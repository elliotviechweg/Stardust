using UnityEngine;

public class CAsteroidMovement : MonoBehaviour {

    public float m_fLinearSpeed;
    public float m_fRotationalSpeed;

    private void Start()
    {
        // Find target
        GameObject tTarget = GameObject.FindGameObjectWithTag(KConstants.PlanetTag);

        // Set velocities
        var tRigidbody = GetComponent<Rigidbody>();
        tRigidbody.angularVelocity = Random.insideUnitSphere * m_fRotationalSpeed;
        tRigidbody.velocity = m_fLinearSpeed * (tTarget.transform.position - transform.position).normalized;
    }
}
