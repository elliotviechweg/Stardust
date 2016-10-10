using UnityEngine;

public class CPlanetSpin : MonoBehaviour
{
    public float m_fRotationalSpeed;
	
    private void Update()
    {
        transform.Rotate(0, -Time.deltaTime * m_fRotationalSpeed, 0);
    }
}
