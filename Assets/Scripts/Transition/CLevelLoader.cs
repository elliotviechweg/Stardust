using UnityEngine;
using UnityEngine.SceneManagement;

public class CLevelLoader : MonoBehaviour
{
	public string m_sLevelName;

	private void OnTouchDown ()
	{
		LoadLevel();
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene(m_sLevelName);
	}
}