using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	float originalY = 0f;

	void Start () {
		originalY = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		Debug.logger.Log("finger")
//		float clampedx = Mathf.Clamp (mouse.x, size, Screen.width-size);
		MouseControl();
	}

	void MouseControl() {
		var v3 = Input.mousePosition;
		v3.z = Camera.main.nearClipPlane;
		v3 = Camera.main.ScreenToWorldPoint(v3);
		transform.position = new Vector3(v3.x, originalY, v3.z);
	}
}