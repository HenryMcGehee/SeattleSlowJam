using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FishLauncher : MonoBehaviour
{
    public GameObject fish;
    public GameObject defaultCamPos;
    public Vector2 force;
    public CinemachineVirtualCamera cam;
    RaycastHit hitInfo;
    Collider coll;

    public int fishCount;
    private GameObject gameManager;
    public bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
           
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

            if(coll.Raycast(ray, out hitInfo, 1000f)){
                if(fishCount % 5 != 0 && canSpawn){
                    if(GameObject.FindGameObjectWithTag("Fish") == null){

                        GameObject fishObj = Instantiate(fish, hitInfo.point, Quaternion.FromToRotation(Vector3.up, Vector3.up));
                        fishObj.GetComponent<Rigidbody>().AddForce(force);
                        force += new Vector2(0, 20);
                        canSpawn = false;
                        cam.Follow = fishObj.transform;
                        fishCount++;
                    }
                }

                if(fishCount % 5 == 0){
                    gameManager.GetComponent<CItyDialogueManager>().PlayDialogue(fishCount);
                    canSpawn = false;
                    fishCount++;
                }
            }
        }
    }

    public void CanSpawn(){
        canSpawn = true;
    }
}