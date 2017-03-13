using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveOnMouseClick : MonoBehaviour {
    //Declares the navMesh
    private NavMeshAgent myNavAgent;
    private object other;

    void Start() {
        myNavAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        //If i press left Click
        if (Input.GetMouseButtonDown(0)) {
            //Ray and rayscast of the camera
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) {
                myNavAgent.destination = hitInfo.point;
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "PiedraCollider") {
            Debug.Log("PiedraCollider");          
        }
    }
}
