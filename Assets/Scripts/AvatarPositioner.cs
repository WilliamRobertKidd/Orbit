using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarPositioner : MonoBehaviour
{
    public GameObject avatar;

    // Start is called before the first frame update
    void Start()
    {
        avatar = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        avatar.transform.position = gameObject.transform.position;
    }
}
