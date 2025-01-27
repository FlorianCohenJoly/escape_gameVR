using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TMP_Text scoreText;
    public TMP_Text comboText;
    public TMP_Text lifeText;

    private int score;
    private int life = 3;  // Démarrage avec 3 vies
    private int combo = 0;  // Combo initialisé à 0
    private float comboDuration = 2f; // Durée du combo en secondes
    private float comboTimer; // Chrono pour réinitialiser le combo

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        DisplayScore();
        DisplayLife();
        DisplayCombo();
    }

    private void Update()
    {
        // Décrémente le combo timer
        if (combo > 0)
        {
            comboTimer -= Time.deltaTime;
            if (comboTimer <= 0)
            {
                ResetCombo();
            }
        }
    }

    public void AddScore(int points)
    {
        // Applique un multiplicateur de score basé sur le combo
        int pointsWithCombo = points * (combo + 1);
        score += pointsWithCombo;
        combo++; // Incrémente le combo
        comboTimer = comboDuration; // Réinitialise le timer de combo

        DisplayScore();
        DisplayCombo();
    }

    public void DisplayScore()
    {
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);
    }

    public void DisplayLife()
    {
        lifeText.text = "Life: " + life;
        Debug.Log("Life: " + life);
    }

    public void DisplayCombo()
    {
        comboText.text = "Combo x" + (combo + 1); // Le combo commence à 1 pour multiplier les points
        Debug.Log("Combo: " + combo);
    }

    public void LoseLife()
    {
        life--;
        DisplayLife();

        if (life <= 0)
        {
            GameOver();
        }
    }

    private void ResetCombo()
    {
        combo = 0;
        DisplayCombo();
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        RestartGame();
    }

    public void RestartGame()
    {
        score = 0;
        life = 3;
        combo = 0;
        DisplayScore();
        DisplayLife();
        DisplayCombo();
    }
}
