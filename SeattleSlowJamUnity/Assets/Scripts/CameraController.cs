using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    GameObject[] temp;
    public List<CinemachineVirtualCamera> vCams;
    //public int activeCam = 0;
    void Start()
    {
        temp = GameObject.FindGameObjectsWithTag("vCam");

        for(int i = 0; i < temp.Length; i++){
            vCams.Add(temp[i].GetComponent<CinemachineVirtualCamera>());
        }
    }

    // Update is called once per frame

    public void cameraSwitcher(int i)
    {
        if(i <= vCams.Count){
            for(int j = 0; j < vCams.Count; j++){
                if(j == i){
                    vCams[j].Priority = 20;
                }
                else{
                    vCams[j].Priority = 0;
                }
            }
        }
        else{
            Debug.Log("not enough cameras");
        }
    }
}
