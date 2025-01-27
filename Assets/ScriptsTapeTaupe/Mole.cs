using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mole : MonoBehaviour
{
    public bool IsHit { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hammer"))
        {
            Debug.Log("Mole hit by hammer");
            Hide();
            GameManager.Instance.AddScore(1); // Ajoute 1 point
            IsHit = true; // Marque la taupe comme frappée
        }
    }

    public void Rise()
    {
        IsHit = false; // Réinitialise le statut lors de chaque apparition
        transform.DOMoveY(0.7f, 0.7f);
    }

    public void Hide()
    {
        transform.DOMoveY(-0.7f, 0.7f);
    }
}
