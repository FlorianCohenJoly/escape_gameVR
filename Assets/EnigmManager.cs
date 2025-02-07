using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class EnigmManager : MonoBehaviour
{
    private int topHieroglyphe;
    private int midHieroglyphe;
    private int botHieroglyphe;
    public bool criptOpened = false;
    public int rightPuzzle = 0;
    public bool altarUp =false;
    public bool rightStatue = false;
    public GameObject stele;
    public Transform steleOpened;
    public GameObject piedestal;
    public Transform piedestalUpPos;
    public GameObject trappe;
    public Transform trappeUpPose;
    public AudioSource steleAudio;
    public AudioSource altarAudio; 
    public AudioClip audio;

    void Start()
    {
        topHieroglyphe = 2;
        midHieroglyphe = 1;
        botHieroglyphe = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(topHieroglyphe==3 && midHieroglyphe==3 && botHieroglyphe==3 && !criptOpened){
            criptOpened = true;
            steleAudio.PlayOneShot(audio);
            stele.transform.DOMove(steleOpened.position, 1.5f)
            .SetEase(Ease.Linear);/*.OnComplete(()=>{
            });*/
        }
        if(rightPuzzle == 4 && !altarUp){
            altarUp =true;
            altarAudio.PlayOneShot(audio);
            piedestal.transform.DOMove(piedestalUpPos.position,1f)
            .SetEase(Ease.Linear);
        }
        if(rightStatue){
            rightStatue = false;
            altarAudio.PlayOneShot(audio);
            trappe.transform.DOMove(trappeUpPose.position, 0.5f)
            .SetEase(Ease.Linear);
        }

    }

    public void ChangeHieroglyphe(int etage){
        int currentValue=0;
        switch (etage){
            case 1:
                currentValue = topHieroglyphe;
                break;
            case 2:
                currentValue = midHieroglyphe;
                break;
            case 3:
                currentValue = botHieroglyphe;
                break;
        }
        if(currentValue<3){
            currentValue+=1;
        }else{
            currentValue=0;
        }
        switch (etage){
            case 1:
                topHieroglyphe = currentValue;
                break;
            case 2:
                midHieroglyphe = currentValue;
                break;
            case 3:
                botHieroglyphe = currentValue;
                break;
        }
    }

    public void GestionPuzzle(bool state){
        if(state){
            rightPuzzle+=1;
        }else{
            rightPuzzle-=1;
        }
    }
}
