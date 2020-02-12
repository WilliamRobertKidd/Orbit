using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    Color colorStart;
    Color colorEnd;

    Color cloudColorStart;
    Color cloudColorEnd;

    float duration = 3.0f;

    public Color[] randomColour;
    public GameObject orbitEgo;
    public GameObject cloudSphere;

    public bool planet;
    public bool startingPlanet;
    public Material[] terraPlanets;
    public Material[] clouds;


    void Start()
    {
        colorStart = GetComponent<Renderer>().material.color;

        if (planet)
        {
            cloudColorStart = cloudSphere.GetComponent<Renderer>().material.color;
        }

        colorEnd = colorStart;
        if (planet)
            cloudColorEnd = cloudColorStart;

        if (!startingPlanet)
        {
            int random = Random.Range(0, randomColour.Length);

            colorEnd = randomColour[random];
            if (planet)
            {
                cloudColorEnd = randomColour[random];
                cloudSphere.GetComponent<Renderer>().material.color = colorEnd;
                cloudSphere.GetComponent<Renderer>().material = clouds[Random.Range(0, clouds.Length)];
                gameObject.GetComponent<Renderer>().material = terraPlanets[Random.Range(0, terraPlanets.Length)];
            }

            gameObject.GetComponent<Renderer>().material.color = colorEnd;
        }

    }

    void Update()
    {
        float lerp = Mathf.PingPong(Time.deltaTime, duration) / duration;

        colorStart = GetComponent<Renderer>().material.color;
        gameObject.GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);

        if (planet)
        {
            cloudColorStart = GetComponent<Renderer>().material.color;
            cloudSphere.GetComponent<Renderer>().material.color = Color.Lerp(cloudColorStart, cloudColorEnd, lerp);
        }
    }

    public void colourChange()
    {
        int random = Random.Range(0, randomColour.Length);
        int random2 = Random.Range(0, randomColour.Length);

        if (colorEnd != randomColour[random])
        {
            colorEnd = randomColour[random];

            if (planet)
                cloudColorEnd = randomColour[random2];
        }
        else
            colourChange();

        
    }
}
