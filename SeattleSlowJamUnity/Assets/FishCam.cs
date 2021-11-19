using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCam : MonoBehaviour
{

    public GameObject fish;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(fish != null){
            transform.position = new Vector3(transform.position.x, fish.transform.position.y, transform.position.z);
        }
    }
}
