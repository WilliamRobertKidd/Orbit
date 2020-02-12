using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitOrbSpawn : MonoBehaviour
{
    public GameObject endingOrb;
    public Transform anchor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void spawn()
    {
        Instantiate(endingOrb, transform);
    }
}
