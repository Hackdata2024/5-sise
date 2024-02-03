using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeepBreathing : MonoBehaviour
{
    public GameObject Player;
    public Transform waypointsParent;

    private List<Transform> waypoints = new List<Transform>();

    private CharacterController playerController;
    private BreathingUI breathe;
    int j = 0;
    private Vector3 moveDirection;

    private bool hasReachedLast = false;
    void Start()
    {
        playerController = Player.GetComponent<CharacterController>();
        breathe = GetComponent<BreathingUI>();

        for (int i = 0; i < waypointsParent.childCount; i++)
        {
            waypoints.Add(waypointsParent.GetChild(i));
        }

        moveToWaypoints(waypoints);
    }

    
    void Update()
    {
        if (!hasReachedLast)
        {
            moveToWaypoints(waypoints);
        }
        if (hasReachedLast)
        {
            Invoke("enableBreatheUI", 13);
        }
    }

    void moveToWaypoints(List<Transform> listt)
    {
        Debug.Log(Vector3.Distance(Player.transform.position, listt[j].position));
        if (Vector3.Distance(Player.transform.position, listt[j].position) > 1f)
        {
            moveDirection = listt[j].position - Player.transform.position;
            Player.transform.Translate(moveDirection * 0.7f * Time.deltaTime);
        }
        else
        {
            if (j != (listt.Count - 1))
            {
                j += 1;
            }
            else
            {
                hasReachedLast = true;
                playerController.enabled = true;


            }
            moveDirection = listt[j].position - Player.transform.position;
        }
    }

    private void enableBreatheUI()
    {
        breathe.enabled = true;
    }
}
