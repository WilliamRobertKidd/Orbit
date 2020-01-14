using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRotation : MonoBehaviour
{
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + rotationSpeed, transform.rotation.eulerAngles.z));
        transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));
    }
}
