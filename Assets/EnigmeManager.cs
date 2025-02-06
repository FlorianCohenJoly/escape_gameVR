using UnityEngine;

public class EnigmeManager : MonoBehaviour
{
    public GameObject canvasEnigme1;
    public GameObject canvasEnigme2;

    public bool enigme1Terminee = false;


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
}