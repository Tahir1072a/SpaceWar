using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Health healthFile;
    [SerializeField] Slider m_Health;
    [Header("Score")]
    [SerializeField] TextMeshProUGUI m_ScoreText;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void Start()
    {
        m_Health.maxValue = healthFile.GetHealth(); 

    }
    void Update()
    {
        UpdateScoreView();
        UpdateHealthView();
    }

    private void UpdateScoreView()
    {
        if(scoreKeeper != null)
        {
            m_ScoreText.text = scoreKeeper.GetCurrentScore().ToString("000000000");
        }
    }
    private void UpdateHealthView()
    {
         m_Health.value =healthFile.GetHealth();
    }
}
