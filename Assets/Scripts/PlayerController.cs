using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	float originalY = 0f;
	float borderWidth = 0;
	Vector3 screen;
	void Start () {
		originalY = transform.position.y;
		var v3 = new Vector3 (Screen.width, Screen.height, Camera.main.nearClipPlane);
		screen = Camera.main.ScreenToWorldPoint (v3);
		borderWidth = GetComponent<EdgeCollider2D> ().bounds.extents.x;
	}

	// Update is called once per frame
	void FixedUpdate () {
//		Vector3 mpos = getMouseWorldPoint ();
		AxisMouseControl ();
	}

	Vector3 getMouseWorldPoint() {
		var v3 = Input.mousePosition;
		v3.z = Camera.main.nearClipPlane;
		return Camera.main.ScreenToWorldPoint(v3);
	}

	void AbsoluteMouseControl(Vector3 pos) {
		float clampedx = Mathf.Clamp (pos.x, -screen.x+borderWidth, screen.x-borderWidth);
		transform.position = new Vector3(clampedx, originalY, pos.z);
	}

	void AxisMouseControl() {
		float x = transform.position.x + (Input.GetAxis ("MouseX") * Time.deltaTime);
		x = Mathf.Clamp (x, -screen.x+borderWidth, screen.x-borderWidth);
		transform.position = new Vector3(x, originalY, 1);
	}

}