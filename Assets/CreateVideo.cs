using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateVideo : MonoBehaviour {

	public GameObject video;

	// Use this for initialization
	void Start () {
		Quaternion quaternion = Quaternion.identity;
		quaternion.eulerAngles = new Vector3 (0, 0, 0);
		Vector3 position = transform.position+(new Vector3(0,0f,13.5f));

		Instantiate (video, position, quaternion);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
