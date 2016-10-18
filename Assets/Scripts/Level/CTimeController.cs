using UnityEngine;
using System.Collections;

public class CTimeController : MonoBehaviour
{
	private void Start ()
	{
		Time.timeScale = 1;
	}
	
	public void SetTimeScale(float i_fNewTimeScale)
	{
		Time.timeScale = i_fNewTimeScale;
	}
}
