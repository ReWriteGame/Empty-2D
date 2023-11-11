using Modules.Score;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounterMB : MonoBehaviour
{
    [SerializeField] private ScoreCounter scoreCounter;

    public UnityEvent<ScoreCounterData> OnChangeData;
    public UnityEvent<ScoreCounterData> OnChangeDataLastValue;

    public UnityEvent<float> OnChangeValue;
    public UnityEvent<float> OnChangeValueLastValue;
    public UnityEvent<float> OnIncreaseValue;
    public UnityEvent<float> OnDecreaseValue;
    public UnityEvent<float> OnCanNotIncreaseValue;
    public UnityEvent<float> OnCanNotDecreaseValue;

    public UnityEvent<Limit> OnChangeLimit;
    public UnityEvent<Limit> OnChangeLimitLastValue;
    public UnityEvent<float> OnChangeLimitMin;
    public UnityEvent<float> OnChangeLimitMinLastValue;
    public UnityEvent<float> OnIncreaseMinValue;
    public UnityEvent<float> OnDecreaseMinValue;
    public UnityEvent<float> OnChangeLimitMax;
    public UnityEvent<float> OnChangeLimitMaxLastValue;
    public UnityEvent<float> OnIncreaseMaxValue;
    public UnityEvent<float> OnDecreaseMaxValue;
    public UnityEvent OnReachMinValue;
    public UnityEvent OnReachMaxValue;

    public ScoreCounter ScoreCounter => scoreCounter;

    private void Awake() => Subscribe();
    private void OnDestroy() => Unsubscribe();

    private void Subscribe()
    {
        scoreCounter.OnChangeData += OnChangeData.Invoke;
        scoreCounter.OnChangeDataLastValue += OnChangeDataLastValue.Invoke;
        scoreCounter.OnChangeValue += OnChangeValue.Invoke;
        scoreCounter.OnChangeValueLastValue += OnChangeValueLastValue.Invoke;
        scoreCounter.OnIncreaseValue += OnIncreaseValue.Invoke;
        scoreCounter.OnDecreaseValue += OnDecreaseValue.Invoke;
        scoreCounter.OnCanNotIncreaseValue += OnCanNotIncreaseValue.Invoke;
        scoreCounter.OnCanNotDecreaseValue += OnCanNotDecreaseValue.Invoke;
        scoreCounter.OnChangeLimit += OnChangeLimit.Invoke;
        scoreCounter.OnChangeLimitLastValue += OnChangeLimitLastValue.Invoke;
        scoreCounter.OnChangeLimitMin += OnChangeLimitMin.Invoke;
        scoreCounter.OnChangeLimitMinLastValue += OnChangeLimitMinLastValue.Invoke;
        scoreCounter.OnIncreaseMinValue += OnIncreaseMinValue.Invoke;
        scoreCounter.OnDecreaseMinValue += OnDecreaseMinValue.Invoke;
        scoreCounter.OnChangeLimitMax += OnChangeLimitMax.Invoke;
        scoreCounter.OnChangeLimitMaxLastValue += OnChangeLimitMaxLastValue.Invoke;
        scoreCounter.OnIncreaseMaxValue += OnIncreaseMaxValue.Invoke;
        scoreCounter.OnDecreaseMaxValue += OnDecreaseMaxValue.Invoke;
        scoreCounter.OnReachMinValue += OnReachMinValue.Invoke;
        scoreCounter.OnReachMaxValue += OnReachMaxValue.Invoke;
    }

    private void Unsubscribe()
    {
        scoreCounter.OnChangeData -= OnChangeData.Invoke;
        scoreCounter.OnChangeDataLastValue -= OnChangeDataLastValue.Invoke;
        scoreCounter.OnChangeValue -= OnChangeValue.Invoke;
        scoreCounter.OnChangeValueLastValue -= OnChangeValueLastValue.Invoke;
        scoreCounter.OnIncreaseValue -= OnIncreaseValue.Invoke;
        scoreCounter.OnDecreaseValue -= OnDecreaseValue.Invoke;
        scoreCounter.OnCanNotIncreaseValue -= OnCanNotIncreaseValue.Invoke;
        scoreCounter.OnCanNotDecreaseValue -= OnCanNotDecreaseValue.Invoke;
        scoreCounter.OnChangeLimit -= OnChangeLimit.Invoke;
        scoreCounter.OnChangeLimitLastValue -= OnChangeLimitLastValue.Invoke;
        scoreCounter.OnChangeLimitMin -= OnChangeLimitMin.Invoke;
        scoreCounter.OnChangeLimitMinLastValue -= OnChangeLimitMinLastValue.Invoke;
        scoreCounter.OnIncreaseMinValue -= OnIncreaseMinValue.Invoke;
        scoreCounter.OnDecreaseMinValue -= OnDecreaseMinValue.Invoke;
        scoreCounter.OnChangeLimitMax -= OnChangeLimitMax.Invoke;
        scoreCounter.OnChangeLimitMaxLastValue -= OnChangeLimitMaxLastValue.Invoke;
        scoreCounter.OnIncreaseMaxValue -= OnIncreaseMaxValue.Invoke;
        scoreCounter.OnDecreaseMaxValue -= OnDecreaseMaxValue.Invoke;
        scoreCounter.OnReachMinValue -= OnReachMinValue.Invoke;
        scoreCounter.OnReachMaxValue -= OnReachMaxValue.Invoke;
    }

    public void SetValue(float value) => scoreCounter.SetValue(value);
    public void SetMinValue(float value) => scoreCounter.SetMinValue(value);
    public void SetMaxValue(float value) => scoreCounter.SetMaxValue(value);
    public void SetData(ScoreCounterData data) => scoreCounter.SetData(data);
    public void IncreaseValue(float value) => scoreCounter.IncreaseValue(value);
    public void DecreaseValue(float value) => scoreCounter.DecreaseValue(value);
    public bool IncreaseValueLimited(float value) => scoreCounter.IncreaseValueLimited(value);
    public bool DecreaseValueLimited(float value) => scoreCounter.DecreaseValueLimited(value);
    public void IncreaseLimitMin(float value) => scoreCounter.IncreaseLimitMin(value);
    public void DecreaseLimitMin(float value) => scoreCounter.DecreaseLimitMin(value);
    public void IncreaseLimitMax(float value) => scoreCounter.IncreaseLimitMax(value);
    public void DecreaseLimitMax(float value) => scoreCounter.DecreaseLimitMax(value);
}