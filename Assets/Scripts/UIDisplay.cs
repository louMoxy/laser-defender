using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Slider healthSlider;
    [SerializeField] GameObject player;

    ScoreKeeper scoreKeeper;
    Health playerHealth;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        playerHealth = player.GetComponent<Health>();
    }

    private void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
        healthSlider.minValue = 0;
    }

    private void Update()
    {
        if(scoreKeeper != null)
        {
            scoreText.text = scoreKeeper.GetScore().ToString("0000000");
        }

        if(playerHealth != null)
        {
            healthSlider.value = playerHealth.GetHealth();
        }
    }

}
