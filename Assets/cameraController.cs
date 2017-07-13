using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	public GameObject target;
	// Use this for initialization
	void Start () {
		gameObject.transform.position = target.transform.position;
		gameObject.transform.Translate(new Vector3(0f, 3f, -10f));
	}

	// Update is called once per frame
	void Update () {
		
		gameObject.transform.position = new Vector3(target.transform.position.x,0f,0f);
		gameObject.transform.Translate(new Vector3(0f, 0f, -10f));
	}
}
