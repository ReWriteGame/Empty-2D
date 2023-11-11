#region Version scripts = 1.1
#endregion

using System;
using UnityEngine;



namespace Modules.Score
{
    [Serializable]
    public struct ScoreCounterData
    {
        [SerializeField] private float value;
        [SerializeField] private Limit valueLimit;// min max

        #region Properties 
        public float Value => value;
        public Limit ValueLimit => valueLimit;
        public float MinValue => valueLimit.MinValue;
        public float MaxValue => valueLimit.MaxValue;
        public float LengthLimit => valueLimit.LengthLimit;
        public float LengthCurrentScoreToMaximum => Math.Abs(valueLimit.MaxValue - Value);
        public float LengthCurrentScoreToMinimum => Math.Abs(Value - valueLimit.MinValue);
        public bool CheckValueIsMin => Mathf.Approximately(value, valueLimit.MinValue);
        public bool CheckValueIsMax => Mathf.Approximately(value, valueLimit.MaxValue);


        #endregion

        #region Сonstructors
        public ScoreCounterData(ScoreCounterData data) => this = data;

        public ScoreCounterData(float value, Limit limit)
        {
            valueLimit = limit;
            this.value = value;
            CorrectValue();
        }

        public ScoreCounterData(float value, float minValue, float maxValue)
        {
            valueLimit = new Limit(minValue, maxValue);
            this.value = value;
            CorrectValue();
        }

        public ScoreCounterData(float value = 0)
        {
            valueLimit = new Limit(float.NegativeInfinity, float.PositiveInfinity);
            this.value = value;
            CorrectValue();
        }
        
        #endregion

        public void SetMinLimit(float value)
        {
            float min = Math.Min(value, valueLimit.MaxValue);
            valueLimit = new Limit(min, valueLimit.MaxValue);
            CorrectValue();
        }

        public void SetMaxLimit(float value)
        {
            float max = Math.Max(valueLimit.MinValue, value);
            valueLimit = new Limit(valueLimit.MinValue, max);
            CorrectValue();
        }

        public void SetValue(float value)
        {
            this.value = value;
            CorrectValue();
        }
       
        private void CorrectValue()
        {
            if (!IsValueCorrect())
            {
                Debug.Log("Attempt to set the wrong date. Data will be corrected.");
            }
            value = Mathf.Clamp(value, valueLimit.MinValue, valueLimit.MaxValue);
        }

        private bool IsValueCorrect() => valueLimit.MinValue <= valueLimit.MaxValue && value >= valueLimit.MinValue && value <= valueLimit.MaxValue;
    }
}