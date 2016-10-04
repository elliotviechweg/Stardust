using UnityEngine;

public class CAsteroidFactory : MonoBehaviour
{
	private GameObject m_tAsteroidPrefab;

	public void SpawnAsteroid(Vector3 i_vPosition, Vector3 i_vTarget)
	{
		GameObject tNewAsteroid = Instantiate(m_tAsteroidPrefab);
		tNewAsteroid.transform.position = i_vPosition;
		tNewAsteroid.GetComponent<CAsteroidMovement>().MoveTowardsTarget(i_vTarget);
	}

	private void Start()
	{
		m_tAsteroidPrefab = (GameObject)Resources.Load("Prefabs/Asteroid");
	}
}
