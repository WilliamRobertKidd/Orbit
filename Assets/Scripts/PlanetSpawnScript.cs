using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawnScript : MonoBehaviour
{
    public float positionSpeed;
    public float scaleSpeed;

    public Vector3 currentPosition;
    public Vector3[] endPosition;

    public Vector3 currentScale;
    public Vector3 endScale;

    public bool noLength;

    int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float pLerp = Mathf.PingPong(Time.deltaTime, positionSpeed) / positionSpeed;
        float sLerp = Mathf.PingPong(Time.deltaTime, scaleSpeed) / scaleSpeed;

        currentPosition = gameObject.transform.localPosition;

        if (!noLength)
        {
            if (i < endPosition.Length)
                gameObject.transform.localPosition = Vector3.MoveTowards(currentPosition, endPosition[i], pLerp);
            else
                gameObject.transform.localPosition = Vector3.Lerp(currentPosition, endPosition[i], pLerp);
        }
        
        currentScale = gameObject.transform.localScale;
        gameObject.transform.localScale = Vector3.Lerp(currentScale, endScale, sLerp);

        if (currentPosition.y == endPosition[i].y && !noLength)
            i += 1;
    }
}
    