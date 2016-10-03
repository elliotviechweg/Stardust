using UnityEngine;
using UnityEngine.UI;

public class CScoreCounterController : MonoBehaviour
{
	public string m_sInitialText;

	private Text m_tText;
	private CScoreController m_tScoreController;
	
	private void Start()
	{
		m_tText = GetComponent<Text>();
		m_tScoreController = CScoreController.Instance;
		UpdateText();
	}

	public void UpdateText()
	{
		Debug.Assert(m_tScoreController != null, "CScoreCounterController::UpdateText: Score Controller hasn't been initialized");

		string sOutputText = m_sInitialText;
		if (m_tScoreController != null)
		{
			sOutputText += m_tScoreController.Score;
		}
		m_tText.text = sOutputText;
	}
}
