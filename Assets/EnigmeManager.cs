using DG.Tweening;
using UnityEngine;

public class EnigmeManager : MonoBehaviour
{
    public GameObject canvasEnigme1;
    public GameObject canvasEnigme2;

    public bool enigme1Terminee = false;


    public Transform coffre; // Assigne ici le Transform du coffre
    public Vector3 hauteurApparition; // Hauteur à laquelle le coffre doit apparaitre
    public float dureeAnimation = 1.5f; // Durée de l'animation

    public void TerminerEnigme1()
    {
        enigme1Terminee = true;
        AfficherUIEnigme2();
    }

    private void AfficherUIEnigme2()
    {
        canvasEnigme1.SetActive(false);
        canvasEnigme2.SetActive(true);
    }
    public void FaireApparaitreCoffre()
    {
        if (coffre != null)
        {
            coffre.DOMoveY(hauteurApparition.y, dureeAnimation);
        }
    }


}