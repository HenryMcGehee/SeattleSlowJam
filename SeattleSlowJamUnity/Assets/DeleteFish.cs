using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFish : MonoBehaviour
{
    public GameObject fishManager;

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("Fish")){
            Destroy(other.gameObject);
            fishManager.GetComponent<FishLauncher>().canSpawn = true;
        }
    }
}
