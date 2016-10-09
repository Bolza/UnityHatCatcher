using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class RestartGame : MonoBehaviour {

	// Use this for initialization
	public void Restart() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}
}
