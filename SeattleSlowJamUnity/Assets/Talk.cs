using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Fungus;

public class Talk : MonoBehaviour
{
    public bool worked;

    private GameObject player;
    public Flowchart chart;
    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
                player.GetComponent<StarterAssets.ThirdPersonController>().canMove = false;
                cameraSwitcher();
                chart.ExecuteBlock("Talk1");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
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
