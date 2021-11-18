using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Fungus;
public class ClickToMove : MonoBehaviour
{
    NavMeshAgent agent;
    public float distanceCanMove;
    public float distanceCanTalk;

    public bool Talking;

    public Flowchart chart;

    public ParticleSystem particle;
    private CameraController cam;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        agent = GetComponent<NavMeshAgent>();  
        cam = GameObject.FindGameObjectWithTag("GameManager").GetComponent<CameraController>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(!Talking){

            if(Input.GetMouseButtonDown(0)){
                RaycastHit hitInfo;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                int layer_mask = LayerMask.GetMask("Terrain");
                int layer_mask2 = LayerMask.GetMask("Deer");

                if(Physics.Raycast(ray, out hitInfo, 1000f, layer_mask2)){
                    float distance = Vector3.Distance (hitInfo.point, transform.position);
                    if(distance < distanceCanTalk){
                        Debug.Log("Talking");
                        Talking = true;
                        chart.ExecuteBlock("Talk1");
                        cam.cameraSwitcher(1);
                    }
                }
                else if(Physics.Raycast(ray, out hitInfo, 1000f, layer_mask)){
                    float distance = Vector3.Distance (hitInfo.point, transform.position);
                    if(distance < distanceCanMove){
                        ParticleSystem p = Instantiate(particle, hitInfo.point, Quaternion.FromToRotation(Vector3.up, Vector3.up));
                        agent.SetDestination(hitInfo.point);
                    }
                }
            }
        }
    }
}
