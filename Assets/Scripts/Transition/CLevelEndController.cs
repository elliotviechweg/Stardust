using UnityEngine;

public class CLevelEndController : MonoBehaviour
{
	public CLevelTimerController m_tLevelTimerController;
	public CHealth m_tPlanetHealth;
	public GameObject m_tLevelUICanvas;
	public GameObject m_tLevelEndUICanvas;
	public CSuccessTextController m_tSuccessTextController;

	private bool m_bHasTransitioned = false;
	
	private void Update ()
	{
		if (!m_bHasTransitioned)
		{
			if (m_tPlanetHealth.IsDead())
			{
				TransitionToLevelEnd(i_bLevelSuccessful: false);
			}
			else if (m_tLevelTimerController.TimerFinished())
			{
				TransitionToLevelEnd(i_bLevelSuccessful: true);
			}
		}
	}

	private void TransitionToLevelEnd(bool i_bLevelSuccessful)
	{
		m_tLevelUICanvas.SetActive(false);
		m_tLevelEndUICanvas.SetActive(true);
		m_tSuccessTextController.UpdateText(i_bLevelSuccessful);

		Time.timeScale = 0;

		m_bHasTransitioned = true;
	} 
}
