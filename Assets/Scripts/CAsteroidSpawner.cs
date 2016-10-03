using UnityEngine;

public class CAsteroidSpawner : MonoBehaviour
{
	public float m_fSpawnDelay;
	public float m_fStartDelay;
	public float m_fTotalLevelTime;
	public CAsteroidFactory m_tAsteroidFactory;

	private float m_fSpawnTimer;
	private float m_fLevelTimer;

	private void Start()
	{
		m_fSpawnTimer = m_fStartDelay;
		m_fLevelTimer = m_fTotalLevelTime;
	}

	private void Update()
	{
		// If the level timer is not up, resolve the spawn timer
		m_fLevelTimer -= Time.deltaTime;
		if (m_fLevelTimer > 0)
		{
			// If the spawn timer is up, spawn a new asteroid and reset the timer
			m_fSpawnTimer -= Time.deltaTime;
			if (m_fSpawnTimer <= 0)
			{
				m_tAsteroidFactory.SpawnAsteroid(new Vector3(10, 0, 10));
				m_fSpawnTimer += m_fSpawnDelay;
			}
		}
	}
}
