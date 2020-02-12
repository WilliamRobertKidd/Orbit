using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFadeIn : MonoBehaviour
{
    public float musicVolume;
    public float maxVolume;

    public bool fading;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (musicVolume < maxVolume && !fading)
            musicVolume += 0.00005f;
        else if (musicVolume > 0 && fading)
        {
            musicVolume -= 0.007f;
        }

        GetComponent<AudioSource>().volume = musicVolume;
    }
}
