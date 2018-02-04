using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Controller_Live_Ki : MonoBehaviour {

    public Image textureLive;
    public Image textureKi;
    public static float ki = 1;
    public float health = 1;

    // Use this for initialization
    void FixedUpdate()
    {
        ki = Mathf.Clamp(ki, 0, 1);
        health = Mathf.Clamp(health, 0, 1);

    }

    void Start () {

       // ki = 1;
        //health = 1;
	}
	
	// Update is called once per frame
	void Update () {
        textureKi.fillAmount = ki;
        health = ki;
	}
}
