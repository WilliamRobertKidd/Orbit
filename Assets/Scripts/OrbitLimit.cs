using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OrbitLimit : MonoBehaviour
{
    public int orbitingObjectsLength;

    public GameObject[] celestials;
    public Transform[] orbitingObjects;
    public Vector3[] orbitingObjectRotations;

    public GameObject orbit;

    public bool timerLock;
    public float timer;
    public float rotationTime;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerLock)
            timer += Time.deltaTime;

        orbitingObjects = orbit.transform.Cast<Transform>().Where(c => c.gameObject.tag == "Celestial").ToArray();

        orbitingObjectRotations[0] = orbitingObjects[0].rotation.eulerAngles;
        orbitingObjectsLength = orbitingObjects.Length;

        if (orbitingObjectsLength > 1)
            orbitingObjectRotations[1] = orbitingObjects[1].rotation.eulerAngles;

        if (orbitingObjectsLength > 2)
            orbitingObjectRotations[2] = orbitingObjects[2].rotation.eulerAngles;

        if (orbitingObjectsLength > 3)
            orbitingObjectRotations[3] = orbitingObjects[3].rotation.eulerAngles;


        // orbitingObjects[0] = orbit.transform.Find("EarthPosition EGO Variant").gameObject;

        //orbitingObjects = GameObject.FindGameObjectsWithTag("Celestial");

        //var arrayOfChildren = orbit.transform.Cast<GameObject>().Where(c => c.gameObject.tag == "Celestial").ToArray();

        //int i;

        //    {
        //        for (i = 0; i < orbitingObjects.Length; i++)
        //        {
        //            orbitingObjects[i] = child.gameObject;
        //        }
        //    }

        if (rotationTime < timer)
        {
            if (orbitingObjectsLength == 2)
            {
                orbitingObjectRotations[1] = orbitingObjects[1].rotation.eulerAngles;
                orbitingObjects[1].rotation = Quaternion.Euler(0, Random.Range(orbitingObjects[0].rotation.y + 30, orbitingObjects[0].rotation.y + 330), 0);

                Debug.Log("2");

                timerLock = true;
                timer = 0;
            }
            else if (orbitingObjectsLength == 3)
            {
                orbitingObjectRotations[2] = orbitingObjects[2].rotation.eulerAngles;
                orbitingObjects[2].rotation = Quaternion.Euler(0, Random.Range(orbitingObjects[0].rotation.y + 60, orbitingObjects[0].rotation.y + 300), 0);

                Debug.Log("3");

                timerLock = true;
                timer = 0;
            }
            else if (orbitingObjectsLength == 4)
            {
                orbitingObjectRotations[3] = orbitingObjects[3].rotation.eulerAngles;
                orbitingObjects[3].rotation = Quaternion.Euler(0, Random.Range(orbitingObjects[0].rotation.y + 90, orbitingObjects[0].rotation.y + 270), 0);

                Debug.Log("4");

                timerLock = true;
                timer = 0;
            }
        }
    }

    public void newOrbitingObject()
    {
        orbitingObjectsLength += 1;
        newOrbitingRotation();
    }

    public void newOrbitingRotation()
    {
        timer = 0;
        timerLock = false;
    }
}
