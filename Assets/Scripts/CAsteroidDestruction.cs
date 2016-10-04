using UnityEngine;

public class CAsteroidDestruction : MonoBehaviour
{
	public float m_fDamageDealt;
	public int m_iPointsAwarded;

	private void OnCollisionEnter(Collision i_tCollision)
	{
		// If we hit something with health, do damage to it
		CHealth tHealth = i_tCollision.gameObject.GetComponent<CHealth>();
		if (tHealth != null)
		{
			i_tCollision.gameObject.GetComponent<CHealth>().DoDamage(m_fDamageDealt);
		}

		DestroySelf();
    }
	
	private void OnMouseDown()
	{
		CScoreController tScoreController = CScoreController.Instance;

		Debug.Assert(tScoreController != null, "CAsteroidDestruction::OnMouseDown: Score Controller hasn't been initialized");
		if (tScoreController != null)
		{
			CScoreController.Instance.IncreaseScore(m_iPointsAwarded);
		}

		DestroySelf();
	}

	private void DestroySelf()
	{
		Destroy(this.gameObject);
		// Play VFX
	}
}
