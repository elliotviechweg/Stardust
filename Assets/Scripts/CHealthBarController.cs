using UnityEngine;
using UnityEngine.UI;

public class CHealthBarController : MonoBehaviour
{
	private Slider m_tHealthBar; 

	void Start ()
	{
		m_tHealthBar = GetComponent<Slider>();
		UpdateValue(1);
	}
	
	// Update is called once per frame
	public void UpdateValue (float i_fNewValue)
	{
		m_tHealthBar.value = i_fNewValue;
	}
}
