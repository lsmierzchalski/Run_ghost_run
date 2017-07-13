using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostController : MonoBehaviour {

	public float moveSpeed = 5.0f;

	public int rotationSpeed = 12;
	int direction = 2;//1 - left 2 - right
	bool changeDirection = false;
	int i = 0;

	float changeLayerSpeed = 0.1f;
	public int layer = 1;//1 - top 2 - bottom
	bool changeLayer = false;
	int j = 0;

	private BoxCollider boxcol;

	private GameObject[] enemy;

	void Start () {
		boxcol = gameObject.GetComponent<BoxCollider> ();
	}

	void FixedUpdate () {

		if (changeDirection == false) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				if (direction == 2) {
					//Debug.Log ("prawej w lewo");
					changeDirection = true;
					boxcol.size = new Vector3 (0.1f,0.22f,0.11f);
				}
				direction = 1;
			}
			else if (Input.GetKey (KeyCode.RightArrow)) {
				if (direction == 1) {
					//Debug.Log ("z lewej w prawo");
					changeDirection = true;
					boxcol.size = new Vector3 (0.1f,0.22f,0.11f);
				}
				direction = 2;
			}
			var x = Input.GetAxis ("Horizontal") * Time.deltaTime * moveSpeed;
			if (x < 0)
				x = -x;
			transform.Translate (0, 0, x);
		}
		else if(changeDirection == true){
			i+=rotationSpeed;
			transform.Rotate(0,rotationSpeed,0);
			if (i == 180) {
				changeDirection = false;
				i = 0;
				boxcol.size = new Vector3 (0.43f,0.22f,0.11f);
			}
			//Debug.Log (i);
		}

		if (changeLayer == false) {
			if (Input.GetKey (KeyCode.UpArrow)) {
				if (layer == 2) {
					changeLayer = true;
				}
				layer = 1;
			}
			else if (Input.GetKey (KeyCode.DownArrow)) {
				if (layer == 1) {
					changeLayer = true;
				}
				layer = 2;
			}
		} else if (changeLayer == true) {
			if (layer == 2) {
				j+=1;
				transform.Translate(0,-changeLayerSpeed,0);
				if (j == 40) {
					changeLayer = false;
					j = 0;
				}
			} else if (layer == 1) {
				j+=1;
				transform.Translate(0,changeLayerSpeed,0);
				if (j == 40) {
					changeLayer = false;
					j = 0;
				}
			}
		}

		if (leaveEnemy() == 0) {
			StartCoroutine (DelayMenu ());
		}

	}

	int leaveEnemy(){
		enemy = GameObject.FindGameObjectsWithTag ("enemy");
		return enemy.Length;
	}

	IEnumerator DelayMenu(){
		yield return new WaitForSeconds (1.0f / GetComponent<Camera>().GetComponent<Postprocess> ().timeScale);
		Application.LoadLevel ("menu");
	}
}
