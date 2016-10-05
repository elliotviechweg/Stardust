using UnityEngine;

public class CAsteroidSpawner : MonoBehaviour
{
	public float m_fSpawnDelay;
	public float m_fStartDelay;
	public float m_fTotalSpawningTime;
	public float m_fSpawnDistance;
	public float m_fMaxSpawnAngleDegrees;
	public CAsteroidFactory m_tAsteroidFactory;
	public Transform m_tPlanet;

	private float m_fSpawnTimer;
	private float m_fLevelTimer;
	private float m_fMaxSpawnAngleRadians;

	private void Start()
	{
		m_fSpawnTimer = m_fStartDelay;
		m_fLevelTimer = m_fTotalSpawningTime;
		m_fMaxSpawnAngleRadians = m_fMaxSpawnAngleDegrees * Mathf.Deg2Rad;
		
		Random.seed = System.DateTime.Now.Millisecond;
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
				m_tAsteroidFactory.SpawnAsteroid(GenerateSpawnPosition(), m_tPlanet.position);
				m_fSpawnTimer += m_fSpawnDelay;
			}
		}
	}

	private Vector3 GenerateSpawnPosition()
	{
		// Generates random spawn position a given distance away from the planet

		// Generate angle from horizontal, then convert to cartesian coordinates
		float fAngle = m_fMaxSpawnAngleRadians * Random.Range(-1.0f, 1.0f);
		float fXPosition = m_fSpawnDistance * Mathf.Cos(fAngle);
		float fYPosition = m_fSpawnDistance * Mathf.Sin(fAngle);
		
		// Decide whether spawn position is on the left or the right
		if (Random.Range(0, 2) == 0)
		{
			fXPosition = -fXPosition;
		}

		// Spawn position is always offset from planet position
		Vector3 vSpawnOffset = new Vector3(fXPosition, 0, fYPosition);

		return m_tPlanet.position + vSpawnOffset;
	}
}
