using UnityEngine;
using UnityEngine.UI;

public class CLevelTimerTextController : MonoBehaviour
{
	public CLevelTimerController m_tLevelTimerController;

	private Text m_tLevelTimerText;

	private void Start()
	{
		m_tLevelTimerText = GetComponent<Text>();
	}

	private void Update()
	{
		UpdateValue(m_tLevelTimerController.LevelTimer);
	}

	private void UpdateValue(float i_fNewValueString)
	{
		m_tLevelTimerText.text = ((int)i_fNewValueString).ToString();
	}
}
