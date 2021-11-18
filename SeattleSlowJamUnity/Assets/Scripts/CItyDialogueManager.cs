using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
public class CItyDialogueManager : MonoBehaviour
{
    public Flowchart chart;
    public FadeManager fade;
    // Start is called before the first frame update
    void Start()
    {
        fade.SetFade(1,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDialogue(int i){
        chart.ExecuteBlock(i.ToString());
    }

    public void FadeOut(){
        fade.SetFade(0,1);
    }
}
