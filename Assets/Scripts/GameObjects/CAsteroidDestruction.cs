using UnityEngine;

public class CAsteroidDestruction : MonoBehaviour
{
	// Variables set in editor
	[SerializeField]
	private float m_fDamageDealt;
	[SerializeField]
	private int m_iPointsAwarded;

	// Components assigned in editor
	[SerializeField]
	private GameObject m_tExplosionVFX;
	[SerializeField]
	private GameObject m_tImpactVFX;

	// Internally used member variables
    private CResultsTransitioner m_tLevelResultTransitioner;

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
        // If the level results transitioner has transitioner consider the level over and ignore the input
        if (m_tLevelResultTransitioner.HasTransitioned)
        {
            return;
        }

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

	private void Start()
	{
		// Cache the level result transitioner for this level so it doesn't need to looked up on each tap
		m_tLevelResultTransitioner = FindObjectOfType<CResultsTransitioner>();
		Debug.Assert(m_tLevelResultTransitioner != null);
	}
}
