using UnityEngine;

public class CAsteroidMovement : MonoBehaviour
{
    public float m_fLinearSpeed;
    public float m_fRotationalSpeed;

	public void MoveTowardsTarget(Vector3 i_vTarget)
	{
		Rigidbody tRigidbody = GetComponent<Rigidbody>();
		tRigidbody.angularVelocity = Random.insideUnitSphere * m_fRotationalSpeed;
		tRigidbody.velocity = m_fLinearSpeed * (i_vTarget - transform.position).normalized;
	}
}
