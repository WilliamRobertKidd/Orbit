using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;

public class VacuumEffect : MonoBehaviour
{
    //private IVRInputDevice _primaryController;

    public GameObject VacuumParticles;
    public GameObject trigger;

    public Vector3[] triggerRotations;
    public Vector3 triggerRotation;

    public float rotationSpeed;

    public bool shooting;

    public GameObject orbTally;
    public bool ending;

    public bool playing;

    public float currentVolume;
    public float maxVolume;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ending = orbTally.GetComponent<OrbTally>().ending;
        GetComponentInChildren<AudioSource>().volume = currentVolume;

        if (!ending)
        {
            //if (_primaryController == null)
            //{
            //    _primaryController = VRDevice.Device.PrimaryInputDevice;
            //    return;
            //}    ​

            float lerp = Mathf.PingPong(Time.deltaTime, rotationSpeed) / rotationSpeed;
            trigger.transform.localEulerAngles = Vector3.Lerp(trigger.transform.localEulerAngles, triggerRotation, lerp);


            if (Input.GetKey(KeyCode.Mouse0) || OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                // VacuumParticles.SetActive(true);

                triggerRotation = triggerRotations[1];

                if (playing == false)
                {
                    //GetComponentInChildren<AudioSource>().Play();

                    playing = true;
                }

                if (playing == true)
                {
                }

                if (currentVolume < maxVolume)
                {
                    currentVolume += 0.001f;
                }
            }
            else
            {
                // VacuumParticles.SetActive(false);

                triggerRotation = triggerRotations[0];


                if (currentVolume > 0)
                    currentVolume -= 0.002f;
                else
                    Debug.Log("");
                    //GetComponentInChildren<AudioSource>().Pause();

                playing = false;
            }


        }
        else
        {
            float lerp = Mathf.PingPong(Time.deltaTime, rotationSpeed) / rotationSpeed;
            trigger.transform.localEulerAngles = Vector3.Lerp(trigger.transform.localEulerAngles, triggerRotation, lerp);

            triggerRotation = triggerRotations[1];

            if (currentVolume > 0)
                currentVolume -= 0.002f;
        }
    }
}
