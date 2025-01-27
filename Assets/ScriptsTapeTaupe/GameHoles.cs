using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHoles : MonoBehaviour
{
    public List<Mole> moles = new List<Mole>();
    public float initialDelayBetweenMoles = 2f;  // Délai initial entre les apparitions de taupes
    private float delayBetweenMoles;
    public float difficultyIncreaseRate = 0.1f;  // Réduction du délai à chaque apparition
    public float minDelayBetweenMoles = 0.5f;    // Délai minimum entre les apparitions

    private void Start()
    {
        delayBetweenMoles = initialDelayBetweenMoles;
    }

    IEnumerator SpawnMolesRandomly()
    {
        while (true)
        {
            if (moles.Count > 0)
            {
                int randomIndex = Random.Range(0, moles.Count);
                Mole selectedMole = moles[randomIndex];

                if (selectedMole != null)
                {
                    selectedMole.Rise();

                    yield return new WaitForSeconds(delayBetweenMoles);

                    if (!selectedMole.IsHit) // Vérifie si la taupe a été frappée
                    {
                        GameManager.Instance.LoseLife(); // Le joueur perd une vie si la taupe n'est pas frappée
                    }
                    selectedMole.Hide();

                    // Augmente la difficulté en réduisant le délai
                    delayBetweenMoles = Mathf.Max(minDelayBetweenMoles, delayBetweenMoles - difficultyIncreaseRate);
                }
            }
            yield return new WaitForSeconds(delayBetweenMoles);
        }
    }

    public void StartRandomMole()
    {
        Debug.Log("StartRandomMole");
        StartCoroutine(SpawnMolesRandomly());
    }
}
