using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Postprocess : MonoBehaviour {

	public float intensity;
	private Material material;
	private float time = 1;
	public AnimationCurve flashCurve;
	public float timeScale = 1;

	public Texture tex;

	void Update(){
		time += Time.deltaTime;

		if (Input.GetKeyDown (KeyCode.Space)) {
			//flash ();
		}
	}

	public void flash(){
		time = 0;
	}

	// Create a privete material used to the effect
	void Awake(){
		material = new Material (Shader.Find ("Hidden/Postprocess"));
	}

	//Postprocess the image
	void OnRenderImage(RenderTexture source, RenderTexture destination){
		material.SetTexture ("_Tex", tex);
		material.SetFloat ("_Flash", flashCurve.Evaluate (time * timeScale));
		material.SetFloat ("_Intensity", intensity);
		Graphics.Blit (source, destination, material);
	}

}
