using UnityEngine;

public class CAsteroidDestruction : MonoBehaviour
{
	public float m_fDamageDealt;
	public int m_iPointsAwarded;

	private void OnCollisionEnter(Collision i_tCollision)
	{
		// Do damage to the planet if we hit it
        if (i_tCollision.gameObject.tag == KConstants.PlanetTag)
        {
			i_tCollision.gameObject.GetComponent<CHealth>().DoDamage(m_fDamageDealt);
        }

		DestroySelf();
    }
	
	private void OnMouseDown()
	{
		CScoreEventReceiver.IncreaseScore(m_iPointsAwarded);
		DestroySelf();
	}

	private void DestroySelf()
	{
		Destroy(this.gameObject);
		// Play VFX
	}
}
