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

    public float timer;
    public float spawnSpeed;
    public bool ending;
    public bool empty;
    public bool locked;

    public Transform orbSpawn;
    public Transform primaryHand;
    public Transform anchor;

    public bool endingLock;
    public GameObject endingOrb;

    public GameObject[] celestials;

    public GameObject planetPrefab;
    public GameObject moonPrefab;

    public GameObject sceneEndObject;
    public GameObject orbPositioner;

    public bool ring1;
    public bool ring2;
    public bool ring3;
    public bool ring4;

    public int orbTotal;


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

        if (Input.GetKeyDown(KeyCode.P))
        {
            newPlanet();
        }

        if (ending)
        {
            timer += Time.deltaTime;

            if (!endingLock)
            {
                orbPositioner.GetComponent<OrbPositioner>().orbsCollecting = true;
                endingLock = true;
            }

            if (empty == true && locked == true)
            {
                sceneEndObject.GetComponent<SceneEnd>().fadeToBlack();
                locked = false;
            }

            if (spawnSpeed < timer && empty == false)
            {

                if (totalTally >= 16 && empty == false && locked == false)
                {
                    locked = true;
                }
                else if (totalTally < 16 && empty == false && locked == false)
                {
                    empty = true;
                    locked = true;
                }
                else if (totalTally >= 1 && orbTotal <= 16)
                {
                    if (orbTotal == 16)
                    {
                        orbTotal = 0;

                        if (ring1 == false)
                            ring1 = true;
                        else if (ring2 == false)
                            ring2 = true;
                        else if (ring3 == false)
                            ring3 = true;
                        else if (ring4 == false)
                            ring4 = true;
                    }

                    if (ring1 == false)
                    {
                        orbSpawn.GetComponent<ExitOrbSpawn>().spawn();
                        orbTotal += 1;
                    }
                    else if (ring2 == false)
                    {
                        orbSpawn.GetComponent<ExitOrbSpawn>().spawn();
                        orbTotal += 1;
                    }
                    else if (ring3 == false)
                    {
                        orbSpawn.GetComponent<ExitOrbSpawn>().spawn();
                        orbTotal += 1;
                    }
                    else if (ring4 == false)
                    {
                        orbSpawn.GetComponent<ExitOrbSpawn>().spawn();
                        orbTotal += 1;
                    }
                    else if (ring4 == true)
                    {
                        orbPositioner.GetComponent<OrbPositioner>().orbsCollecting = false;
                    }
                    else
                    {
                        orbPositioner.GetComponent<OrbPositioner>().orbsCollecting = false;

                        Debug.Log("OrbsCollectingFALSE");
                    }

                    totalTally -= 1;
                }
                //else if (tally > 0)
                //{
                //    tally -= 2;
                //}
                else
                {
                    orbPositioner.GetComponent<OrbPositioner>().orbsCollecting = false;

                    Debug.Log("OrbsCollectingFALSE");
                }   

                timer = 0;
            }
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

        if (celestials[celestial].layer == 10 && celestials[celestial].GetComponent<OrbitLimit>().orbitingObjectsLength < 4)
        {
            Debug.Log("NEW PLANET");

            Instantiate(planetPrefab, celestials[celestial].GetComponent<ModelReference>().orbit.transform.position,
                    celestials[celestial].GetComponent<ModelReference>().orbit.transform.rotation, 
                    celestials[celestial].GetComponent<ModelReference>().orbit.transform);

            celestials[celestial].GetComponent<OrbitLimit>().newOrbitingObject();
        }
        else if (celestials[celestial].layer == 10 && celestials[celestial].GetComponent<OrbitLimit>().orbitingObjectsLength == 4)
        {
            Debug.Log("CAN'T CREATE NEW PLANET, RECALCULATING");

            amendment();
        }
        else
            newPlanet();
    }

    void newMoon()
    {
        celestial = Random.Range(0, celestials.Length);

        if (celestials[celestial].layer == 9 && celestials[celestial].GetComponent<OrbitLimit>().orbitingObjectsLength < 2)
        {
            Debug.Log("NEWMOON");

            Instantiate(moonPrefab, celestials[celestial].GetComponent<ModelReference>().orbit.transform.position,
                    celestials[celestial].GetComponent<ModelReference>().orbit.transform.rotation, 
                    celestials[celestial].GetComponent<ModelReference>().orbit.transform);

            celestials[celestial].GetComponent<OrbitLimit>().newOrbitingObject();
        }
        else if (celestials[celestial].layer == 9 && celestials[celestial].GetComponent<OrbitLimit>().orbitingObjectsLength == 2)
        {
            Debug.Log("CAN'T CREATE NEW MOON, RECALCULATING");

            amendment();
        }
        else
            newMoon();
    }

    public void endingSequence()
    {
        ending = true;
    }
}