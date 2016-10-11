using UnityEngine;
using UnityEngine.UI;

public class CHealthTextController : MonoBehaviour
{
	public CHealth m_tHealth;

	private Text m_tHealthText;

	private void Start()
	{
		m_tHealthText = GetComponent<Text>();
	}

	private void Update()
	{
		UpdateValue(m_tHealth.CurrentHealth);
	}

	private void UpdateValue(float i_fNewValueString)
	{
		m_tHealthText.text = ((int)i_fNewValueString).ToString();
	}
}
