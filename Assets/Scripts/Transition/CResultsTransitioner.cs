using UnityEngine;

public class CResultsTransitioner : MonoBehaviour
{
	public CLevelTimerController m_tLevelTimerController;
	public CHealth m_tPlanetHealth;
	public GameObject m_tLevelUICanvas;
	public GameObject m_tResultsUICanvas;
	public CSuccessTextController m_tSuccessTextController;
	public CTimeController m_tTimeController;

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
