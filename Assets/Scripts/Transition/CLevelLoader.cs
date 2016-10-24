using UnityEngine;
using UnityEngine.SceneManagement;

public class CLevelLoader : MonoBehaviour
{
	// Variables set in editor
	[SerializeField]
	private string m_sLevelName;

	public void LoadLevel()
	{
		SceneManager.LoadScene(m_sLevelName);
	}
}