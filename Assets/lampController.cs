using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lampController : MonoBehaviour {

	public Material outRange;
	public Material inRange;

	public GameObject active;

	public GameObject bam;

	Renderer rend;

	bool inTrigger = false;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "ghost") {
			inTrigger = true;
			rend.sharedMaterial = inRange;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.name == "ghost") {
			inTrigger = false;
			rend.sharedMaterial = outRange;
		}
	}

	void Start(){
		rend = GetComponent<Renderer> ();
		rend.enabled = true;
	}

	void Update(){

	}

	void OnTriggerStay(Collider col){
		
		if (Input.GetKeyDown ("space") && col.gameObject.name == "ghost") {
			//Debug.Log ("bum");

			Quaternion quaternionBum = Quaternion.identity;
			quaternionBum.eulerAngles = new Vector3 (0, 0, 0);
			Vector3 positionBum = transform.position+(new Vector3(0,0.5f,-2.5f));

			Instantiate (bam, positionBum, quaternionBum);

			Quaternion quaternion = Quaternion.identity;
			quaternion.eulerAngles = new Vector3 (0, 180, 0);
			Vector3 position = transform.position+(new Vector3(0,0.3f,0));

			Instantiate (active, position, quaternion);

			Destroy (gameObject);
		}

	}
}
