using UnityEngine;
using UnityEngine.UI;

public class CSuccessTextController : MonoBehaviour
{
	// Variables set in editor
	[SerializeField]
	private string m_sSuccessMessage;
	[SerializeField]
	private string m_sFailureMessage;
	
	public void UpdateText(bool i_bLevelSuccessful)
	{
		GetComponent<Text>().text = i_bLevelSuccessful ? m_sSuccessMessage : m_sFailureMessage;
	}
}
