using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTimer : MonoBehaviour
{
    public GameObject[] UI;
    public GameObject Start;
    public void Trigger()
    {
        for (int i = 0; i < UI.Length; i++)
        {
            if (UI[i].activeInHierarchy == false)
            {
                UI[i].SetActive(true);
            }
            else
            {
                UI[i].SetActive(true);
            }

        }
    }

    public void StartButton()
    {
        Start.SetActive(false);
    }
}
