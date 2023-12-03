using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DataSave", menuName = "ScriptableObjects/DataSave", order = 9)]
public class DataSave : ScriptableObject
{
    [SerializeField] private int lastScore = 0;
    [SerializeField] private int heightScore = 0;
    [SerializeField] private int allScore = 0;

    public Action OnUpdateData;

    public int AllScore
    {
        get => allScore;
        set => SetValueInt(ref allScore, value);
    }

    public int LastScore
    {
        get => lastScore;
        set => SetValueInt(ref lastScore, value);
    }

    public int HeightScore
    {
        get => heightScore;
        set => SetValueInt(ref heightScore, value);
    }

    private void SetValueInt(ref int field, int value) // make t value?
    {
        field = value;
        OnUpdateData?.Invoke();
    }
}