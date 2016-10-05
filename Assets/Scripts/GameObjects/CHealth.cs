using UnityEngine;

public class CHealth : MonoBehaviour
{
	public float MaxHealth
	{
		get
		{
			return m_fMaxHealth;
		}
		set
		{
			m_fMaxHealth = value;
		}
	}
	[SerializeField]
	private float m_fMaxHealth;

	public float CurrentHealth
	{
		get
		{
			return m_fCurrentHealth;
		}
	}
	private float m_fCurrentHealth;

	public void DoDamage(float i_fDamageTaken)
	{
		m_fCurrentHealth -= i_fDamageTaken;
		if (m_fCurrentHealth <= 0)
		{
			m_fCurrentHealth = 0;
			// Planet destroyed
		}
	}

	private void Start()
	{
		m_fCurrentHealth = m_fMaxHealth;
	}
}
