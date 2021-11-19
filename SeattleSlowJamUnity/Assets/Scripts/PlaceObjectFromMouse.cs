using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectFromMouse : MonoBehaviour
{
    public GameObject[] prefabs;

    private GameObject currentObject;

    public GameObject gameManager;

    public ParticleSystem particle;
    private int objIndex;
    public int diaIndex;

    void Start(){
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        if(currentObject == null){
            currentObject = Instantiate(prefabs[0]);
        }
        else{
            Destroy(currentObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MoveObject();
    }

    private void MoveObject(){
        if(currentObject != null){

            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            RaycastHit hit;
            int layerMask =~ LayerMask.GetMask("CurrentObject");

            if (Physics.Raycast (ray, out hit, 40000, layerMask)) 
            {
                currentObject.transform.position = hit.point;        
                currentObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);        
            }    
            
            if(Input.GetMouseButtonDown(0)){

                Instantiate(currentObject, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                currentObject = null;
                Instantiate(particle, hit.point, Quaternion.FromToRotation(Vector3.up, Vector3.up));
                
                if(diaIndex % 5 == 0){
                    gameManager.GetComponent<CItyDialogueManager>().PlayDialogue(diaIndex);
                }
                else{
                    NextObject();
                }

                diaIndex++;
            }
        }
    }

    private void NextObject(){
        if(diaIndex == 6){
            gameManager.GetComponent<CameraController>().cameraSwitcher(1);
        }

        if(diaIndex == 12){
            gameManager.GetComponent<CameraController>().cameraSwitcher(2);
        }

        if(diaIndex == 24){
            gameManager.GetComponent<CameraController>().cameraSwitcher(3);
        }

        currentObject = Instantiate(prefabs[objIndex]);
        objIndex++;
        
        /*if(objIndex > prefabs.Length){
            objIndex = 0;
        }
        else{
            currentObject = Instantiate(prefabs[objIndex]);
        }*/
    }
}
