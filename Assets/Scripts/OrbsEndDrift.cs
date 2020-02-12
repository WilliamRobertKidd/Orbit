using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OrbsEndDrift : MonoBehaviour
{
    public bool start;

    public GameObject targetObject;

    public float speed;
    public float positionSpeed;
    public float scaleSpeed;
    public float scaleSpeed2;

    public float driftTimer;
    public float driftLimit;

    public float pulsateTimer;
    public bool bright;
    public float brightenTime;
    public float dimTime;

    public bool endCollected;
    public bool startDrift;

    public Color currentColor;
    public Color emissionColor;
    public Color dimColor;
    public Color brightColor;

    public Color colorStart;
    public Color colorEnd;
    public float duration;

    public Vector3 currentScale;
    public Vector3 endScale;

    void Start()
    {
        emissionColor = GetComponent<Renderer>().material.GetColor("_EmissionColor");

        dimColor = currentColor * -4;
        brightColor = currentColor * 4;
    }


    void Update()
    {
        pulsateTimer += Time.deltaTime;

        GetComponent<Renderer>().material.SetColor("_EmissionColor", emissionColor);

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

        if (bright)
        {
            colorEnd = brightColor;
        }
        else
        {
            colorEnd = dimColor;
        }

        float lerp = Mathf.PingPong(Time.deltaTime, duration) / duration;

        colorStart = emissionColor;
        emissionColor = Color.Lerp(colorStart, colorEnd, lerp);



        float pLerp = Mathf.PingPong(Time.deltaTime, positionSpeed) / positionSpeed;
        float sLerp = Mathf.PingPong(Time.deltaTime, scaleSpeed) / scaleSpeed;

        gameObject.transform.localScale = Vector3.Lerp(gameObject.transform.localScale, endScale, sLerp);


        if (startDrift)
        {
            driftTimer += Time.deltaTime;

            if (driftTimer > driftLimit)
                startDrift = false;

            transform.Translate(Vector3.forward * Time.deltaTime * speed);

            transform.SetParent(GameObject.FindGameObjectWithTag("OrbSpawnAnchor").transform);

        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, targetObject.transform.position, pLerp);

            scaleSpeed = scaleSpeed2;

            transform.SetParent(GameObject.FindGameObjectWithTag("OrbAnchor").transform);
        }
    }
}