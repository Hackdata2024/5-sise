using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableBreathing : MonoBehaviour
{
    public BreathingUI breathe;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            breathe.enabled = true;
        }
    }
}
