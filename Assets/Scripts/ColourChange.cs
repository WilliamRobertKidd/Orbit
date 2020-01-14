using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    Color colorStart;
    Color colorEnd;
    float duration = 3.0f;

    public Color[] randomColour;
    public GameObject orbitEgo;


    void Start()
    {
        colorStart = GetComponent<Renderer>().material.color;
        colorEnd = colorStart;

        int random = Random.Range(0, randomColour.Length);

        colorEnd = randomColour[random];
        gameObject.GetComponent<Renderer>().material.color = colorEnd;
    }

    void Update()
    {
        float lerp = Mathf.PingPong(Time.deltaTime, duration) / duration;

        colorStart = GetComponent<Renderer>().material.color;
        gameObject.GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);
    }

    public void colourChange()
    {
        int random = Random.Range(0, randomColour.Length);

        colorEnd = randomColour[random];
    }
}
