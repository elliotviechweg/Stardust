using UnityEngine;

public class CAsteroidFactory : MonoBehaviour
{
	private GameObject m_tAsteroidPrefab;

	public void SpawnAsteroid(Vector3 i_vPosition, Vector3 i_vTarget)
	{
		GameObject tNewAsteroid = (GameObject)Instantiate(m_tAsteroidPrefab, i_vPosition, new Quaternion(0,0,0,0));
		tNewAsteroid.GetComponent<CAsteroidMovement>().MoveTowardsTarget(i_vTarget);
	}

	private void Start()
	{
		m_tAsteroidPrefab = (GameObject)Resources.Load("Prefabs/Asteroid");
	}
}
