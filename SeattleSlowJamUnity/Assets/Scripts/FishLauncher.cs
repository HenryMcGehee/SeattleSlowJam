using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishLauncher : MonoBehaviour
{
    public GameObject fish;
    public Vector2 force;
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
                    GameObject fishObj = Instantiate(fish, hitInfo.point, Quaternion.FromToRotation(Vector3.up, Vector3.up));
                    fishObj.GetComponent<Rigidbody>().AddForce(force);
                    fishCount++;
                    force += new Vector2(0, 20);
                    canSpawn = false;
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