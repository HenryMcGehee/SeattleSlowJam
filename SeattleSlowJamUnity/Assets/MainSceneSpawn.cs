using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainSceneSpawn : MonoBehaviour
{
    GameObject player;

    public Transform pos1;
    public Transform pos2;

    public bool firstSpawn = true;

    void Awake(){
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        int y = SceneManager.GetActiveScene().buildIndex;

        if(y == 0){
            player = GameObject.FindGameObjectWithTag("Player");
            pos1 =  GameObject.FindGameObjectWithTag("Spawn1").GetComponent<Transform>();
            pos2 =  GameObject.FindGameObjectWithTag("Spawn2").GetComponent<Transform>();

            if(firstSpawn){
                player.transform.position = pos1.position;
            }
            else{
                player.transform.position = pos2.position;
            }
        }
    }

    public void changeSpawn(){
        firstSpawn = false;
    }
}
