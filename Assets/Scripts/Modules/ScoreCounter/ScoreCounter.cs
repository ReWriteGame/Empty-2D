#region Version scripts = 1.1
#endregion

using System;
using UnityEngine;

namespace Modules.Score
{
    [Serializable]
    public class ScoreCounter
    {
        [SerializeField] private ScoreCounterData data;

        #region Events
        public event Action<ScoreCounterData> OnChangeData;
        public event Action<ScoreCounterData> OnChangeDataLastValue;
        
        public event Action<float> OnChangeValue;
        public event Action<float> OnChangeValueLastValue;
        public event Action<float> OnIncreaseValue;
        public event Action<float> OnDecreaseValue;
        public event Action<float> OnCanNotIncreaseValue;
        public event Action<float> OnCanNotDecreaseValue;
        
        public event Action<Limit> OnChangeLimit;
        public event Action<Limit> OnChangeLimitLastValue;
        public event Action<float> OnChangeLimitMin;
        public event Action<float> OnChangeLimitMinLastValue;
        public event Action<float> OnIncreaseMinValue;
        public event Action<float> OnDecreaseMinValue;
        public event Action<float> OnChangeLimitMax;
        public event Action<float> OnChangeLimitMaxLastValue;
        public event Action<float> OnIncreaseMaxValue;
        public event Action<float> OnDecreaseMaxValue;
        public event Action OnReachMinValue;
        public event Action OnReachMaxValue;
        
        #endregion
        
        #region Properties 
        public float Value => data.Value;
        public float MinValue => data.ValueLimit.MinValue;
        public float MaxValue => data.ValueLimit.MaxValue;
        public Limit ValueLimit => data.ValueLimit;
        public ScoreCounterData Data => data;
        public float LengthLimit => data.ValueLimit.LengthLimit;

        #endregion

        #region Сonstructors
        public ScoreCounter()
        {
            data = new ScoreCounterData();
        }
         
        public ScoreCounter(ScoreCounterData data)
        {
            this.data = data;
        }
       
        #endregion
     
        public void SetValue(float value) => SetData(new ScoreCounterData(value, data.MinValue, data.MaxValue));
        public void SetMinValue(float value) => SetData(new ScoreCounterData(data.Value, value, data.MaxValue));
        public void SetMaxValue(float value) => SetData(new ScoreCounterData(data.Value, data.MinValue, value));
        public void SetData(ScoreCounterData data)
        {
            var oldData = this.data;
            this.data = data;
            InvokeDataChangeEvents(oldData, this.data);
        }


        public void IncreaseValue(float value) 
        {
            if (value <= 0) return;
            var oldData = data;
            data.SetValue(data.Value + value);
            InvokeDataChangeEvents(oldData, data);

            InvokeIncreaseValueEvents(value);
        }

        public void DecreaseValue(float value)
        {
            if (value <= 0) return;
            var oldData = data;
            data.SetValue(data.Value - value);
            InvokeDataChangeEvents(oldData, data);
            
            InvokeDecreaseValueEvents(value);
        }
        
        
        public bool IncreaseValueLimited(float value)
        {
            if (value <= 0) return false;

            if (data.LengthCurrentScoreToMaximum >= value)
            {
                IncreaseValue(value);
                return true;
            }
            else
            {
                OnCanNotIncreaseValue?.Invoke(value);
                return false; 
            }
        }

        public bool DecreaseValueLimited(float value)
        {
            if (value <= 0) return false;
           
            if (data.LengthCurrentScoreToMinimum >= value) 
            {
                DecreaseValue(value);
                return true;
            }
            else
            {
                OnCanNotDecreaseValue?.Invoke(value);
                return false; 
            }
        }
        
           
        public void IncreaseLimitMin(float value)
        {
            if (value <= 0) return;
            var oldData = data;
            data.SetMinLimit(data.MinValue + value);
            InvokeDataChangeEvents(oldData, data);
            OnIncreaseMinValue?.Invoke(value);
        }
        
        public void DecreaseLimitMin(float value)
        {
            if (value <= 0) return;
            var oldData = data;
            data.SetMinLimit(data.MinValue - value);
            InvokeDataChangeEvents(oldData, data);
            OnDecreaseMinValue?.Invoke(value);
        }
        
        
        public void IncreaseLimitMax(float value)
        {
            if (value <= 0) return;
            var oldData = data;
            data.SetMaxLimit(data.MaxValue + value);
            InvokeDataChangeEvents(oldData, data);
            OnIncreaseMaxValue?.Invoke(value);
        }
        
        public void DecreaseLimitMax(float value)
        { 
            if (value <= 0) return;
            var oldData = data;
            data.SetMaxLimit(data.MaxValue - value);
            InvokeDataChangeEvents(oldData, data);
            OnDecreaseMaxValue?.Invoke(value);
        }
        
        
        private void InvokeIncreaseValueEvents(float increaseValue)
        {
            if (data.CheckValueIsMax)
                OnReachMaxValue?.Invoke();
            OnIncreaseValue?.Invoke(increaseValue);
        }
        
        private void InvokeDecreaseValueEvents(float decreaseValue)
        {
            if (data.CheckValueIsMin)
                OnReachMinValue?.Invoke();
            OnDecreaseValue?.Invoke(decreaseValue);
        }
        
        private void InvokeDataChangeEvents(ScoreCounterData oldData, ScoreCounterData currentData)
        {
            OnChangeData?.Invoke(currentData);
            OnChangeDataLastValue?.Invoke(oldData);

            if (!Mathf.Approximately(oldData.Value, currentData.Value))
            {
                OnChangeValue?.Invoke(currentData.Value);
                OnChangeValueLastValue?.Invoke(oldData.Value);
            }
            
            if (!Mathf.Approximately(oldData.ValueLimit.MinValue, currentData.ValueLimit.MinValue))
            {
                OnChangeLimitMin?.Invoke(currentData.ValueLimit.MinValue);
                OnChangeLimitMinLastValue?.Invoke(oldData.ValueLimit.MinValue);
            }
            
            if (!Mathf.Approximately(oldData.ValueLimit.MaxValue, currentData.ValueLimit.MaxValue))
            {
                OnChangeLimitMax?.Invoke(currentData.ValueLimit.MaxValue);
                OnChangeLimitMaxLastValue?.Invoke(oldData.ValueLimit.MaxValue);
            }
            
            if (!Mathf.Approximately(oldData.ValueLimit.MinValue, currentData.ValueLimit.MinValue)||
                !Mathf.Approximately(oldData.ValueLimit.MaxValue, currentData.ValueLimit.MaxValue))
            {
                OnChangeLimit?.Invoke(currentData.ValueLimit);
                OnChangeLimitLastValue?.Invoke(oldData.ValueLimit);
            }
        }
    }
}

// first assign limit values and then check if it is correct
// if passing the date by reference and changing it from outside the event will not work
// if you move the limits and go beyond the current account what will happen
// check if the date applies when you set it
// when the date changes, you need to trigger change events so that the ONdatachange visuals are updated
// if the values go beyond the data type in the limits

//problems if you change the value manually in the d inspector outside the logic, then it doesn’t work well
//what happens if you set values that fall outside the range of the data type
//test performance when changing the structure or creating a new one на производительность как лучше менять структуру или создавать новый объект 