using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    CharacterController character;
    Vector3 moveDireccion;
    public float speed;
    public float jumpForce;
    public float gracity = 9.8f;
    float h,v;
    public float rotateSpeed;
    Animation anim;
    public float rangRaycast;

    public LayerMask mask;
    public float radiosRaycast;
    RaycastHit hit, hit2;
     
     float num = 0;
    public GameObject Ki;

    GameObject kiExter;



    // Use this for initialization
    void Awake()
    {
        rangRaycast = Mathf.Clamp(rangRaycast, 0, 40);

    }
    void Start () {
        character = GetComponent<CharacterController>();
        anim = GetComponent<Animation>();


    }
    void FixedUpdate()
    {
              
    }


    // Update is called once per frame
    void Update () {

        
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Physics.Raycast(transform.position, -transform.up, out hit, (radiosRaycast + 5f) + rangRaycast, mask);

        if (character.isGrounded || hit.collider)
            {
            Debug.LogError("camina");
            speed = 7.0f;
                moveDireccion = new Vector3(0, 0, v);
                moveDireccion = transform.TransformDirection(moveDireccion);
                moveDireccion *= speed;

               
                if (Input.GetKey(KeyCode.LeftShift) && character.isGrounded)
                {
                
                    moveDireccion *= 4;
                }
           

            transform.Rotate(0, h * rotateSpeed * Time.deltaTime, 0);


        }
        
                // SUBE CON LA LETRA TAB, MANTIENE SU POSICION Y LA GRAVEDAD ES 0
            if (Input.GetKey(KeyCode.T) )
            {
            rangRaycast += 0.8f;
            Physics.Raycast(new Vector3(transform.position.x + 0.1f, transform.position.y + 0.1f, transform.position.z), -transform.up, out hit2, (radiosRaycast -0.5f) + rangRaycast, mask);

            moveDireccion.y = 10f;

            if (hit2.collider == null   )
            {
                gracity = 0f;
                moveDireccion = new Vector3(0, 0, 0);

            }
        }

        

        // BAJA CON LA LETRA G
        if (Input.GetKey(KeyCode.G))
        {
            rangRaycast -= 0.7f;
            moveDireccion.y -= 6f;

        }
        if (Input.GetKey(KeyCode.R))
        {
            //kiExter = (GameObject)Instantiate(Ki, transform.position, Ki.transform.rotation);
            //Destroy(kiExter,1.5f);
            moveDireccion = new Vector3(0, 0, 0);


        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            num = 0;
            
        }
        if (character.isGrounded)
        {
            rangRaycast = 0.0f;
            gracity = 89.0f;
        }
        Animationn();


        moveDireccion.y -= gracity * Time.deltaTime;
        character.Move(moveDireccion * Time.deltaTime);

    }
    void Animationn()
    {
        
        if (v>0)
        {
            anim.CrossFade("Run");
                   }
        else
        {
            anim.CrossFade("Idle");
          //  num = 0;

        }
        if (Input.GetKey(KeyCode.LeftShift) && v>0)
        {
            anim.CrossFade("Flay");

        }
        if (Input.GetKey(KeyCode.T) )
        {
            anim.CrossFade("FlayUp");

        }
        else if (Input.GetKey(KeyCode.G) && !character.isGrounded )
        {
            anim.CrossFade("FlayDown");

        }
        else if (v > 0 && gracity == 0 && hit.collider)
        {
            moveDireccion *= 3.0f;
            anim.CrossFade("Flay");
        }
       else if (Input.GetKey(KeyCode.R) )
        {
          
            num += Time.deltaTime;
            anim.CrossFade("Ki1");
            if (num >= 0.6f)
            {
                anim.CrossFade("Ki2");
            }
           
            
        }
        
        else if (gracity == 0 && !character.isGrounded)
        {
            //num = 0;
            anim.CrossFade("IdleAir");
        }
        

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, -transform.up * ((radiosRaycast + 5f) + rangRaycast)  );

        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Vector3(transform.position.x + 0.1f,transform.position.y + 0.1f, transform.position.z) , -transform.up * ((radiosRaycast - 0.5f) + rangRaycast));
    }
}
