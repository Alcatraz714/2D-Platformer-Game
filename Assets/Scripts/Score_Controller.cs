using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score_Controller : MonoBehaviour
{
    [SerializeField] int KeyScore;
    private TextMeshProUGUI scoretext;
    private int score = 0;

    private void Awake() 
    {
        scoretext = GetComponent<TextMeshProUGUI>();
    }

    private void Start() 
    {
        RefreshUI();
    }

    public void IncreaseScore()
    {
        score += KeyScore;
        RefreshUI();
    }

    private void RefreshUI()
    {
        scoretext.text = "Score : " + score;
    }
}
