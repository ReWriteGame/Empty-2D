using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerVisual : MonoBehaviour
{
    [SerializeField] private Text output;
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
