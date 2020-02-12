using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{
    public GameObject ring;
    public GameObject[] ringList;
    public Vector3[] ringRotations;

    public float rotationSpeed;
    public float ringSpeed;

    public bool startingPositions;
    public bool nextStage;

    public GameObject sceneEndObject;
    public GameObject orbTally;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ringRotations[0] = new Vector3(ringRotations[0].x, ringRotations[0].y, ringRotations[0].z += 1);
        //ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y, ringRotations[1].z += 1);
        //ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y, ringRotations[2].z += 1);
        //ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[3].y, ringRotations[3].z += 1);


        float rLerp = Mathf.PingPong(Time.deltaTime, rotationSpeed) / rotationSpeed;

        /* Constant Rotating */

        if (ringRotations[0].z > 359.9)
        {
            ringRotations[0] = new Vector3(ringRotations[0].x, ringRotations[0].y, 0);
            ringList[0].transform.localEulerAngles = ringRotations[0];
        }

        if (ringRotations[1].z > 359.9)
        {
            ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y, 0);
            ringList[1].transform.localEulerAngles = ringRotations[1];
        }

        if (ringRotations[2].z > 359.9)
        {
            ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y, 0);
            ringList[2].transform.localEulerAngles = ringRotations[2];
        }

        if (ringRotations[3].z > 359.9)
        {
            ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[3].y, 0);
            ringList[3].transform.localEulerAngles = ringRotations[3];
        }

            ringRotations[0] = new Vector3(ringRotations[0].x, ringRotations[0].y, ringRotations[0].z += ringSpeed);

        if (ringList.Length > 1)
            ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y, ringRotations[1].z += ringSpeed);

        if (ringList.Length > 2)
            ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y, ringRotations[2].z += ringSpeed);

        if (ringList.Length > 3)
            ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[3].y, ringRotations[3].z += ringSpeed);

        ringList = GameObject.FindGameObjectsWithTag("Ring");


        // ringList[0].transform.localEulerAngles = Vector3.Lerp(ringList[0].transform.localEulerAngles, ringRotations[0], rLerp);
        // ringList[1].transform.localEulerAngles = Vector3.Lerp(ringList[1].transform.localEulerAngles, ringRotations[1], rLerp);


        /* Starting Positions */

        if (startingPositions)
        {
            ringList[0].transform.localEulerAngles = ringRotations[0];

            if (ringList.Length > 1)
                ringList[1].transform.localEulerAngles = ringRotations[1];

            if (ringList.Length > 2)
                ringList[2].transform.localEulerAngles = ringRotations[2];

            if (ringList.Length > 3)
                ringList[3].transform.localEulerAngles = ringRotations[3];
        }
        else
        {
            ringList[0].transform.localEulerAngles = ringRotations[0];

            if (ringList.Length > 1)
            ringList[1].transform.localEulerAngles = ringRotations[1];

            if (ringList.Length > 2)
                ringList[2].transform.localEulerAngles = ringRotations[2];

            if (ringList.Length > 3)
                ringList[3].transform.localEulerAngles = ringRotations[3];

            if (ringRotations[0].x < 0.1 
                && ringRotations[1].x < ringRotations[0].x 
                && ringRotations[2].x < ringRotations[0].x 
                && ringRotations[3].x < ringRotations[0].x && nextStage == true)
            {
                nextStage = false;
                sceneEndObject.GetComponent<SceneEnd>().fadeToBlack();
            }
            
            else if (ringRotations[0].y > 89.9 && ringRotations[1].y > 89.9 && ringRotations[2].y > 89.9 && ringRotations[3].y > 89.9 && nextStage == true)
            {
                Debug.Log("STAGE 4");

                if (ringRotations[0].x < 0.1)
                {
                    ringRotations[0] = new Vector3(ringRotations[0].x -= (ringSpeed / 2), ringRotations[0].y, ringRotations[0].z);
                    ringList[0].transform.localEulerAngles = ringRotations[0];

                    Debug.Log("RING1DONE");
                }
                else
                    ringRotations[0] = new Vector3(ringRotations[0].x -= ringSpeed, ringRotations[0].y, ringRotations[0].z);

                if (ringList.Length == 1)
                {
                        if (ringRotations[1].x < ringRotations[0].x)
                            ringRotations[1] = new Vector3(ringRotations[1].x -= (ringSpeed / 2), ringRotations[1].y, ringRotations[1].z);
                        else
                            ringRotations[1] = new Vector3(ringRotations[1].x -= ringSpeed, ringRotations[1].y, ringRotations[1].z);

                        if (ringRotations[2].x < ringRotations[0].x)
                            ringRotations[2] = new Vector3(ringRotations[2].x -= (ringSpeed / 2), ringRotations[2].y, ringRotations[2].z);
                        else
                            ringRotations[2] = new Vector3(ringRotations[2].x -= ringSpeed, ringRotations[2].y, ringRotations[2].z);

                        if (ringRotations[3].x < ringRotations[0].x)
                            ringRotations[3] = new Vector3(ringRotations[3].x -= (ringSpeed / 2), ringRotations[3].y, ringRotations[3].z);
                        else
                            ringRotations[3] = new Vector3(ringRotations[3].x -= ringSpeed, ringRotations[0].y, ringRotations[3].z);
                }

                    if (ringList.Length > 1)
                {
                    if (ringRotations[1].x < ringRotations[0].x)
                    {
                        ringRotations[1] = new Vector3(ringRotations[1].x -= (ringSpeed / 2), ringRotations[1].y, ringRotations[1].z);
                        ringList[1].transform.localEulerAngles = ringRotations[1];

                        Debug.Log("RING2DONE");
                    }
                    else
                        ringRotations[1] = new Vector3(ringRotations[1].x -= ringSpeed, ringRotations[1].y, ringRotations[1].z);
                }

                if (ringList.Length > 2)
                {
                    if (ringRotations[2].x < ringRotations[0].x)
                    {
                        ringRotations[2] = new Vector3(ringRotations[2].x -= (ringSpeed / 2), ringRotations[2].y, ringRotations[2].z);
                        ringList[2].transform.localEulerAngles = ringRotations[2];

                        Debug.Log("RING3DONE");
                    }
                    else
                        ringRotations[2] = new Vector3(ringRotations[2].x -= ringSpeed, ringRotations[2].y, ringRotations[2].z);
                }

                if (ringList.Length > 3)
                {
                    if (ringRotations[3].x < ringRotations[0].x)
                    {
                        ringRotations[3] = new Vector3(ringRotations[3].x -= (ringSpeed / 2), ringRotations[3].y, ringRotations[3].z);
                        ringList[3].transform.localEulerAngles = ringRotations[3];

                        Debug.Log("RING4DONE");
                    }
                    else
                        ringRotations[3] = new Vector3(ringRotations[3].x -= ringSpeed, ringRotations[0].y, ringRotations[3].z);
                }
            }

            else if (ringRotations[0].x > 50 && ringRotations[1].x > 70 && ringRotations[2].x > 90 && ringRotations[3].x > 110)
            {
                Debug.Log("STAGE 3");

                nextStage = true;

                if (ringRotations[0].y > 89.9)
                {
                    ringRotations[0] = new Vector3(ringRotations[0].x, ringRotations[0].y, ringRotations[0].z);
                    ringList[0].transform.localEulerAngles = ringRotations[0];

                    Debug.Log("RING1DONE");
                }
                else
                    ringRotations[0] = new Vector3(ringRotations[0].x, ringRotations[0].y += ringSpeed, ringRotations[0].z);

                if (ringList.Length == 1)
                {
                        if (ringRotations[1].y > 89.9)
                            ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y, ringRotations[1].z);
                        else
                            ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y += ringSpeed, ringRotations[1].z);

                        if (ringRotations[2].y > 89.9)
                            ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y, ringRotations[2].z);
                        else
                            ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y += ringSpeed, ringRotations[2].z);

                        if (ringRotations[3].y > 89.9)
                            ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[3].y, ringRotations[3].z);
                        else
                            ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[0].y += ringSpeed, ringRotations[3].z);
                }

                    if (ringList.Length > 1)
                {
                    if (ringRotations[1].y > 89.9)
                    {
                        ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y, ringRotations[1].z);
                        ringList[1].transform.localEulerAngles = ringRotations[1];

                        Debug.Log("RING2DONE");
                    }
                    else
                        ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y += ringSpeed, ringRotations[1].z);
                }

                if (ringList.Length > 2)
                {
                    if (ringRotations[2].y > 89.9)
                    {
                        ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y, ringRotations[2].z);
                        ringList[2].transform.localEulerAngles = ringRotations[2];

                        Debug.Log("RING3DONE");
                    }
                    else
                        ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y += ringSpeed, ringRotations[2].z);
                }

                if (ringList.Length > 3)
                {
                    if (ringRotations[3].y > 89.9)
                    {
                        ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[3].y, ringRotations[3].z);
                        ringList[3].transform.localEulerAngles = ringRotations[3];

                        Debug.Log("RING4DONE");
                    }
                    else
                        ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[0].y += ringSpeed, ringRotations[3].z);
                }
            }
            else if (ringRotations[0].x > 50 && ringRotations[1].x > 70 && ringRotations[2].x > 90 && ringRotations[3].x > 110)
            {
                Debug.Log("STAGE 3");

                if (ringRotations[0].y > 89.9)
                {
                    ringRotations[0] = new Vector3(ringRotations[0].x, ringRotations[0].y, ringRotations[0].z);
                    ringList[0].transform.localEulerAngles = ringRotations[0];

                    Debug.Log("RING1DONE");
                }
                else
                    ringRotations[0] = new Vector3(ringRotations[0].x, ringRotations[0].y += ringSpeed, ringRotations[0].z);

                if (ringList.Length == 1)
                {
                        if (ringRotations[1].y > 89.9)
                            ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y, ringRotations[1].z);
                        else
                            ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y += ringSpeed, ringRotations[1].z);

                        if (ringRotations[2].y > 89.9)
                            ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y, ringRotations[2].z);
                        else
                            ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y += ringSpeed, ringRotations[2].z);

                        if (ringRotations[3].y > 89.9)
                            ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[3].y, ringRotations[3].z);
                        else
                            ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[0].y += ringSpeed, ringRotations[3].z);
                }


                    if (ringList.Length > 1)
                {
                    if (ringRotations[1].y > 89.9)
                    {
                        ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y, ringRotations[1].z);
                        ringList[1].transform.localEulerAngles = ringRotations[1];

                        Debug.Log("RING2DONE");
                    }
                    else
                        ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y += ringSpeed, ringRotations[1].z);
                }

                if (ringList.Length > 2)
                {
                    if (ringRotations[2].y > 89.9)
                    {
                        ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y, ringRotations[2].z);
                        ringList[2].transform.localEulerAngles = ringRotations[2];

                        Debug.Log("RING3DONE");
                    }
                    else
                        ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y += ringSpeed, ringRotations[2].z);
                }

                if (ringList.Length > 3)
                {
                    if (ringRotations[3].y > 89.9)
                    {
                        ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[3].y, ringRotations[3].z);
                        ringList[3].transform.localEulerAngles = ringRotations[3];

                        Debug.Log("RING4DONE");
                    }
                    else
                        ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[0].y += ringSpeed, ringRotations[3].z);
                }
            }
            else if (ringRotations[0].y < 0.1 && ringRotations[1].y < 0.1 && ringRotations[2].y < 0.1 && ringRotations[3].y < 0.1)
            {
                Debug.Log("STAGE 2");

                if (ringRotations[0].x > 50)
                {
                    ringRotations[0] = new Vector3(ringRotations[0].x, ringRotations[0].y, ringRotations[0].z);
                    ringList[0].transform.localEulerAngles = ringRotations[0];
                }
                else
                    ringRotations[0] = new Vector3(ringRotations[0].x += ringSpeed, ringRotations[0].y, ringRotations[0].z);


                if (ringList.Length == 1)
                {
                        if (ringRotations[1].x > 70)
                            ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y, ringRotations[1].z);
                        else
                            ringRotations[1] = new Vector3(ringRotations[1].x += ringSpeed, ringRotations[1].y, ringRotations[1].z);

                        if (ringRotations[2].x > 90)
                            ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y, ringRotations[2].z);
                        else
                            ringRotations[2] = new Vector3(ringRotations[2].x += ringSpeed, ringRotations[2].y, ringRotations[2].z);

                        if (ringRotations[3].x > 110)
                            ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[3].y, ringRotations[3].z);
                        else
                            ringRotations[3] = new Vector3(ringRotations[3].x += ringSpeed, ringRotations[3].y, ringRotations[3].z);
                }


                if (ringList.Length > 1)
                {
                    if (ringRotations[1].x > 70)
                    {
                        ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y, ringRotations[1].z);
                        ringList[1].transform.localEulerAngles = ringRotations[1];
                    }
                    else
                        ringRotations[1] = new Vector3(ringRotations[1].x += ringSpeed, ringRotations[1].y, ringRotations[1].z);
                }

                if (ringList.Length > 2)
                {
                    if (ringRotations[2].x > 90)
                    {
                        ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y, ringRotations[2].z);
                        ringList[2].transform.localEulerAngles = ringRotations[2];
                    }
                    else
                        ringRotations[2] = new Vector3(ringRotations[2].x += ringSpeed, ringRotations[2].y, ringRotations[2].z);
                }

                if (ringList.Length > 3)
                {
                    if (ringRotations[3].x > 110)
                    {
                        ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[3].y, ringRotations[3].z);
                        ringList[3].transform.localEulerAngles = ringRotations[3];
                    }
                    else
                        ringRotations[3] = new Vector3(ringRotations[3].x += ringSpeed, ringRotations[3].y, ringRotations[3].z);
                }
            }
            else
            {
                Debug.Log("STAGE 1");

                if (ringRotations[0].y < 0.1)
                {
                    ringRotations[0] = new Vector3(ringRotations[0].x, ringRotations[0].y, ringRotations[0].z);
                    ringList[0].transform.localEulerAngles = ringRotations[0];
                }
                else
                    ringRotations[0] = new Vector3(ringRotations[0].x, ringRotations[0].y -= ringSpeed, ringRotations[0].z);

                if (ringList.Length == 1)
                {
                        if (ringRotations[1].y < 0.1)
                            ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y, ringRotations[1].z);
                        else
                            ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y -= ringSpeed, ringRotations[1].z);

                        if (ringRotations[2].y < 0.1)
                            ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y, ringRotations[2].z);
                        else
                            ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y -= ringSpeed, ringRotations[2].z);

                        if (ringRotations[3].y < 0.1)
                            ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[3].y, ringRotations[3].z);
                        else
                            ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[0].y -= ringSpeed, ringRotations[3].z);
                }


                    if (ringList.Length > 1)
                {
                    if (ringRotations[1].y < 0.1)
                    {
                        ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y, ringRotations[1].z);
                        ringList[1].transform.localEulerAngles = ringRotations[1];
                    }
                    else
                        ringRotations[1] = new Vector3(ringRotations[1].x, ringRotations[1].y -= ringSpeed, ringRotations[1].z);
                }

                if (ringList.Length > 2)
                {
                    if (ringRotations[2].y < 0.1)
                    {
                        ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y, ringRotations[2].z);
                        ringList[2].transform.localEulerAngles = ringRotations[2];
                    }
                    else
                        ringRotations[2] = new Vector3(ringRotations[2].x, ringRotations[2].y -= ringSpeed, ringRotations[2].z);
                }

                if (ringList.Length > 3)
                {
                    if (ringRotations[3].y < 0.1)
                    {
                        ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[3].y, ringRotations[3].z);
                        ringList[3].transform.localEulerAngles = ringRotations[3];
                    }
                    else
                        ringRotations[3] = new Vector3(ringRotations[3].x, ringRotations[0].y -= ringSpeed, ringRotations[3].z);
                }
            }
        }
        

        if (Input.GetKey(KeyCode.L))
        {
            NewRing();
        }
    }

    public void NewRing()
    {
        if (ringList.Length < 4)
        {
            Instantiate(ring, transform.position, ring.transform.rotation, transform);
            Debug.Log("NEWRING");
        }
        else
        {
            startingPositions = false;
            Debug.Log("Starting Positions OFF");
        }

        if (orbTally.GetComponent<OrbTally>().totalTally < 20)
        {
            startingPositions = false;
            Debug.Log("Starting Positions OFF");
        }
    }
}
