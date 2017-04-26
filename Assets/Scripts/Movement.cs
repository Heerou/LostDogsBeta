using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

//Raycast
	RaycastHit hit;
	Ray ray;

//Position where i'm going to click	
	Vector3 movePosition;
	public float speed = 1f;

	//Initial position
	Vector3 initialPosition;
	//The position where i want to go
	Vector3 targetDirection;
	float angle;
	Vector3 playerRotation;
	Coroutine coroutine;

	void Update () {
		ControlMovement();
	}

/* Colliders */
	void OnTriggerEnter (Collider collider) {
		//Collision with the rock
		if (collider.gameObject.name == "Piedra") {
			//StopAllCoroutines ();
			StopCoroutine (coroutine);
		}
		//If it touchs the water returns to the original position
		if (collider.gameObject.name == "Water") {
			transform.position = new Vector3 ();
			Debug.Log ("El jugador se mojo");
		}
		//If it touchs the VictoryPoint beats the level
		if (collider.gameObject.name == "VictoryPoint") {
			Debug.Log ("Ganaste");
		}
	}
	
	void ControlMovement() {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);						
		//Where the player will go
		if(Input.GetMouseButtonDown(0)) {
			if(Physics.Raycast(ray, out hit)) {
				movePosition =  new Vector3(hit.transform.position.x , 0.5f, hit.transform.position.z);
				targetDirection = movePosition - transform.position;
				angle = Vector3.Angle(targetDirection, transform.forward);
				playerRotation =  transform.eulerAngles;
				playerRotation.y = angle;
				transform.eulerAngles = playerRotation;
				coroutine = StartCoroutine(AwesomeMovement());
			}
		}
	}

	IEnumerator AwesomeMovement() {
		float timeCounter = 0;
		initialPosition = transform.position;
		while (timeCounter < 1) {
			transform.position = Vector3.Lerp(initialPosition, movePosition, timeCounter * speed);
			timeCounter += Time.deltaTime;
			yield return null;
		}
		transform.position = movePosition;
	}
}