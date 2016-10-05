using UnityEngine;

public class CScoreController : MonoBehaviour
{
	public static CScoreController Instance
	{
		get
		{
			return m_tInstance;
		}
	}
	private static CScoreController m_tInstance = null;

	public float Score
	{
		get
		{
			return m_fScore;
		}
	}
	private float m_fScore;

	public CScoreCounterController m_tScoreCounterController;

	public CScoreController()
	{
		if (m_tInstance != null)
		{
			Destroy(this);
		}

		m_tInstance = this;
		
		m_fScore = 0;
	}

	public void IncreaseScore(float i_fScoreValue)
	{
		m_fScore += i_fScoreValue;
		if (m_tScoreCounterController != null)
		{
			m_tScoreCounterController.UpdateText();
		}
	}
}
