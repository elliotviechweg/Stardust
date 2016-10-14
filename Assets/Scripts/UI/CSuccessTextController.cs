using UnityEngine;
using UnityEngine.UI;

public class CSuccessTextController : MonoBehaviour
{
	public string m_sSuccessMessage;
	public string m_sFailureMessage;
	
	public void UpdateText(bool i_bLevelSuccessful)
	{
		GetComponent<Text>().text = i_bLevelSuccessful ? m_sSuccessMessage : m_sFailureMessage;
	}
}
