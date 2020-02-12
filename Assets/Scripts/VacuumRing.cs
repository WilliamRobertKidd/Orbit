using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumRing : MonoBehaviour
{
    public Vector3[] circlePositions;
    public Vector3[] circleScales;
    public Color[] vacuumColors;

    public float positionSpeed;
    public float scaleSpeed;

    public GameObject orbTally;
    public bool ending;

    // Start is called before the first frame update
    void Start()
    {
        circlePositions = GetComponentInParent<VacuumParticles>().circlePositions;
        circleScales = GetComponentInParent<VacuumParticles>().circleScales;
        vacuumColors = GetComponentInParent<VacuumParticles>().vacuumColors;
    }

    // Update is called once per frame
    void Update()
    {
        ending = orbTally.GetComponent<OrbTally>().ending;

        if (!ending)
        {
            if (Input.GetKey(KeyCode.Mouse0) || OVRInput.Get(OVRInput.Button.One) || OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
            {
                ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
                settings.startLifetime = 1;

            }
            else
            {
                ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
                settings.startLifetime = 0.001f;

                settings.startColor = new ParticleSystem.MinMaxGradient(vacuumColors[6]);
            }
        }
        else
        {
            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startLifetime = 0.001f;

            settings.startColor = new ParticleSystem.MinMaxGradient(vacuumColors[6]);
        }

            float pLerp = Mathf.PingPong(Time.deltaTime, positionSpeed) / positionSpeed;
            float sLerp = Mathf.PingPong(Time.deltaTime, scaleSpeed) / scaleSpeed;

        // transform.localScale = Vector3.Lerp(transform.localScale, circleScales[0], sLerp);

        if (transform.localPosition == circlePositions[0])
        {
            transform.localPosition = circlePositions[9];
            transform.localScale = circleScales[9];

            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(vacuumColors[7]);
        }
        else if (transform.localPosition.z <= circlePositions[1].z + 0.1f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, circlePositions[0], pLerp);
            transform.localScale = Vector3.Lerp(transform.localScale, circleScales[0], sLerp);

            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(vacuumColors[6]);
        }
        else if (transform.localPosition.z <= circlePositions[2].z + 0.1f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, circlePositions[1], pLerp);
            transform.localScale = Vector3.Lerp(transform.localScale, circleScales[1], sLerp);

            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(vacuumColors[5]);
        }
        else if (transform.localPosition.z <= circlePositions[3].z + 0.1f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, circlePositions[2], pLerp);
            transform.localScale = Vector3.Lerp(transform.localScale, circleScales[2], sLerp);

            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(vacuumColors[4]);
        }
        else if (transform.localPosition.z <= circlePositions[4].z + 0.1f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, circlePositions[3], pLerp);
            transform.localScale = Vector3.Lerp(transform.localScale, circleScales[3], sLerp);

            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(vacuumColors[3]);
        }
        else if (transform.localPosition.z <= circlePositions[5].z + 0.1f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, circlePositions[4], pLerp);
            transform.localScale = Vector3.Lerp(transform.localScale, circleScales[4], sLerp);

            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(vacuumColors[2]);
        }
        else if (transform.localPosition.z <= circlePositions[6].z + 0.1f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, circlePositions[5], pLerp);
            transform.localScale = Vector3.Lerp(transform.localScale, circleScales[5], sLerp);

            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(vacuumColors[1]);
        }
        else if (transform.localPosition.z <= circlePositions[7].z + 0.1f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, circlePositions[6], pLerp);
            transform.localScale = Vector3.Lerp(transform.localScale, circleScales[6], sLerp);

            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(vacuumColors[0]);
        }
        else if (transform.localPosition.z <= circlePositions[9].z + 0.1f)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, circlePositions[7], pLerp);
            transform.localScale = Vector3.Lerp(transform.localScale, circleScales[7], sLerp);

            ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
            settings.startColor = new ParticleSystem.MinMaxGradient(vacuumColors[0]);
        }
    }
}
