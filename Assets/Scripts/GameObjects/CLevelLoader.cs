using UnityEngine;
using UnityEngine.SceneManagement;

public class CLevelLoader : MonoBehaviour
{
	public string m_sLevelName;

	private void OnTouchDown () {
		SceneManager.LoadScene(m_sLevelName);
	}
}