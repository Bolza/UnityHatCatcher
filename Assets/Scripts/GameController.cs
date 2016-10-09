using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	Vector3 screen;
	public GameObject BowlingBall;
	public float timeLeft;
	public Text timerText; 
	public Text scoreText; 
	int playerScore = 0;

	void Start () {
		var v3 = new Vector3 (Screen.width, Screen.height, Camera.main.nearClipPlane);
		screen = Camera.main.ScreenToWorldPoint (v3);
		StartCoroutine( Spawn () );
	}

	public IEnumerator Spawn() {
		yield return new WaitForSeconds (2);
		while (timeLeft > 0) {
			float x = Random.Range (-screen.x, screen.x);
			Vector3 sposition = new Vector3 (x, screen.y+2, screen.z);
			GameObject ball = (GameObject)Instantiate (BowlingBall, sposition , Quaternion.identity);
//			Vector3 force = new Vector3(Random.Range (-300, 300), 0, 0);
//			ball.GetComponent<Rigidbody2D> ().AddForce (force);
			yield return new WaitForSeconds (Random.Range (1, 2));
		}
	}

	void FixedUpdate() {
		timeLeft -= Time.deltaTime;
		timerText.text = "Time Left: " + Mathf.Max(0, Mathf.Round(timeLeft));
	}

	public void addScore(int score) {
		playerScore += score;
		scoreText.text = "Score: " + playerScore;
	}
}
