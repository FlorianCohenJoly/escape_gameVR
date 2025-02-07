using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comptabiliseObject : MonoBehaviour
{
    public GameVictory manager;


    public void OnTriggerEnter(Collider other){
        if(other.CompareTag("item1") && !manager.egyptObject){
            Debug.LogWarning("objet egypte trouvé");
            manager.egyptObject = true;
            manager.IncrementObject();
        }else if(other.CompareTag("item2") && !manager.farmObject){
            Debug.LogWarning("objet scifi trouvé");
            manager.farmObject = true;
            manager.IncrementObject();
        }else if (other.CompareTag("item3") && !manager.scifiObject){
            Debug.LogWarning("objet frarm trouvé");
            manager.scifiObject = true;
            manager.IncrementObject();
        }
    } 

}
