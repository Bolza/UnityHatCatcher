using UnityEngine;
using System.Collections;

public class BallCollide : MonoBehaviour {
	GameController game;
	public int points = 1;
	void Start() {
		game = GameObject.Find("GameLevelController").GetComponent<GameController>();
	}
	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "Hat") {
			game.addScore (points);
			Destroy (this.gameObject);
		} else if (other.gameObject.name == "LevelBoundary") {
			Destroy (this.gameObject);
		}
	}
}
