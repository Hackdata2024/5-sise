using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enable : MonoBehaviour
{
    public GameObject[] UI;
    public void Trigger()
    {
        for (int i = 0; i < UI.Length; i++)
        {
            if (UI[i].activeInHierarchy == true)
            {
                UI[i].SetActive(false);
            }
            else
            {
                UI[i].SetActive(false);
            }

        }
    }
}
