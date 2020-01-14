using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class OrbsDrift : MonoBehaviour
{
    public bool test;
    public bool spawn;

    public bool inside;
    public bool vacuum;

    public GameObject targetObject;

    public Transform target;
    public float speed;
    public float spawnSpeed;

    public float timer;
    public float directionSwitch;
    public int direction;
    public int driftDirection;

    void Start()
    {
        targetObject = GameObject.FindGameObjectWithTag("Head");
        target = targetObject.transform;

    }

    void Update()
    {
        timer += Time.deltaTime;

        if (!test)
        {
            if (!inside)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
            else
            {
                Vector3 dir = transform.position - target.position;
                transform.Translate(dir * (speed / 4) * Time.deltaTime);
            }
        }

        else if (vacuum)
        {
            targetObject = GameObject.FindGameObjectWithTag("Vacuum");
            target = targetObject.transform;

            float step = spawnSpeed * Time.deltaTime;

            transform.LookAt(target);
            transform.Translate(Vector3.forward * step);
        }

        else if (spawn)
        {
            float step = spawnSpeed * Time.deltaTime;

            transform.LookAt(target);
            transform.Translate(Vector3.forward * step);
        }

        else
        {
            targetObject = GameObject.FindGameObjectWithTag("Head");
            target = targetObject.transform;

            transform.LookAt(target);

            float step = speed * Time.deltaTime;

            if (!inside)
                transform.Translate(Vector3.forward * step);
            else
                transform.Translate(Vector3.back * step);

            if (timer > directionSwitch)
            {
                timer = 0;

                driftDirection = direction;

                direction = Random.Range(0, 7);
            }

            // Move Direction //
            {
                if (direction == 0)
                    transform.Translate(Vector3.up * step);

                if (direction == 1)
                {
                    transform.Translate(Vector3.up * step);
                    transform.Translate(Vector3.right * step);
                }

                if (direction == 2)
                    transform.Translate(Vector3.right * step);

                if (direction == 3)
                {
                    transform.Translate(Vector3.right * step);
                    transform.Translate(Vector3.down * step);
                }

                if (direction == 4)
                    transform.Translate(Vector3.down * step);

                if (direction == 5)
                {
                    transform.Translate(Vector3.down * step);
                    transform.Translate(Vector3.left * step);
                }

                if (direction == 6)
                    transform.Translate(Vector3.left * step);

                if (direction == 7)
                {
                    transform.Translate(Vector3.left * step);
                    transform.Translate(Vector3.up * step);
                }
            }

            // Drift Direction //
            {
                float driftStep = (speed/2) * Time.deltaTime;

                if (driftDirection == 0)
                    transform.Translate(Vector3.up * driftStep);

                if (driftDirection == 1)
                {
                    transform.Translate(Vector3.up * driftStep);
                    transform.Translate(Vector3.right * driftStep);
                }

                if (driftDirection == 2)
                    transform.Translate(Vector3.right * driftStep);

                if (driftDirection == 3)
                {
                    transform.Translate(Vector3.right * driftStep);
                    transform.Translate(Vector3.down * driftStep);
                }

                if (driftDirection == 4)
                    transform.Translate(Vector3.down * driftStep);

                if (driftDirection == 5)
                {
                    transform.Translate(Vector3.down * driftStep);
                    transform.Translate(Vector3.left * driftStep);
                }

                if (driftDirection == 6)
                    transform.Translate(Vector3.left * driftStep);

                if (driftDirection == 7)
                {
                    transform.Translate(Vector3.left * driftStep);
                    transform.Translate(Vector3.up * driftStep);
                }
            }
        } 
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.name);

        if (other.name == "EGOOrbInnerRadius")
        {
            inside = true;
            spawn = false;
        }

        if (other.name == "EGOOrbDeadZoneTop")
        {
            if (direction == 1 || direction == 2 || direction == 7)
            {
                timer = 0;
                direction = Random.Range(0, 7);
            }
        }

        if (other.name == "EGOOrbDeadZoneBottom")
        {
            if (direction == 3 || direction == 4 || direction == 5)
            {
                timer = 0;
                direction = Random.Range(0, 7);
            }
        }

        if (other.name == "VacuumSuction")
            vacuum = true;
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.name == "VacuumSuction")
    //        vacuum = true;
    //    else
    //        vacuum = false;
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "EGOOrbOuterRadius")
            inside = false;

        if (other.name == "VacuumSuction")
            vacuum = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "VacuumSuction")
        {
            ++GetComponentInParent<OrbTally>().tally;
            Destroy(gameObject);
        }
    }
}