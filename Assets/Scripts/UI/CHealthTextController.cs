using UnityEngine;
using UnityEngine.UI;

public class CHealthTextController : MonoBehaviour {

	public CHealth m_tHealth;

	private Text m_tHealthText;

	private void Start()
	{
		m_tHealthText = GetComponent<Text>();
	}

	private void Update()
	{
		UpdateValue(m_tHealth.CurrentHealth.ToString());
	}

	private void UpdateValue(string i_sNewValueString)
	{
		m_tHealthText.text = i_sNewValueString;
	}
}
