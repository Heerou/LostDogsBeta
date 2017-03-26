using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

//Raycast
	RaycastHit hit;
	Ray ray;

//Position where i'm going to click	
	Vector3 movePosition;
	public float speed = 10f;

	Vector3 initialPosition;
	
	Vector3 targetDirection;
	float angle;
	Vector3 playerRotation;
	Coroutine coroutine = null;
	
	

	void Update () {
		ControlMovement();
	}
	void OnTriggerEnter (Collider collider) {
		if(collider.gameObject.name == "Piedra") {			
			StopCoroutine(coroutine);
		}
	}

	void ControlMovement() {
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);						
		//Where the player will go
		if(Input.GetMouseButton(0)) {
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
			transform.position = Vector3.Lerp(initialPosition, movePosition, timeCounter);
			timeCounter += Time.deltaTime;
			yield return null;
		}
		transform.position = movePosition;
	}
}