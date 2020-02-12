using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;


public class OrbsDrift : MonoBehaviour
{
    public bool test;
    public bool start;

    public bool spawn;

    public bool stuck;

    public bool inside;
    public bool vacuum;

    public bool endOrb;
    public bool orbCluster;

    public GameObject targetObject;

    public Transform target;
    public float speed;
    public float spawnSpeed;

    public float timer;
    public float directionSwitch;
    public int direction;
    public int driftDirection;

    public float pulsateTimer;
    public bool bright;
    public float brightenTime;
    public float dimTime;

    public bool endCollected;

    public Color currentColor;
    Color emissionColor;
    Color dimColor;
    Color brightColor;

    Color albedoColorStart;
    Color colorStart;
    Color colorEnd;
    public float duration;

    public float scaleSpeed;
    public Vector3 currentScale;
    public Vector3 endScale;

    private IVRInputDevice _primaryController;

    public GameObject audio;

    void Start()
    {
        if (!endOrb)
        {
            targetObject = GameObject.FindGameObjectWithTag("Head");
            target = targetObject.transform;
        }
        else
        {
            targetObject = GameObject.FindGameObjectWithTag("EarthRing");
            target = targetObject.transform;
        }

        emissionColor = GetComponent<Renderer>().material.GetColor("_EmissionColor");
    }


    void Update()
    {
        timer += Time.deltaTime;
        pulsateTimer += Time.deltaTime;

        dimColor = currentColor * -4;
        brightColor = currentColor * 4;

        GetComponent<Renderer>().material.SetColor("_EmissionColor", emissionColor);

        float cLerp = Mathf.PingPong(Time.deltaTime, duration);
        float lerp = Mathf.PingPong(Time.deltaTime, duration) / duration;

        


        if (GetComponent<Renderer>().material.color == Color.yellow)
            start = false;

        if (start)
        {
            colorEnd = brightColor;

            albedoColorStart = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, Color.yellow, cLerp);

            emissionColor = Color.Lerp(colorStart, brightColor, lerp);
        }
        else if (GameObject.FindGameObjectWithTag("OrbSpawnAnchor").GetComponent<OrbTally>().ending == true)
        {
            GetComponent<Renderer>().material.color = Color.Lerp(GetComponent<Renderer>().material.color, Color.clear, cLerp);
            emissionColor = Color.Lerp(colorStart, dimColor, lerp);

            float sLerp = Mathf.PingPong(Time.deltaTime, scaleSpeed) / scaleSpeed;

            currentScale = transform.localScale;
            transform.localScale = Vector3.Lerp(currentScale, new Vector3(0, 0, 0), sLerp);
        }
        else
        {
            if (!stuck)
            {
                if (brightenTime < pulsateTimer && bright)
                {
                    bright = false;
                    pulsateTimer = 0;
                }

                else if (dimTime < pulsateTimer && !bright)
                {
                    bright = true;
                    pulsateTimer = 0;
                }
            }
            else
                bright = true;

            if (bright)
            {
                colorEnd = brightColor;
            }
            else
            {
                colorEnd = dimColor;
            }

            emissionColor = Color.Lerp(colorStart, colorEnd, lerp);
        }

        colorStart = emissionColor;


        //Renderer renderer = GetComponent<Renderer>();
        //Material mat = renderer.material;

        //float emission = Mathf.PingPong(Time.time * 0.25f, 1.5f);
        //Color baseColor = Color.yellow; //Replace this with whatever you want for your base color at emission level '1'

        //Color finalColor = baseColor * Mathf.LinearToGammaSpace(emission);

        //mat.SetColor("_EmissionColor", finalColor);


        if (!test)
        {
            if (!inside)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
            else
            {
                Vector3 dir = transform.position - target.position;
                transform.Translate(dir * (speed / 4) * Time.deltaTime);
            }
        }

        else if (stuck)
        {
            float sLerp = Mathf.PingPong(Time.deltaTime, scaleSpeed) / scaleSpeed;

            currentScale = transform.localScale;
            transform.localScale = Vector3.Lerp(currentScale, endScale, sLerp);
        }

