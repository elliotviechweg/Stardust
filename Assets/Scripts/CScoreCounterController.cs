using UnityEngine;
using UnityEngine.UI;

public class CScoreCounterController : MonoBehaviour
{
	public string m_sInitialText;
	public CScoreController m_tScoreController;

	private Text m_tText;
	

	private void Start()
	{
		m_tText = GetComponent<Text>();
		UpdateText();
	}

	public void UpdateText()
	{
		m_tText.text = m_sInitialText + m_tScoreController.GetScore();
	}
}
