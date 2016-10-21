using UnityEngine;
using UnityEngine.SceneManagement;

public class CSceneLoader : MonoBehaviour
{
	public string m_sLevelName;

	public void OnTouchDown ()
	{
		SceneManager.LoadScene(m_sLevelName);
	}
}