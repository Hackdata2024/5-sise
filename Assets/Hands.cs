using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hands : MonoBehaviour
{
    private XRDirectInteractor interactor;

    // Start is called before the first frame update
    void Start()
    {
        interactor = GetComponent<XRDirectInteractor>();
    }
    public void Test()
    {
        Debug.Log("Test");
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
