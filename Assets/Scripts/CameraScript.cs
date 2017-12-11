using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public bool movX;
	public bool movY;
	public Transform canvas;
	bool onPause = false;
	private Transform pt;

	void Start () {	
		pt = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			if (onPause == false) {
				Time.timeScale = 0;
				canvas.gameObject.SetActive (true);
				onPause = true;
			} else {
				Time.timeScale = 1;
				canvas.gameObject.SetActive (false);
				onPause = false;
			}
		}
		if (Mathf.Abs (transform.position.x - pt.position.x) > 2) {
			transform.Translate (
				new Vector3 ((pt.position.x - transform.position.x)*2, 0)
				*Time.deltaTime);
		}
		if (Mathf.Abs (transform.position.y - pt.position.y) > 2 && transform.position.y >= -2) {
			transform.Translate (
				new Vector3 (0, (pt.position.y - transform.position.y)*3)
				*Time.deltaTime);
		}
	}
}