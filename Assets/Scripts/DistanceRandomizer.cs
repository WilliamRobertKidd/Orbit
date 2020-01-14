using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceRandomizer : MonoBehaviour
{
    public bool planet;

    public int randomPositionNumber;
    public float[] planetPositions;
    public float[] moonPositions;

    // Start is called before the first frame update
    void Start()
    {
        randomPositionNumber = Random.Range(0, 5);

        if (!planet)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, moonPositions[randomPositionNumber]);
        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, planetPositions[randomPositionNumber]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
