using UnityEngine;

public class CLevelIntroductionTransitioner : MonoBehaviour
{
	// Variables set in editor
	[SerializeField]
	private float m_fMaxCameraSpeed;
	[SerializeField]
	private float m_fCameraZoomFactor;
	[SerializeField]
	private float m_fCameraZoomSpeed;
	[SerializeField]
	private float m_fWaitForCameraTime;

	// Components assigned in editor
	[SerializeField]
	private Camera m_tCamera;
	[SerializeField]
	private CLevelLoader m_tLevelLoader;
	[SerializeField]
	private GameObject m_tLevelSummaryCanvas;
	[SerializeField]
	private GameObject m_tLevelIntroductionCanvas;

	// Internally used member variables
	private Vector3 m_vOriginalCameraPosition;
	private Vector3 m_vTargetCameraPosition;
	private Vector3 m_vCurrentCameraVelocity;
	
	private float m_fOriginalCameraSize;
	private float m_fTargetCameraSize;

	private float m_fWaitForCameraTimer;

	private bool m_bUpdateCameraPosition;
	private bool m_bUpdateCameraZoom;

	private bool m_bTransitionRequested;
	private bool m_bSwitchToLevelIntroductionUI;

	// Constants
	private const float m_fEpsilon = 0.001f;

	public void OnTouchDown()
	{
		// Start level if we are ready
		if (ReadyToStartLevel())
		{
			m_tLevelLoader.LoadLevel();
		}
		// Transition to Level Introduction screen if first tap
		else if (!m_bTransitionRequested)
		{
			TransitionToLevelIntroduction();
		}
	}

	private bool ReadyToStartLevel()
	{
		// If the player has asked to transition to the Level Introduction,
		// and the wait for camera timer is over, the player can start the level
		return (m_bTransitionRequested && (m_fWaitForCameraTimer <= 0));
	}

	private void TransitionToLevelIntroduction()
	{
		// Make changes to camera
		CentreCameraOnSelf();
		ZoomCamera();

		// Set timer to wait for camera movement
		m_fWaitForCameraTimer = m_fWaitForCameraTime;

		// Set flags
		m_bTransitionRequested = true;
		m_bSwitchToLevelIntroductionUI = true;
	}
	
	private void CentreCameraOnSelf()
	{
		m_vTargetCameraPosition = m_vOriginalCameraPosition + transform.position;
		m_bUpdateCameraPosition = true;
	}

	private void ZoomCamera()
	{
		m_fTargetCameraSize = m_fOriginalCameraSize / m_fCameraZoomFactor;
		m_bUpdateCameraZoom = true;
	}

	private void Update()
	{
		var Timescale = Time.timeScale;
		if (m_bUpdateCameraPosition)
		{
			m_tCamera.transform.position = Vector3.SmoothDamp(m_tCamera.transform.position, m_vTargetCameraPosition, ref m_vCurrentCameraVelocity, 1 / (Time.deltaTime * m_fMaxCameraSpeed));
			// Stop when we've reached the target
			if ((m_tCamera.transform.position - m_vTargetCameraPosition).sqrMagnitude <= m_fEpsilon)
			{
				m_tCamera.transform.position = m_vTargetCameraPosition;
				m_bUpdateCameraPosition = false;
			}
		}

		if (m_bUpdateCameraZoom)
		{
			m_tCamera.orthographicSize = Mathf.Lerp(m_tCamera.orthographicSize, m_fTargetCameraSize, Time.deltaTime * m_fCameraZoomSpeed);
			// Stop when we've reached the target
			if (Mathf.Abs(m_tCamera.orthographicSize - m_fTargetCameraSize) <= m_fEpsilon)
			{
				m_tCamera.orthographicSize = m_fTargetCameraSize;
				m_bUpdateCameraZoom = false;
			}
		}

		// If timer is going, decrement it
		if (m_fWaitForCameraTimer > 0)
		{
			m_fWaitForCameraTimer -= Time.deltaTime;
		}
		// Otherwise, timer has finished, so check whether the UI needs to be switched
		else if (m_bSwitchToLevelIntroductionUI)
		{
			SwitchUI();
		}
	}

	private void SwitchUI()
	{
		m_tLevelSummaryCanvas.SetActive(!m_tLevelSummaryCanvas.activeSelf);
		m_tLevelIntroductionCanvas.SetActive(!m_tLevelIntroductionCanvas.activeSelf);
		m_bSwitchToLevelIntroductionUI = false;
	}

	private void Start()
	{
		m_vOriginalCameraPosition = m_tCamera.transform.position;
		m_vTargetCameraPosition = m_vOriginalCameraPosition;
		m_bUpdateCameraPosition = false;

		m_fOriginalCameraSize = m_tCamera.orthographicSize;
		m_fTargetCameraSize = m_fOriginalCameraSize;
		m_bUpdateCameraZoom = false;

		m_fWaitForCameraTimer = 0;

		m_bTransitionRequested = false;
		m_bSwitchToLevelIntroductionUI = false;
	}
}
