using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Talk : MonoBehaviour
{
    public bool worked;
    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;

    private void Start()
    {
        cameraSwitcher();
    }


    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
                Debug.Log("it worked");
            if (Input.GetButtonDown("Interact"))
            {
                worked = true;
                cameraSwitcher();
            }
        }
    }

    void cameraSwitcher()
    {
        if (worked)
        {
            vcam1.Priority = 0;
            vcam2.Priority = 1;
        }
        else
        {
            vcam1.Priority = 1;
            vcam2.Priority = 0;
        }
    }
}