        else if (vacuum &&
            (Input.GetKey(KeyCode.Mouse0) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.One))
            && GameObject.FindGameObjectWithTag("OrbSpawnAnchor").GetComponent<OrbTally>().ending == false)
        {
            if (_primaryController == null)
            {
                _primaryController = VRDevice.Device.PrimaryInputDevice;
                return;
            }

            targetObject = GameObject.FindGameObjectWithTag("Vacuum");
            target = targetObject.transform;

            float step = spawnSpeed * Time.deltaTime;

            transform.LookAt(target);
            transform.Translate(Vector3.forward * step);
        }

        else if (spawn)
        {
            float step = spawnSpeed * Time.deltaTime;

            transform.LookAt(target);
            transform.Translate(Vector3.forward * step);
        }

        else if (endOrb)
        {
            float step = spawnSpeed * Time.deltaTime;

            if (transform.position.y < 0)
                transform.Translate(Vector3.up * step);

            transform.LookAt(target);
            transform.Translate(Vector3.forward * step);
        }

        else if (orbCluster)
        {

        }

        else
        {
            targetObject = GameObject.FindGameObjectWithTag("Head");
            target = targetObject.transform;

            transform.LookAt(target);

            float step = speed * Time.deltaTime;

            if (!inside)
                transform.Translate(Vector3.forward * step);
            else
                transform.Translate(Vector3.back * step);

            if (timer > directionSwitch)
            {
                timer = 0;

                driftDirection = direction;

                direction = Random.Range(0, 7);
            }

            // Move Direction //
            {
                if (direction == 0)
                    transform.Translate(Vector3.up * step);

                if (direction == 1)
                {
                    transform.Translate(Vector3.up * step);
                    transform.Translate(Vector3.right * step);
                }

                if (direction == 2)
                    transform.Translate(Vector3.right * step);

                if (direction == 3)
                {
                    transform.Translate(Vector3.right * step);
                    transform.Translate(Vector3.down * step);
                }

                if (direction == 4)
                    transform.Translate(Vector3.down * step);

                if (direction == 5)
                {
                    transform.Translate(Vector3.down * step);
                    transform.Translate(Vector3.left * step);
                }

                if (direction == 6)
                    transform.Translate(Vector3.left * step);

                if (direction == 7)
                {
                    transform.Translate(Vector3.left * step);
                    transform.Translate(Vector3.up * step);
                }
            }

            // Drift Direction //
            {
                float driftStep = (speed / 2) * Time.deltaTime;

                if (driftDirection == 0)
                    transform.Translate(Vector3.up * driftStep);

                if (driftDirection == 1)
                {
                    transform.Translate(Vector3.up * driftStep);
                    transform.Translate(Vector3.right * driftStep);
                }

                if (driftDirection == 2)
                    transform.Translate(Vector3.right * driftStep);

                if (driftDirection == 3)
                {
                    transform.Translate(Vector3.right * driftStep);
                    transform.Translate(Vector3.down * driftStep);
                }

                if (driftDirection == 4)
                    transform.Translate(Vector3.down * driftStep);

                if (driftDirection == 5)
                {
                    transform.Translate(Vector3.down * driftStep);
                    transform.Translate(Vector3.left * driftStep);
                }

                if (driftDirection == 6)
                    transform.Translate(Vector3.left * driftStep);

                if (driftDirection == 7)
                {
                    transform.Translate(Vector3.left * driftStep);
                    transform.Translate(Vector3.up * driftStep);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name);

        if (other.name == "EGOOrbInnerRadius")
        {
            inside = true;
            spawn = false;
        }

        if (other.name == "EGOOrbDeadZoneTop")
        {
            if (direction == 1 || direction == 2 || direction == 7)
            {
                timer = 0;
                direction = Random.Range(0, 7);
            }
        }

        if (other.name == "EGOOrbDeadZoneBottom")
        {
            if (direction == 3 || direction == 4 || direction == 5)
            {
                timer = 0;
                direction = Random.Range(0, 7);
            }
        }

        if (other.name == "VacuumSuction")
        {
            vacuum = true;
        }

        if (other.name == "OrbsOrbit")
        {
            transform.parent = other.transform;
            stuck = true;
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.name == "VacuumSuction")
    //        vacuum = true;
    //    else
    //        vacuum = false;
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "EGOOrbOuterRadius")
            inside = false;

        if (other.name == "VacuumSuction")
            vacuum = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "VacuumSuction")
        {
            ++GetComponentInParent<OrbTally>().tally;

            Instantiate(audio, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}