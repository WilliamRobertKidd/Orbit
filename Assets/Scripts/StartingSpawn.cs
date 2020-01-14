using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingSpawn : MonoBehaviour
{
    public bool earth;

    public GameObject moonPrefab;
    public GameObject playerPositionPrefab;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(moonPrefab, gameObject.transform);
        Instantiate(playerPositionPrefab, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
