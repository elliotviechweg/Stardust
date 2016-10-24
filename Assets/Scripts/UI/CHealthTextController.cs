using UnityEngine;
using UnityEngine.UI;

public class CHealthTextController : MonoBehaviour
{
	// Components assigned in editor
	[SerializeField]
	private CHealth m_tHealth;

	// Internally used member variables
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
