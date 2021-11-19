using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public GameObject[] vCams;

    //public int activeCam = 0;
    void Start()
    {
        //vCams = GameObject.FindGameObjectsWithTag("vCam");
    }

    // Update is called once per frame

    public void cameraSwitcher(int i)
    {
        if(i <= vCams.Length){
            for(int j = 0; j < vCams.Length; j++){
                if(j == i){
                    vCams[j].GetComponent<CinemachineVirtualCamera>().Priority = 20;
                }
                else{
                    vCams[j].GetComponent<CinemachineVirtualCamera>().Priority = 0;
                }
            }
        }
        else{
            Debug.Log("not enough cameras");
        }
    }
}
