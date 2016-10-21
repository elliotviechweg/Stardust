using UnityEngine;

public class CLevelIntroductionTransitioner : MonoBehaviour
{
	public float m_fMaxCameraSpeed;
	public float m_fCameraZoomFactor;
	public float m_fCameraZoomSpeed;

	public Camera m_tCamera;

	private Vector3 m_vOriginalCameraPosition;
	private Vector3 m_vTargetCameraPosition;
	private Vector3 m_vCurrentCameraVelocity;

	private float m_fOriginalCameraSize;
	private float m_fTargetCameraSize;

	private bool m_bUpdateCameraPosition;
	private bool m_bUpdateCameraZoom;

	private float m_fEpsilon = 0.001f;

	public void OnTouchDown()
	{
		CentreCameraOnSelf();
		ZoomCamera();
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
	}

	private void Start()
	{
		m_vOriginalCameraPosition = m_tCamera.transform.position;
		m_vTargetCameraPosition = m_vOriginalCameraPosition;
		m_bUpdateCameraPosition = false;

		m_fOriginalCameraSize = m_tCamera.orthographicSize;
		m_fTargetCameraSize = m_fOriginalCameraSize;
		m_bUpdateCameraZoom = false;
	}
}
