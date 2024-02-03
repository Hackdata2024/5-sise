using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum stage
{
    Touch,
    Sound,
    Smell,
    Finish
}
public class ThreeTactic : MonoBehaviour
{
    public List<GameObject> TouchObjects = new List<GameObject>();
    public List<GameObject> SoundObjects = new List<GameObject>();
    public List<GameObject> SmellObjects = new List<GameObject>();

    public AudioSource intro;

    private stage currentStage;

    private DeepBreathing deepBreathing;

    private int touchObjectCount, soundObjectCount, smellObjectCount = 0;

    public AudioSource selectObject;
    public AudioSource barrelSound;
    public AudioSource bottleSound;
    public AudioSource skeletonSound;

    void Start()
    {
        currentStage = stage.Touch;
        intro.Play();
        Invoke("enableTouchObjects", 9);
        deepBreathing = GetComponent<DeepBreathing>();
    }

    void Update()
    {
        switch (currentStage)
        {
            case stage.Touch:
                //disable the lights if object stage is completed
                if (touchObjectCount >= 3)
                {
                    for (int i = 0; i < SoundObjects.Count; i++)
                    {
                        TouchObjects[i].transform.Find("Point Light").gameObject.SetActive(false);
                    }

                    currentStage = stage.Sound;
                }
                break;

            case stage.Sound:
                //enable the sound object lights
                for (int i = 0; i < SoundObjects.Count; i++)
                {
                    SoundObjects[i].transform.Find("Point Light").gameObject.SetActive(true);
                }
                //disable the lights if sound stage is completed
                if (soundObjectCount >= 3)
                {

                    for (int i = 0; i < SoundObjects.Count; i++)
                    {
                        SoundObjects[i].transform.Find("Point Light").gameObject.SetActive(false);
                    }

                    currentStage = stage.Smell;
                }
                break;

            case stage.Smell:
                //enable the smell objects lights
                for (int i = 0; i < SmellObjects.Count; i++)
                {
                    SmellObjects[i].transform.Find("Point Light").gameObject.SetActive(true);
                }
                //disable the lights if smell stage is completed
                if (smellObjectCount >= 3){

                    for (int i = 0; i < SmellObjects.Count; i++)
                    {
                        SmellObjects[i].transform.Find("Point Light").gameObject.SetActive(false);
                    }
                    currentStage = stage.Finish;
                }

                break;

            case stage.Finish:
                deepBreathing.enabled = true;
                this.enabled = false;
                //enable next strategy script
                //disable this script
                break;
        }
        
    }

    private void enableTouchObjects()
    {
        for (int i = 0; i < TouchObjects.Count; i++)
        {
            TouchObjects[i].transform.Find("Point Light").gameObject.SetActive(true);
        }
    }

    public void IncreaseTouchCount()
    {
        touchObjectCount += 1;
        selectObject.Play();
    }

    public void IncreaseSoundCountBarrel()
    {
        soundObjectCount += 1;
        barrelSound.Play();
    }
    public void IncreaseSoundCountSkeleton()
    {
        soundObjectCount += 1;
        skeletonSound.Play();
    }
    public void IncreaseSoundCountBottle()
    {
        soundObjectCount += 1;
        bottleSound.Play();
    }

    public void IncreaseSmellCount()
    {
        smellObjectCount += 1;
        selectObject.Play();
    }
}
