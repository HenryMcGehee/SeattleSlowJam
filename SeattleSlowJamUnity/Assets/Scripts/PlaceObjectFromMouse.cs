using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectFromMouse : MonoBehaviour
{
    public GameObject[] prefabs;

    private GameObject currentObject;

    public GameObject gameManager;
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
                //NextObject();
                currentObject = null;
                gameManager.GetComponent<CItyDialogueManager>().PlayDialogue(diaIndex);
                diaIndex++;
            }
        }
    }

    private void NextObject(){
        if(diaIndex == 3){
            gameManager.GetComponent<CameraController>().cameraSwitcher(0);
        }

        if(diaIndex == 6){
            gameManager.GetComponent<CameraController>().cameraSwitcher(2);
        }

        if(objIndex > prefabs.Length){
            objIndex = 0;
            currentObject = Instantiate(prefabs[objIndex]);
        }
        else{
            objIndex++;
            currentObject = Instantiate(prefabs[objIndex]);
        }
    }
}
