using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class teleportZone : MonoBehaviour
{
    public Transform tpPos;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.LogWarning("enter collider trig");
            other.transform.position = tpPos.position;
        }
    }
}
