using UnityEngine;

public class CDestroyParticlesWhenDone : MonoBehaviour
{
	// Internally used member variables
	private ParticleSystem m_tParticleSystem;
	
	private void Update()
	{
		if (m_tParticleSystem)
		{
			if (!m_tParticleSystem.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}

	private void Start()
	{
		m_tParticleSystem = GetComponent<ParticleSystem>();
	}
}
