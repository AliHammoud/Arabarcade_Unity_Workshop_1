using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLights : MonoBehaviour {

	void Update () {

		Cotroller x = transform.GetComponentInParent<Cotroller>();



		if (!x.isGrounded){

			GetComponent<Renderer>().material.color =  new Color(0.3f, 0.6f, 0.7f);

		} else {

			GetComponent<Renderer>().material.color =  new Color(0.4f,1f,0.95f);

		}

	}
}
