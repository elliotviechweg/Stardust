using UnityEngine;
using UnityEngine.UI;

public class CLevelTimerTextController : MonoBehaviour
{
	// Components assigned in editor
	[SerializeField]
	private CLevelTimerController m_tLevelTimerController;

	// Internally used member variables
	private Text m_tLevelTimerText;

	private void Start()
	{
		m_tLevelTimerText = GetComponent<Text>();
	}

	private void Update()
	{
		UpdateText(m_tLevelTimerController.LevelTimer);
	}

	private void UpdateText(float i_fNewValueString)
	{
		m_tLevelTimerText.text = ((int)i_fNewValueString).ToString();
	}
}
