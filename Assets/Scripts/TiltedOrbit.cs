using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltedOrbit : MonoBehaviour
{

    public GameObject orbit;
    float randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(-0.5f, 0.5f);

        transform.Rotate(new Vector3(randomNumber, transform.rotation.y, transform.rotation.z));
        orbit.transform.Rotate(new Vector3(-randomNumber, orbit.transform.rotation.y, orbit.transform.rotation.z));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
