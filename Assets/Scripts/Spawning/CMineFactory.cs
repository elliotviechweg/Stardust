using UnityEngine;

public class CMineFactory : MonoBehaviour
{
	private GameObject m_tMinePrefab;
	private float m_fMineRadius;

	public void SpawnMine(Vector3 i_vPosition)
	{
		// Check area is clear before spawning
		if (!Physics.CheckSphere(i_vPosition, m_fMineRadius))
		{
			GameObject tNewMine = (GameObject)Instantiate(m_tMinePrefab, i_vPosition, new Quaternion(0, 0, 0, 0));
		}
	}

	private void Start()
	{
		m_tMinePrefab = (GameObject)Resources.Load("Prefabs/Mine");

		// Get Mine radius
		float fMineRadius = -1;
		SphereCollider[] tColliders = m_tMinePrefab.GetComponents<SphereCollider>();
		foreach (SphereCollider tCollider in tColliders)
		{
			if (!tCollider.isTrigger)
			{
				m_fMineRadius = tCollider.radius;
				break;
			}
		}
		Debug.Assert(fMineRadius >= 0, "CMineFactory::Start: Object collider not found");
	}
}
