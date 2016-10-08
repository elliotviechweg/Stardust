using UnityEngine;

public class CDestroyParticlesWhenDone : MonoBehaviour
{
	private ParticleSystem m_tParticleSystem;

	private void Start()
	{
		m_tParticleSystem = GetComponent<ParticleSystem>();
	}

	public void Update()
	{
		if (m_tParticleSystem)
		{
			if (!m_tParticleSystem.IsAlive())
			{
				Destroy(gameObject);
			}
		}
	}
}
