using UnityEngine;
using DG.Tweening;
using UnityEngine.XR.Interaction.Toolkit;

public class SlidingDoor : MonoBehaviour
{
    [SerializeField] private Transform door; // L'objet de la porte à déplacer
    [SerializeField] private Vector3 openPosition; // Position finale de la porte lorsqu'elle est ouverte
    [SerializeField] private float slideDuration = 1f; // Durée de l'animation
    [SerializeField] private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable button; // Le bouton interactif

    private Vector3 closedPosition; // Position initiale de la porte
    private bool isOpen = false; // Indique si la porte est ouverte

    void Start()
    {
        // Stocke la position initiale de la porte
        closedPosition = door.position;

        // Abonne-toi à l'événement d'interaction du bouton
        button.selectEntered.AddListener(OnButtonPressed);
    }

    private void OnDestroy()
    {
        // Désabonne-toi pour éviter des erreurs
        button.selectEntered.RemoveListener(OnButtonPressed);
    }

    private void OnButtonPressed(SelectEnterEventArgs args)
    {
        
        if (isOpen)
        {
            // Ferme la porte
            door.DOMove(closedPosition, slideDuration);
        }
        else
        {
            // Ouvre la porte
            door.DOMove(openPosition, slideDuration);
        }

        isOpen = !isOpen; // Alterne l'état
    }
}
