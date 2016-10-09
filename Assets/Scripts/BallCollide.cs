using UnityEngine;
using System.Collections;

public class BallCollide : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.gameObject.tag == "Hat") {
			Destroy (this.gameObject);
		} else if (other.gameObject.name == "LevelBoundary") {
			Destroy (this.gameObject);
		}
	}
}
