using System;
using TMPro;
using UnityEngine;

public class TimerVisual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI output;
    [SerializeField] private Timer timer;
    [SerializeField] private int numberOfCharacters = 2;
    
    
    
    void Update()
    {
        UpdateTime();
    }


    public void UpdateTime()
    {
        output.text = $"{Math.Round(timer.CurrentTime, numberOfCharacters)}";
    }
}
