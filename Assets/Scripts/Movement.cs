using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public bool isCollider = false;
	Vector3 movePosition;
	public float speed = 10f;
	public Transform player;
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit, Mathf.Infinity)) {
			if(Input.GetMouseButton(0)) {
				movePosition =  new Vector3(hit.point.x, 0.5f, hit.point.z);
				transform.position = movePosition;
				Debug.Log("Mi movimiento es: " + movePosition);
			}
		}
	}
}
