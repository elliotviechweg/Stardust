using UnityEngine;

public class CScoreController : MonoBehaviour
{
	public CScoreCounterController m_tScoreCounterController;

	private float m_fScore;

	public float GetScore()
	{
		return m_fScore;
	}

	private void Start()
	{
		CScoreEventReceiver.SetScoreCounter(this);
		m_fScore = 0;
	}

	public void IncreaseScore(float i_fScoreValue)
	{
		m_fScore += i_fScoreValue;
		m_tScoreCounterController.UpdateText();
	}
}
