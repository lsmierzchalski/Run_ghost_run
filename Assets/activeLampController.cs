using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activeLampController : MonoBehaviour {

	public GameObject bam;

	AudioSource scream;

	void Start(){
		scream = GetComponent<AudioSource>();

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "enemy") {

			Quaternion quaternionBum = Quaternion.identity;
			quaternionBum.eulerAngles = new Vector3 (0, 0, 0);
			Vector3 positionBum = transform.position+(new Vector3(0,0.5f,-2.5f));

			scream.Play();

			Instantiate (bam, positionBum, quaternionBum);

			Destroy (col.gameObject);
			Destroy (gameObject, 0.9f);
		}
	}
}
