using UnityEngine;
using UnityEngine.SceneManagement;

public class CLevelLoader : MonoBehaviour
{
	public string m_sLevelName;

	public void LoadLevel()
	{
		SceneManager.LoadScene(m_sLevelName);
	}
}