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
    
    public void Update(){
        if( goodObject == 3){
            porteSorti.SetActive(true);
        }
    } 

    public void IncrementObject(){
        goodObject+=1;
    }
}
