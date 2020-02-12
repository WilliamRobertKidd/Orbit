using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTilt : MonoBehaviour
{
    public Vector3[] rotations;
    public GameObject[] objects;
    public bool twoObjects;

    // Start is called before the first frame update
    void Start()
    {
        int i;
        i = Random.Range(0, 3);

        objects[0].transform.rotation = Quaternion.Euler(rotations[i]);

        if (twoObjects)
        objects[1].transform.rotation = Quaternion.Euler(rotations[i]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
