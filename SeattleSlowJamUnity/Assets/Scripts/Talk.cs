using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Fungus;

public class Talk : MonoBehaviour
{
    private GameObject player;
    public Flowchart chart;

    private CameraController cam;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cam = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CameraController>();
    }


    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Interact"))
            {
                player.GetComponent<StarterAssets.ThirdPersonController>().canMove = false;
                chart.ExecuteBlock("Talk1");
                cam.cameraSwitcher(1);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}
