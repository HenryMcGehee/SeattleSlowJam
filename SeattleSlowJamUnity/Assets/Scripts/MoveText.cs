using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveText : MonoBehaviour
{
    public float speed = 0.5f;
    private float fraction = 0;
    public Transform pos1;
    public Transform pos2;

    public bool setPos;
    void Update()
    {
        //setRotation();
        setPosition(setPos);
    }

    public void setPosition(bool posTrigger){
        if(posTrigger){
            if(fraction < 1){
                fraction += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(transform.position, pos1.position, fraction);
            }
        }
        else{
            if(fraction < 1){
                fraction += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(transform.position, pos2.position, fraction);
            }
        }
    }
    void setRotation(){
            transform.LookAt(Camera.main.transform.position, -Vector3.up);
    }

    public void setMethod(){
        if(setPos){
            fraction = 0;
            setPos = false;
        }
        else{
            fraction = 0;
            setPos = true;
        }
    }
}
