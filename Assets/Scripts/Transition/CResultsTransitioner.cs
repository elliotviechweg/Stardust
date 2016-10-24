using UnityEngine;

public class CResultsTransitioner : MonoBehaviour
{
	// Components assigned in editor
	[SerializeField]
	private CLevelTimerController m_tLevelTimerController;
	[SerializeField]
	private CHealth m_tPlanetHealth;
	[SerializeField]
	private GameObject m_tLevelUICanvas;
	[SerializeField]
	private GameObject m_tResultsUICanvas;
	[SerializeField]
	private CSuccessTextController m_tSuccessTextController;
	[SerializeField]
	private CTimeController m_tTimeController;

	// Properties
	public bool HasTransitioned
    {
        get
		{
			return m_bHasTransitioned;
		}
    }
	private bool m_bHasTransitioned = false;
	
	private void Update ()
	{
		if (!m_bHasTransitioned)
		{
			if (m_tPlanetHealth.IsDead())
			{
				TransitionToResults(i_bLevelSuccessful: false);
			}
			else if (m_tLevelTimerController.TimerFinished())
			{
				TransitionToResults(i_bLevelSuccessful: true);
			}
		}
	}

	private void TransitionToResults(bool i_bLevelSuccessful)
	{
		m_tLevelUICanvas.SetActive(false);
		m_tResultsUICanvas.SetActive(true);
		m_tSuccessTextController.UpdateText(i_bLevelSuccessful);

		m_tTimeController.SetTimeScale(0);

		m_bHasTransitioned = true;
	} 
}
