using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounterVisual : MonoBehaviour
{
    [SerializeField] private Text output;
    [SerializeField] private ScoreCounter scoreCounter;
    [SerializeField] private int numberOfCharacters = 2;


    private void Start()
    {
        UpdateScore();
    }


    public void UpdateScore()
    {
        output.text = $"{Math.Round(scoreCounter.Score, numberOfCharacters)}";
    }

    private void OnEnable()
    {
        scoreCounter.changeScoreEvent.AddListener(UpdateScore);
    }
    private void OnDisable()
    {
        scoreCounter.changeScoreEvent.RemoveListener(UpdateScore);
    }
}
