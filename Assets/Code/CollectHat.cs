using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectHat : MonoBehaviour
{
    public GameObject hatOnCashierDesk;
    
     private void Start()
    {
        hatOnCashierDesk.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            
            hatOnCashierDesk.SetActive(true);
        }
    }
}
