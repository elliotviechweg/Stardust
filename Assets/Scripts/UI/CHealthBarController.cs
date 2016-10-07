using UnityEngine;
using UnityEngine.UI;

public class CHealthBarController : MonoBehaviour
{
	public CHealth m_tHealth;

	private Slider m_tHealthBar; 

	private void Start ()
	{
		m_tHealthBar = GetComponent<Slider>();
	}

	private void Update()
	{
		UpdateValue(m_tHealth.CurrentHealth / m_tHealth.MaxHealth);
	}
	
	private void UpdateValue (float i_fNewValue)
	{
		m_tHealthBar.value = i_fNewValue;
	}
}
