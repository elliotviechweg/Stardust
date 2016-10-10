using UnityEngine;

public class CLevelTimerController : MonoBehaviour
{
	public float TotalLevelTime
	{
		get
		{
			return m_fTotalLevelTime;
		}
	}
	[SerializeField]
	private float m_fTotalLevelTime;

	public float LevelTimer
	{
		get
		{
			return m_fLevelTimer;
		}
	}
	private float m_fLevelTimer;

	private void Start()
	{
		m_fLevelTimer = m_fTotalLevelTime;
	}

	private void Update()
	{
		// Reduce timer
		m_fLevelTimer -= Time.deltaTime;
		if (m_fLevelTimer < 0)
		{
			m_fLevelTimer = 0;
		}
	}
}
