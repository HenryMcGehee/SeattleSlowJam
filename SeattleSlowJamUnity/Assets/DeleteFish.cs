using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFish : MonoBehaviour
{
    public FishLauncher fishManager;
    GameObject gameManager;

    void Start(){
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("Fish")){
            Destroy(other.gameObject);
            fishManager.canSpawn = true;
        }
    }
}
