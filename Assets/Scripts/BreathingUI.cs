using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private float timer = 15f;
    private float timerCount = 0f;
    int i = 0;

   
    void Start()
    {
        
        //completeTactic.Play();
        currentStage = breatheStages.instruction;
        Invoke("playInstructionVoiceover", 13);
        Invoke("startRepetition", 14);
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
                        inhaleAudio.Play();
                    }

                }
                else
                {
                    currentStage = breatheStages.completed;
                }
                break;
            case breatheStages.completed:
                Invoke("playFinalAudio", 15);
                this.enabled = false;
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
