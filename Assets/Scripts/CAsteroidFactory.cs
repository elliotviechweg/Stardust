using UnityEngine;
using System.Collections;

public class CAsteroidFactory : MonoBehaviour
{
	private GameObject m_tAsteroidPrefab;

	public void SpawnAsteroid(Vector3 i_vPosition)
	{
		GameObject tNewAsteroid = Instantiate(m_tAsteroidPrefab);
		tNewAsteroid.transform.position = i_vPosition;
	}

	private void Start()
	{
		m_tAsteroidPrefab = (GameObject)Resources.Load("Prefabs/Asteroid");
	}
}
