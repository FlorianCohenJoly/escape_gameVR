using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketGestionnaire : MonoBehaviour
{
    public EnigmManager manager;
    public string caseValue;
    private bool canWin = false;

    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("Parchemin")){
            Debug.LogWarning("test " + other.name + " et " + caseValue );
            if(caseValue == other.name){
                Debug.LogWarning("reussite puzzle +1");
                manager.GestionPuzzle(true);
            }
        }else if(other.CompareTag("win")){
            canWin = true;
        }
    }

    public void OnTriggerExit(Collider other){
        if(other.CompareTag("Parchemin")){
            if(caseValue == other.name){
                manager.GestionPuzzle(false);
            }
        }else if(other.CompareTag("win")){
            canWin = false;
        }
    }


    public void WinInteraction(){
        if(canWin){
            manager.rightStatue = true;
        }
    }
    
}
