﻿using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public GameObject explosion;
	public ParticleSystem[] effects;
	BallCollide ballCollide;

	void Start() {
		ballCollide = this.GetComponent<BallCollide>();
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Hat") {
			Instantiate (explosion, transform.position, transform.rotation);
			foreach (var effect in effects) {
				effect.transform.parent = null;
				effect.Stop ();
				Destroy (effect.gameObject, 1.0f);
			}
			ballCollide.Hit ();
		}
	}
}
