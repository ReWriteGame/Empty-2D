using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameLogic : MonoBehaviour
{
    [SerializeField] private ScoreCounterMB scoreCounter;
    [SerializeField] private DataSave dataSave;

    public UnityEvent OnWinGame;
    public UnityEvent OnLoseGame;
    public UnityEvent OnEndGame;

    private void Start()
    {
    }

    private void OnDestroy()
    {
    }
    
    public void WinGame()
    {
        OnWinGame?.Invoke();
        EndGame();
    }

    public void LoseGame()
    {
        OnLoseGame?.Invoke();
        EndGame();
    }

    private void EndGame()
    {
        SaveData();
        OnEndGame?.Invoke();
    }

    private void SaveData()
    {
        dataSave.HeightScore = Mathf.Max(dataSave.HeightScore, (int)scoreCounter.ScoreCounter.Value);
        dataSave.LastScore = (int)scoreCounter.ScoreCounter.Value;
        dataSave.AllScore += (int)scoreCounter.ScoreCounter.Value;
    }
}