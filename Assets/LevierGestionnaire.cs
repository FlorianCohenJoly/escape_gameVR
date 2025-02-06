using System.Collections;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class LevierGestionnaire : MonoBehaviour
{
    public GameObject rotatingPart;
    public XRLever levier;
    public bool canRotate = true;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void ActivLevier(){
        Debug.LogWarning("activation");
        
        
    }

    public void RotatePart(){
        if(canRotate){
            canRotate = false;
            StartCoroutine("Rotating");
        }
    }

    public IEnumerator Rotating(){
        yield return new WaitForSeconds(0.5f);
        canRotate = true;
    }
}
