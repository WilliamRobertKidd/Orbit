using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbTally : MonoBehaviour
{
    public int totalTally;

    public int tally;
    public int amendmentCost;

    public int method;
    public int celestial;

    public GameObject[] celestials;

    public GameObject planetPrefab;
    public GameObject moonPrefab;


    Color colorStart;
    Color colorEnd = Color.green;
    float duration = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");

        if (tally >= amendmentCost)
        {
            totalTally += tally;
            tally = 0;

            amendment();
        }
    }

    void amendment()
    {
        method = Random.Range(0,4);

        if (method == 0 || method == 1)
            colourChange();

        if (method == 2)
            newPlanet();

        if (method == 3)
            newMoon();
    }

    void colourChange()
    {
        //float lerp = Mathf.PingPong(Time.time, duration) / duration;

        Debug.Log("COLOURCHANGE");

        celestial = Random.Range(0, celestials.Length);

        celestials[celestial].GetComponent<ModelReference>().model.GetComponent<ColourChange>().colourChange();

        //colorStart = celestials[celestial].GetComponent<Renderer>().material.color;
        //celestials[celestial].GetComponent<Renderer>().material.color = Color.Lerp(colorStart, colorEnd, lerp);
    }

    void newPlanet()
    {
        celestial = Random.Range(0, celestials.Length);

        if (celestials[celestial].layer == 10)
        {
            Debug.Log("NEWPLANET");

            Instantiate(planetPrefab, celestials[celestial].GetComponent<ModelReference>().orbit.transform.position,
                    celestials[celestial].GetComponent<ModelReference>().orbit.transform.rotation, 
                    celestials[celestial].GetComponent<ModelReference>().orbit.transform);
        }
        else
            newPlanet();
    }

    void newMoon()
    {
        celestial = Random.Range(0, celestials.Length);

        if (celestials[celestial].layer == 9)
        {
            Debug.Log("NEWMOON");

            Instantiate(moonPrefab, celestials[celestial].GetComponent<ModelReference>().orbit.transform.position,
                    celestials[celestial].GetComponent<ModelReference>().orbit.transform.rotation, 
                    celestials[celestial].GetComponent<ModelReference>().orbit.transform);
        }
        else
            newMoon();
    }


}
