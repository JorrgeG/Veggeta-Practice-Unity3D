using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_KI : MonoBehaviour {

    // Use this for initialization
    public GameObject Ki;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.R))
        {
            Controller_Live_Ki.ki += 0.002f;
           GameObject kiExter = (GameObject)Instantiate(Ki, transform.position , Ki.transform.rotation);
            Destroy(kiExter, 1f);
            kiExter.transform.parent = transform;
        }

        }
}
