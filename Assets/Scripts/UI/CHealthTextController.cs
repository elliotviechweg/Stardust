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
		UpdateText(m_tHealth.CurrentHealth);
	}

	private void UpdateText(float i_fNewValueString)
	{
		m_tHealthText.text = ((int)i_fNewValueString).ToString();
	}
}
