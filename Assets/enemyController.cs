using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour {

	public float moveSpeed = 5.0f;
	public bool moveLeft;
	public float maxDistance = 10.0f;
	public float range = 0.3f;
	public int plus = 4;

	bool director = false;
	int i = 0;

	public Camera camera;

	void Start () {
		
	}
	

	void Update () {

		RaycastHit hit;
		float distance = 10.0f;

		Vector3 forward = -transform.TransformDirection (Vector3.forward) * 10;
		Debug.DrawRay (transform.position, forward, Color.green);

		if (Physics.Raycast (transform.position, (forward), out hit)) {
			distance = hit.distance;
			//Debug.Log (distance + " " + hit.collider.gameObject.name);
		}

		if (moveLeft && distance < range && hit.collider.gameObject.tag == "wall") {
			director = true;
		}

		if (director == false) {

			if (moveLeft && distance > range) {
				transform.Translate (new Vector3 (0, GetComponent<Rigidbody> ().velocity.y, -moveSpeed));
			} else if (!moveLeft && distance > range) {
				transform.Translate (new Vector3 (0, GetComponent<Rigidbody> ().velocity.y, moveSpeed));
			}
		
		} else if (director) {
			transform.Rotate(new Vector3(0,plus,0));
			i+=plus;
			if(i==180){
				i = 0;
				director = false;
			}
		}


		if (hit.collider != null) {
			if (hit.collider.gameObject.name == "ghost" && distance < maxDistance) {
				//Debug.Log ("Game Over!");
				camera.GetComponent<Postprocess>().flash();
				StartCoroutine (DelayMenu ());
			}
		}
	}

	IEnumerator DelayMenu(){
		yield return new WaitForSeconds (1.0f / camera.GetComponent<Postprocess> ().timeScale);
		Application.LoadLevel ("menu");
	}
}
