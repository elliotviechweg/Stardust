using UnityEngine;
using System.Collections;

public class CPlanetSpin : MonoBehaviour
{
    public float m_fRotationalSpeed;

    void Start()
    {
		// TODO: use rigidbody.angularVelocity here instead of constant update calls
    }

    void Update()
    {
        transform.Rotate(0, -Time.deltaTime * m_fRotationalSpeed, 0);
    }
}
