using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRotation : MonoBehaviour
{
    public float rotationSpeed;
    public bool startingMoon;
    public bool avatar;

    public bool firstOrbiting;

    // Start is called before the first frame update
    void Start()
    {
        //transform.rotation.SetEulerAngles(0,Random.Range(0,360),0);

        if (startingMoon)
            transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));

        if (avatar)
            transform.Rotate(new Vector3(0, Random.Range(-30, -180), 0));


        //Quaternion.Euler(0,Random.Range(0,360),0);
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + rotationSpeed, transform.rotation.eulerAngles.z));


        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));

        //if (transform.localEulerAngles.y > 360)
        //    transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
