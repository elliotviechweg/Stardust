using UnityEngine;

public class CInputManager : MonoBehaviour
{
	public float m_fTouchRadius;
	public float m_fTouchMaxDistance;
	public Camera m_tCamera;
	public LayerMask m_tTouchInputMask;

	private RaycastHit m_tRaycastHit;

	private void Update ()
	{
#if UNITY_EDITOR
		// Check for any input
		if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0) || Input.GetMouseButtonUp(0))
		{
			// Check whether input hit a gameobject
			Ray tRay = m_tCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.SphereCast(tRay, m_fTouchRadius, out m_tRaycastHit, m_fTouchMaxDistance, m_tTouchInputMask))
			{
				// Call appropriete method on gameobject
				GameObject tObjectHit = m_tRaycastHit.transform.gameObject;
				if (Input.GetMouseButtonDown(0))
				{
					tObjectHit.SendMessage("OnTouchDown", m_tRaycastHit.point, SendMessageOptions.DontRequireReceiver);
				}
				/* Not Used Yet
				else if (Input.GetMouseButtonUp(0))
				{
					tObjectHit.SendMessage("OnTouchUp", m_tRaycastHit.point, SendMessageOptions.DontRequireReceiver);
				}
				else if (Input.GetMouseButton(0))
				{
					tObjectHit.SendMessage("OnTouchStay", m_tRaycastHit.point, SendMessageOptions.DontRequireReceiver);
				}
				*/
			}
		}
#else
		// Check for any input
		if (Input.touchCount > 0)
		{
			foreach (Touch tTouch in Input.touches)
			{
				// Check whether input hit a gameobject
				Ray tRay = m_tCamera.ScreenPointToRay(tTouch.position);
				if (Physics.SphereCast(tRay, m_fTouchRadius, out m_tRaycastHit, m_fTouchMaxDistance, m_tTouchInputMask))
				{
					// Call appropriete method on gameobject
					GameObject tObjectHit = m_tRaycastHit.transform.gameObject;
					if (tTouch.phase == TouchPhase.Began)
					{
						tObjectHit.SendMessage("OnTouchDown", m_tRaycastHit.point, SendMessageOptions.DontRequireReceiver);
					}
					/* Not Used Yet
					else if (tTouch.phase == TouchPhase.Ended)
					{
						tObjectHit.SendMessage("OnTouchUp", m_tRaycastHit.point, SendMessageOptions.DontRequireReceiver);
					}
					else if (tTouch.phase == TouchPhase.Stationary || tTouch.phase == TouchPhase.Moved)
					{
						tObjectHit.SendMessage("OnTouchStay", m_tRaycastHit.point, SendMessageOptions.DontRequireReceiver);
					}
					else if (tTouch.phase == TouchPhase.Canceled)
					{
						tObjectHit.SendMessage("OnTouchExit", m_tRaycastHit.point, SendMessageOptions.DontRequireReceiver);
					}
					*/
				}
			}
		}
#endif
	}
}
