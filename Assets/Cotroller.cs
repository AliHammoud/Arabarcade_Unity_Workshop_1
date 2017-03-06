using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cotroller : MonoBehaviour {

	public float characterSpeed = 5;
	public bool isGrounded = false;

	void Update () {

		MoveControllerC (KeyCode.LeftArrow, -1, -0, 0, characterSpeed);
		MoveControllerC (KeyCode.RightArrow, 1, -0, 0, characterSpeed);
		JumpController (980);

	}

	private void MoveControllerA (KeyCode key, float x, float y, float z) {

		if(Input.GetKeyDown(key)){

			transform.position += new Vector3 (x, y, z);

		}

	}

	private void MoveControllerB (KeyCode key, float x, float y, float z, float speed = 1) {

		if(Input.GetKey(key)){

			transform.Translate ( 
				new Vector3 ( 
					x * Time.deltaTime * speed, 
					y * Time.deltaTime * speed, 
					z * Time.deltaTime * speed
				) 
			);

		}

	}

	private void MoveControllerC (KeyCode key, float x, float y, float z, float speed = 1) {
		
		if(Input.GetKey(key)){

			try {

				Rigidbody _RBody = GetComponent<Rigidbody>();

				_RBody.AddForce(
					x * speed,
					y * speed,
					z * speed,
					ForceMode.Acceleration
				);

				_RBody.velocity = new Vector3(
					Mathf.Clamp(_RBody.velocity.x, -10, 10),
					_RBody.velocity.y,
					_RBody.velocity.z
				);

			} catch(Exception e) {

				Debug.LogWarning("No rigidbody attached to character!");

			}

		}

	}

	private void JumpController (float jumpPower) {

		if(Input.GetKeyDown(KeyCode.Space)) {

			try {
				
				Rigidbody _RBody = GetComponent<Rigidbody>();

				if ( isGrounded == true ) {
					
					_RBody.AddForce(
						0,
						jumpPower,
						0,
						ForceMode.Impulse
					);

					isGrounded = false;
				}


			} catch(Exception e) {

				Debug.LogWarning("No rigidbody attached to character!");

			}

		}

	}

	void OnCollisionEnter (Collision e) {

		switch (e.collider.tag) {

		case "Ground":
			isGrounded = true;
			break;
			

		}

	}

}