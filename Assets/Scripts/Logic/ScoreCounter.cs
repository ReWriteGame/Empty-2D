using UnityEngine;
using UnityEngine.Events;


public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float score = 0;
    //[SerializeField] private float minScore = 0;
    //[SerializeField] private float maxScore = 100;
    [SerializeField] private Vector2 borders = new Vector2(0,100);

    public UnityEvent changeScoreEvent;
    public UnityEvent takeAwayScoreEvent;
    public UnityEvent addScoreEvent;
    public UnityEvent isMinScoreEvent;
    public UnityEvent isMaxScoreEvent;

    public float Value { get => score; private set => score = value; }
    public float MinScore { get => borders.x; private set => borders.x = value; }
    public float MaxScore { get => borders.y; private set => borders.y = value; }


    public void Add(float value)
    {
        if (value < 0) return;
        score = (score + value) >= borders.y ? borders.y : (score + value);

        // Events
        changeScoreEvent?.Invoke();
        addScoreEvent?.Invoke();
        if (CheckIsMax()) isMaxScoreEvent?.Invoke();
    }

    public void TakeAway(float value)
    {
        if (value < 0) return;
        score = (score - value) <= borders.x ? borders.x : (score - value);

        // Events
        changeScoreEvent?.Invoke();
        takeAwayScoreEvent?.Invoke();
        if (CheckIsMin()) isMinScoreEvent?.Invoke();
    }

    public bool CheckIsMin()
    {
        return score <= borders.x ? true : false;
    }
    public bool CheckIsMax()
    {
        return score >= borders.y ? true : false;
    }

    public void CorrectScore()
    {
        if(CheckIsMax()) score = borders.y;
        if(CheckIsMin()) score = borders.x;
    }
    
    private void Awake()
    {
        CorrectScore();
    }
}
