using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDestroyLoadScene : MonoBehaviour
{
	[SerializeField]
	string _sceneName;

	void OnDestroy()
	{
		SceneManager.LoadScene(_sceneName);
	}
}
