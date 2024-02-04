using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeTacticFinish : MonoBehaviour
{
    public AudioSource threeTacticFinish;
    private BreathingUI breathe;
    // Start is called before the first frame update
    void Start()
    {
        threeTacticFinish.Play();
        breathe = GetComponent<BreathingUI>();
        Invoke("BreathingEnable", 13);
        gameObject.GetComponent<ThreeTacticFinish>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BreathingEnable()
    {
        breathe.enabled = true;
    }
}
