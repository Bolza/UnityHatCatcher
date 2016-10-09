using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	Vector3 screen;
	public GameObject BowlingBall;
	public float timeLeft;
	public Text timerText; 
	public Text scoreText; 
	public GameObject gameOverLabel;
	public GameObject restartButton;
	public GameObject mainPlayer;

	int playerScore = 0;

	void Start () {
		var v3 = new Vector3 (Screen.width, Screen.height, Camera.main.nearClipPlane);
		screen = Camera.main.ScreenToWorldPoint (v3);
		mainPlayer.SetActive (true);
		gameOverLabel.SetActive (false);
		restartButton.SetActive (false);
		StartCoroutine( Spawn () );
	}

	public IEnumerator Spawn() {
		yield return new WaitForSeconds (2);
		while (timeLeft > 0) {
			SpawnBall ();
			yield return new WaitForSeconds (Random.Range (0.5f, 1.5f));
		}
		if (timeLeft <= 0) {
			GameOver ();
		}
	}

	void SpawnBall() {
		float x = Random.Range (-screen.x, screen.x);
		Vector3 sposition = new Vector3 (x, screen.y+2, screen.z);
		GameObject ball = (GameObject)Instantiate (BowlingBall, sposition , Quaternion.identity);
	}

	void FixedUpdate() {
		timeUpdater ();
	}

	void timeUpdater() {
		timeLeft -= Time.deltaTime;
		timerText.text = "Time Left: " + Mathf.Max(0, Mathf.Round(timeLeft));
	}

	void GameOver() {
		gameOverLabel.SetActive (true);
		restartButton.SetActive (true);
		mainPlayer.SetActive (false);

	}

	public void addScore(int score) {
		playerScore += score;
		scoreText.text = "Score: " + playerScore;
	}
}
