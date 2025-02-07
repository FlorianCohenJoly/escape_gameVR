using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class LevierGestionnaire : MonoBehaviour
{
    public GameObject rotatingPart;
    public XRLever levier;
    public bool canRotate = true;
    private Quaternion initialRotation;
    public EnigmManager manager;
    public int etage;
    public AudioSource obeliscAudio;

    void Start()
    {
        initialRotation = levier.handle.localRotation;
    }

    
    void Update()
    {
        
    }

    public void ActivLevier(){
        levier.handle.GetComponent<Rigidbody>().isKinematic = false;
        levier.value = false;
        levier.handle.rotation = initialRotation;
        levier.value = true;
        levier.handle.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void RotatePart(){
        if(canRotate){
            canRotate = false;
            obeliscAudio.Play();
            rotatingPart.transform.DORotate(rotatingPart.transform.rotation.eulerAngles + new Vector3(0, 90, 0), 2f, RotateMode.FastBeyond360)
                .SetEase(Ease.OutQuad) 
                .OnComplete(() => {
                    canRotate = true;
                    manager.ChangeHieroglyphe(etage);
                    obeliscAudio.Stop();
                });
        }
    }

  
}
