using UnityEngine;

public class CAsteroidSpawner : MonoBehaviour
{
	public float m_fSpawnDelay;
	public float m_fStartDelay;
	public float m_fTotalSpawningTime;
	public float m_fSpawnDistance;
	public float m_fZOffset;

	public float m_fTopRightMaxSpawnAngleDegrees;
	public float m_fTopLeftMaxSpawnAngleDegrees;
	public float m_fBottomLeftMaxSpawnAngleDegrees;
	public float m_fBottomRightMaxSpawnAngleDegrees;

	public CAsteroidFactory m_tAsteroidFactory;
	public Transform m_tPlanet;

	private float m_fSpawnTimer;
	private float m_fLevelTimer;

	private void Start()
	{
		m_fSpawnTimer = m_fStartDelay;
		m_fLevelTimer = m_fTotalSpawningTime;
		
		Random.InitState(System.DateTime.Now.Millisecond);
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
		// Generate random spawn position a given distance away from the planet
				
		// Decide which quadarant to use
		EQuadrant eQuadrant = CQuadrant.GetRandomQuadrant();

		// Set angle of approach for asteroid
		float fAngle = 0;
		switch (eQuadrant)
		{
			case EQuadrant.TopRight:
				fAngle = Random.Range(0.0f, 1.0f) * m_fTopRightMaxSpawnAngleDegrees * Mathf.Deg2Rad;
				break;
			case EQuadrant.TopLeft:
				fAngle = Mathf.PI - (Random.Range(0.0f, 1.0f) * m_fTopLeftMaxSpawnAngleDegrees * Mathf.Deg2Rad);
				break;
			case EQuadrant.BottomLeft:
				fAngle = Mathf.PI + (Random.Range(0.0f, 1.0f) * m_fBottomLeftMaxSpawnAngleDegrees * Mathf.Deg2Rad);
				break;
			case EQuadrant.BottomRight:
				fAngle = 2 * Mathf.PI - (Random.Range(0.0f, 1.0f) * m_fBottomRightMaxSpawnAngleDegrees * Mathf.Deg2Rad);
				break;
		}

		// Convert angle to cartesian coordinates
		float fXPosition = m_fSpawnDistance * Mathf.Cos(fAngle);
		float fYPosition = m_fSpawnDistance * Mathf.Sin(fAngle);

		// Spawn position is always offset from planet position
		Vector3 vSpawnOffset = new Vector3(fXPosition, fYPosition, m_fZOffset);

		return m_tPlanet.position + vSpawnOffset;
	}
}

public enum EQuadrant
{
	TopRight,
	TopLeft,
	BottomLeft,
	BottomRight,

	Noof
}

public static class CQuadrant
{
	public static EQuadrant GetRandomQuadrant()
	{
		return IntToQuadrant(Random.Range(0, (int)EQuadrant.Noof));
	}

	private static EQuadrant IntToQuadrant(int i_iQuadrantInt)
	{
		return (EQuadrant)i_iQuadrantInt;
	}
}
