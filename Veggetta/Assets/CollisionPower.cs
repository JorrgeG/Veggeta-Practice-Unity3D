using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPower : MonoBehaviour {
    public GameObject EfectExplo;
   
    public float longZ;
    CapsuleCollider capsuCollider;

    public Power_Spawn powerSpawn;
   
    // Use this for initialization
    void Start() {
        
        longZ = Mathf.Clamp(longZ, 0, 40);
        capsuCollider = GetComponent<CapsuleCollider>();
        capsuCollider.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.F) && Power_Spawn.powerActive == true)
        {
            StartCoroutine(Power());

        }*/


        if (Power_Spawn.num >= 39)
        {
            capsuCollider.enabled = false;
            transform.localPosition = Vector3.zero;
        }
        else
        {
            capsuCollider.enabled = true;

            transform.localPosition = new Vector3(0, 0, Power_Spawn.num);
        }
       
    }

    void OnTriggerEnter(Collider c)
    {
        Debug.LogError(c.tag);
        Debug.LogError(c.name);
        if (c.tag == "Earth")
        {
            StartCoroutine(powerSpawn.EndPower(1.25f));
            Debug.LogError("wwww");
            GameObject Explo = Instantiate(EfectExplo, transform.position, EfectExplo.transform.rotation) as GameObject;
            Destroy(Explo, 1.5f);
        }

    }
    /*
    IEnumerator Power()
    {
        Debug.LogError("sirve");        
        yield return new WaitForSeconds(2f);
        capsuCollider.enabled = true;

        for (int i = 0; i < 37; i++)
        {

            longZ =  3 + i;

            yield return new WaitForSeconds(0.02f);
            //transform.Translate(0, 0, longZ / 30);
            transform.localPosition = new Vector3(0, 0, longZ);


        }
        yield return new WaitForSeconds(2f);
    }*/
}
