using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Customer : MonoBehaviour
{
    public Flowchart Dialogue;
    public string name;

    void OnTriggerEnter(Collider x)
    {
        if(x.gameObject.tag=="Player"){
            Dialogue.ExecuteBlock(name);
        }
    }
}
