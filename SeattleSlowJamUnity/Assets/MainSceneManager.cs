using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    public GameObject spawner;

    // Start is called before the first frame update
    void Awake()
    {
        if(GameObject.FindGameObjectWithTag("MainSceneSpawner") == null){
            Instantiate(spawner);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
