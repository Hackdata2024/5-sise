using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public enum breatheStages
{
    instruction,
    repeat,
    completed,
    end
}
public class BreathingUI : MonoBehaviour
{
    public AudioSource completeTactic;

    private breatheStages currentStage;

    public AudioSource instructionAudio;
    public AudioSource inhaleAudio;
    public AudioSource completeAudio;

    public VideoPlayer videoPlayer;

    private float timer = 15f;
    private float timerCount = 0f;
    int i = 0;

   
    void Start()
    {
        //completeTactic.Play();
        currentStage = breatheStages.instruction;
        //Invoke("playInstructionVoiceover", 13);
        instructionAudio.Play();
        Invoke("startRepetition", 1);
        //Invoke("startRepetition", 12);
    }

    void Update()
    {
        switch (currentStage)
        {
            case breatheStages.instruction:
                break;

            case breatheStages.repeat:
                if (i < 3)
                {
                    if (timerCount < timer)
                    {
                        timerCount += Time.deltaTime;
                    }
                    else
                    {
                        timerCount = 0f;
                        i += 1;
                        //inhaleAudio.Play();
                        Debug.Log("playing video");
                        videoPlayer.Stop();
                        videoPlayer.Play();
                    }

                }
                else
                {
                    currentStage = breatheStages.completed;
                }
                break;
            case breatheStages.completed:
                Invoke("playFinalAudio", 15);
                gameObject.GetComponent<BreathingUI>().enabled = false;
                break;
        }
    }

    private void playInstructionVoiceover()
    {
        instructionAudio.Play();
    }
    private void startRepetition()
    {
        currentStage = breatheStages.repeat;
    }
    private void playFinalAudio()
    {
        completeAudio.Play();
    }
}
