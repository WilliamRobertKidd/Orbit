using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarPositioner : MonoBehaviour
{
    public GameObject avatar;

    public float positionSpeed;

    public bool ending;
    public Vector3 endingPosition;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ending = avatar.GetComponentInChildren<OrbTally>().ending;


        avatar.transform.position = gameObject.transform.position;

        if (ending)
        {
            float pLerp = Mathf.PingPong(Time.deltaTime, positionSpeed) / positionSpeed;
            gameObject.transform.localPosition = Vector3.Lerp(gameObject.transform.localPosition, endingPosition, pLerp);
        }


    }
}
