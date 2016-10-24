using UnityEngine;

public class CScoreController : MonoBehaviour
{
	// Properties
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
	
	public void IncreaseScore(float i_fScoreValue)
	{
		m_fScore += i_fScoreValue;
	}

	public CScoreController()
	{
		if (m_tInstance != null)
		{
			Destroy(this);
		}

		m_tInstance = this;
	}

	private void Start()
	{
		m_fScore = 0;
	}
}
