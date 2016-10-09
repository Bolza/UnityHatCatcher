using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	float maxWidth;
	// Use this for initialization
	void Start () {
		Vector3 uc = new Vector3 (Screen.width, Screen.height, 10);
		Vector3 raw = Camera.main.ScreenToWorldPoint (uc);
		maxWidth = raw.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		var clip = Camera.main.nearClipPlane ();
//		float x = Input.GetAxis ("Horizontal") * Time.deltaTime;
		float mousex = Input.GetAxis ("MouseX");
		float mousey = Input.GetAxis ("MouseY");
		Vector3 mouse = new Vector3 (mousex, mousey, 1);
		Vector3 world = Camera.main.ScreenToWorldPoint (this.transform.position);
//		Debug.logger.Log ("mouse",mousex );
//		Debug.logger.Log ("world");
		Rigidbody2D cmp = GetComponent<Rigidbody2D>();
//		this.transform.position = mouse;
		float clampedx = Mathf.Clamp (mouse.x, -Screen.width, Screen.width);
//		this.transform.position -9 / +9
		cmp.transform.position = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 12));
		Debug.logger.Log ("pos",cmp.transform.position );
		cmp.transform.Translate (clampedx, 0f, 0f);
	}
}