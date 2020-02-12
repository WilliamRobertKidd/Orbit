using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VacuumParticles : MonoBehaviour
{
    public Vector3[] circlePositions;
    public Vector3[] circleScales;
    public Color[] vacuumColors;
    public GameObject[] circles;


    // Start is called before the first frame update
    void Start()
    {
        int i;
        for (i = 0; i < circlePositions.Length; i++)
        {
            circlePositions[i] = circles[i].transform.localPosition;
            circleScales[i] = circles[i].transform.localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
