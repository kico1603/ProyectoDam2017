using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 5);
	}
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "enemy") {
            Destroy(other.gameObject);

        }
    }
    // Update is called once per frame

}
