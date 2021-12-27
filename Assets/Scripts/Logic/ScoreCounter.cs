using UnityEngine;
using UnityEngine.Events;


public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private float maxScore;
    [SerializeField] private float minScore = 0;

    public UnityEvent changeScoreEvent;
    public UnityEvent takeAwayScoreEvent;
    public UnityEvent addScoreEvent;
    public UnityEvent isMinScoreEvent;
    public UnityEvent isMaxScoreEvent;

    public float Score { get => score; private set => score = value; }
    public float MaxScore { get => maxScore; private set => maxScore = value; }
    public float MinScore { get => minScore; private set => minScore = value; }


    public void Add(float value)
    {
        if (value < 0) return;
        score = (score + value) >= maxScore ? maxScore : (score + value);

        // Events
        changeScoreEvent?.Invoke();
        addScoreEvent?.Invoke();
        CheckIsMax();
        //changeHP?.Invoke(data.HP);
        //healthEvent?.Invoke(health);
    }

    public void TakeAway(float value)
    {
        if (value < 0) return;
        score = (score - value) <= minScore ? minScore : (score - value);

        // Events
        changeScoreEvent?.Invoke();
        takeAwayScoreEvent?.Invoke();
        CheckIsMin();
        //changeHP?.Invoke(data.HP);
        //damageEvent?.Invoke(health);
    }

    public bool CheckIsMin()
    {
        if (score <= minScore) isMinScoreEvent?.Invoke();
        return score <= minScore ? true : false;
    }
    public bool CheckIsMax()
    {
        if (score >= maxScore) isMaxScoreEvent?.Invoke();
        return score >= maxScore ? true : false;
    }
}
//todo events/var overhill overdamage
//todo зависимость макс хп от хп при настройке
