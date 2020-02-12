using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Liminal.SDK.Core;
using Liminal.Core.Fader;

public class SceneEnd : MonoBehaviour
{
    public float timer;
    public float sessionEnd;

    public float fadeTimer;

    public bool fading;
    public bool flip;

    // Start is called before the first frame update
    void Start()
    {
        fading = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > sessionEnd && fading == false)
        {
            sceneEnding();
            // fadeToBlack();
        }

        if (fading == true)
        {
            fadeTimer += Time.deltaTime;

            if (flip == false)
            {
                GetComponent<CompoundScreenFader>().FadeToBlack(GetComponentInParent<ExperienceApp>().FadeOutSettings.Duration);
                flip = true;
            }


            if (fadeTimer >= GetComponentInParent<ExperienceApp>().FadeOutSettings.Duration)
            {
                ExperienceApp.End();
                Application.Quit();
            }
        }
    }

    void sceneEnding()
    {
        GetComponentInChildren<OrbTally>().endingSequence();
    }

    public void fadeToBlack()
    {
        fading = true;
        GetComponent<CompoundScreenFader>().FadeToBlack(GetComponentInParent<ExperienceApp>().FadeOutSettings.Duration);
        Debug.Log("Fading to Black");

        GetComponent<MusicFadeIn>().fading = true;
    }
}
