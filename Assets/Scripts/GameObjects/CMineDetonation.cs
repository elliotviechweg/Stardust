using UnityEngine;

public class CMineDetonation : MonoBehaviour
{
	public float m_fExplosionRadius;

	private void OnTriggerEnter()
	{
		Collider[] tObjectsInExplosion = Physics.OverlapSphere(transform.position, m_fExplosionRadius);

		foreach(Collider tObject in tObjectsInExplosion)
		{
			tObject.SendMessage("DestroyByMine", SendMessageOptions.DontRequireReceiver);
		}

		DestroySelf();
	}

	private void DestroySelf()
	{
		// Add explosion VFX here
		Destroy(gameObject);
	}
}
