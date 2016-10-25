using UnityEngine;
using UnityEngine.UI;

public class CPowerUpButtonController : MonoBehaviour
{
	// Variables set in editor
	[SerializeField]
	private float m_fCooldownTime;
	[SerializeField]
	// If max uses is set to -1, the power up has no use limit
	private int m_iMaxUses;

	// Internally used member variables
	private Button m_tPowerUpButton;

	private float m_fCooldownTimer;
	private float m_iUsesRemaining;

	public void OnTouchDown()
	{
		m_fCooldownTimer = m_fCooldownTime;
		m_iUsesRemaining--;
		m_tPowerUpButton.interactable = false;
	}

	private void Start()
	{
		m_tPowerUpButton = GetComponent<Button>();
		m_iUsesRemaining = m_iMaxUses;

		// If no uses remain, power up button starts disabled
		m_tPowerUpButton.interactable = (m_iUsesRemaining != 0);
	}

	private void Update()
	{
		// If timer is going, reduce time remaining, otherwise make the button interactable
		if (m_fCooldownTimer > 0)
		{
			m_fCooldownTimer -= Time.deltaTime;
		}
		else if (!m_tPowerUpButton.interactable && m_iUsesRemaining != 0)
		{
			m_tPowerUpButton.interactable = true;
		}
	}
}
