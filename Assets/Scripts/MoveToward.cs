using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    public GameObject targetObject;
    public Transform target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("EarthModel");
        target = targetObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        transform.LookAt(target);
        transform.Translate(Vector3.forward * step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == targetObject)
        {
            targetObject.GetComponent<Rings>().NewRing();
            Destroy(gameObject);
        }
    }
}