using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbPositioner : MonoBehaviour
{
    public Transform[] orbPositions1;
    public GameObject[] orbObjects1;
    public bool orbs1;
    public Transform[] orbPositions2;
    public GameObject[] orbObjects2;
    public bool orbs2;
    public Transform[] orbPositions3;
    public GameObject[] orbObjects3;
    public bool orbs3;
    public Transform[] orbPositions4;
    public GameObject[] orbObjects4;
    public bool orbs4;

    public bool orbsCollecting;

    public int orbsCollected;
    public GameObject endingOrb;


    // Start is called before the first frame update
    void Start()
    {
        orbs1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (orbsCollecting)
        {
            GetComponent<RingsV2>().startingPositions = true;

            endingOrb = GameObject.FindGameObjectWithTag("EndingOrb");

            if (orbs1 == true)
            {
                if (endingOrb.GetComponent<OrbsEndDrift>().endCollected == false)
                {
                    orbObjects1[orbsCollected] = endingOrb;

                    orbObjects1[orbsCollected].GetComponent<OrbsEndDrift>().targetObject = orbPositions1[orbsCollected].gameObject;

                    endingOrb.tag = "Orb";

                    orbsCollected++;
                    endingOrb.GetComponent<OrbsEndDrift>().endCollected = true;
                }

                if (orbsCollected == 16)
                {
                    orbs1 = false;
                    orbs2 = true;

                    orbsCollected = 0;
                }
            }
            else if (orbs2 == true)
            {
                if (endingOrb.GetComponent<OrbsEndDrift>().endCollected == false)
                {
                    orbObjects2[orbsCollected] = endingOrb;

                    orbObjects2[orbsCollected].GetComponent<OrbsEndDrift>().targetObject = orbPositions2[orbsCollected].gameObject;

                    endingOrb.tag = "Orb";

                    orbsCollected++;
                    endingOrb.GetComponent<OrbsEndDrift>().endCollected = true;
                }

                if (orbsCollected == 16)
                {
                    orbs2 = false;
                    orbs3 = true;

                    orbsCollected = 0;
                }
            }
            else if (orbs3 == true)
            {
                if (endingOrb.GetComponent<OrbsEndDrift>().endCollected == false)
                {
                    orbObjects3[orbsCollected] = endingOrb;

                    orbObjects3[orbsCollected].GetComponent<OrbsEndDrift>().targetObject = orbPositions3[orbsCollected].gameObject;

                    endingOrb.tag = "Orb";

                    orbsCollected++;
                    endingOrb.GetComponent<OrbsEndDrift>().endCollected = true;
                }

                if (orbsCollected == 16)
                {
                    orbs3 = false;
                    orbs4 = true;

                    orbsCollected = 0;
                }
            }
            else if (orbs4 == true)
            {
                if (endingOrb.GetComponent<OrbsEndDrift>().endCollected == false)
                {
                    orbObjects4[orbsCollected] = endingOrb;

                    orbObjects4[orbsCollected].GetComponent<OrbsEndDrift>().targetObject = orbPositions4[orbsCollected].gameObject;

                    endingOrb.tag = "Orb";

                    orbsCollected++;
                    endingOrb.GetComponent<OrbsEndDrift>().endCollected = true;
                }

                if (orbsCollected == 16)
                {
                    orbs4 = false;
                    orbsCollecting = false;

                    orbsCollected = 0;
                }
            }
        }
        else
        {
            GetComponent<RingsV2>().startingPositions = false;
        }
    }
}
