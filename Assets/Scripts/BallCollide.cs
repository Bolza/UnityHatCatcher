using UnityEngine;
using System.Collections;

public class BallCollide : MonoBehaviour {
	GameController game;
	public int points = 1;

	void Start() {
		game = GameObject.Find("GameLevelController").GetComponent<GameController>();
		game.addSpawnedItem();

	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Hat") {
			Hit ();
		} else if (other.gameObject.name == "LevelBoundary") {
			Die ();
		}
	}

	public void Hit() {
		game.addScore (points);
		Die ();
	}

	void Die() {
		game.removeSpawnedItem();
		Destroy (this.gameObject);
	}
}
