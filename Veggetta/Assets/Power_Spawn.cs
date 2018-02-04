using UnityEngine;
using System.Collections;

public class Power_Spawn : MonoBehaviour
{

    LineRenderer lineRender;
    public static float num = 0;
   
    Vector3[] ver = new Vector3[1];
    public Move scritpMove;
    public GameObject LightParticles_POWER;
    public ParticleSystem PowerParticles;
    public Animation animChatarcter;

    public static bool powerActive;
    
    
    void Start()
    {
        lineRender = GetComponent<LineRenderer>();
        lineRender.enabled = false;
        LightParticles_POWER.SetActive(false);
        

    }
    void FixedUpdate()
    {
        num = Mathf.Clamp(num, 0, 40);

    }
    
    void Update()
    {

        AnimationCurve curve = new AnimationCurve();
        

            curve.AddKey(0.0f, 0.5f);
            curve.AddKey(1.0f, 1.0f);
       

        lineRender.widthCurve = curve;
        lineRender.widthMultiplier = 1.5f;




        if (Input.GetKeyDown(KeyCode.F) && Controller_Live_Ki.ki >= 0.4f)
        {
            powerActive = true;
            Controller_Live_Ki.ki -= 0.4f;
            LightParticles_POWER.SetActive(true);
            lineRender.enabled = true;
            scritpMove.enabled = false;
            StartCoroutine(Power());
            
        }
        if (num == 40)
        {
            StartCoroutine(EndPower(.25f));
        }
    }

    public IEnumerator EndPower(float delay)
    {
        powerActive = false;

        yield return new WaitForSeconds(delay);
        PowerParticles.startSize = 1f;
        PowerParticles.startLifetime = 0.1f;
        PowerParticles.startSpeed = 5.0f;
        var emicion = PowerParticles.emission;
        emicion.rateOverTime = 30f;

        LightParticles_POWER.SetActive(false);
        lineRender.enabled = false;
        scritpMove.enabled = true;
        num = 0;
        ver[0] = new Vector3(0, 0, 0);
        lineRender.SetPositions(ver);
    }

    IEnumerator Power()
    {
        animChatarcter.CrossFade("Power1");
        yield return new WaitForSeconds(2f);
        animChatarcter.CrossFade("Power2");
        PowerParticles.startSize = 2.5f;
        PowerParticles.startLifetime = 0.3f;
        PowerParticles.startSpeed = 6.0f;
        var emicion = PowerParticles.emission;
        emicion.rateOverTime = 50f;

        for (int i = 0; i < 41; i++)
        {
            if (powerActive)
            {
                num = 3 + i;
                ver[0] = new Vector3(0, 0, num);
                yield return new WaitForSeconds(0.02f);

                lineRender.SetPositions(ver);
            }         
        }
        yield return new WaitForSeconds(2f);
    }

   
}
