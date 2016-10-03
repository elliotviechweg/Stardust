using UnityEngine;

public static class CScoreEventReceiver
{
	private static CScoreController m_tScoreCounter;

	public static void SetScoreCounter(CScoreController i_tStoreCounter)
	{
		m_tScoreCounter = i_tStoreCounter;
	}

	public static void IncreaseScore(float i_fScoreValue)
	{
		if (m_tScoreCounter != null)
		{
			m_tScoreCounter.IncreaseScore(i_fScoreValue);
		}
	}
}
