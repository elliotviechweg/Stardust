using UnityEngine;
using UnityEngine.UI;

public class CLevelTimerBarController : MonoBehaviour
{
	public CLevelTimerController m_tLevelTimerController;

	private Slider m_tLevelTimerBar;

	private void Start()
	{
		m_tLevelTimerBar = GetComponent<Slider>();
	}

	private void Update()
	{
		UpdateValue(m_tLevelTimerController.LevelTimer / m_tLevelTimerController.TotalLevelTime);
	}

	private void UpdateValue(float i_fNewValue)
	{
		m_tLevelTimerBar.value = i_fNewValue;
	}
}
