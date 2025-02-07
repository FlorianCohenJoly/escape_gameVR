using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameVictory : MonoBehaviour
{
    public int goodObject = 0;
    public bool egyptObject = false;
    public bool farmObject =false;
    public bool scifiObject = false;
    public GameObject porteSorti;
    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("item1") && !egyptObject){
            egyptObject = true;
            goodObject +=1;
        }else if(other.CompareTag("item2") && !farmObject){
            farmObject = true;
            goodObject +=1;
        }else if (other.CompareTag("item3") && !scifiObject){
            scifiObject = true;
            goodObject +=1;
        }
    } 

    public void Update(){
        if( goodObject == 3){
            porteSorti.SetActive(true);
        }
    } 
}
