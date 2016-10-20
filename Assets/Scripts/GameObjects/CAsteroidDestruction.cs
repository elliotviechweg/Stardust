using UnityEngine;

public class CAsteroidDestruction : MonoBehaviour
{
	public float m_fDamageDealt;
	public int m_iPointsAwarded;
	public GameObject m_tExplosionVFX;
	public GameObject m_tImpactVFX;

	private void OnCollisionEnter(Collision i_tCollision)
	{
		// If we hit something with health, do damage to it
		CHealth tHealth = i_tCollision.gameObject.GetComponent<CHealth>();
		if (tHealth != null)
		{
			i_tCollision.gameObject.GetComponent<CHealth>().DoDamage(m_fDamageDealt);
		}

		// Set vfx rotation to be pointing at the first point of contact
		Quaternion tVFXRotation = Quaternion.LookRotation(i_tCollision.contacts[0].normal);

		DestroySelf(m_tImpactVFX, tVFXRotation);
    }
	
	private void OnTouchDown()
	{
		DestroyByPlayer();
	}

	private void DestroyByMine()
	{
		IncreaseScore();
		DestroySelf(m_tExplosionVFX, transform.rotation);
	}

	private void DestroyByPlayer()
	{
		IncreaseScore();
		DestroySelf(m_tExplosionVFX, transform.rotation);
	}

	private void IncreaseScore()
	{
		CScoreController tScoreController = CScoreController.Instance;

		Debug.Assert(tScoreController != null, "CAsteroidDestruction::OnMouseDown: Score Controller hasn't been initialized");
		if (tScoreController != null)
		{
			tScoreController.IncreaseScore(m_iPointsAwarded);
		}
	}
	
	private void DestroySelf(GameObject i_tVFXObject, Quaternion i_tVFXRotation)
	{
		// Create VFX
		Instantiate(i_tVFXObject, transform.position, i_tVFXRotation);

		Destroy(gameObject);
	}
}
