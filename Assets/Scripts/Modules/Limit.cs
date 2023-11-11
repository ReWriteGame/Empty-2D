#region Version scripts = 1.1
#endregion

using System;
using UnityEngine;

namespace Modules.Score
{
    [Serializable]
    public struct Limit
    {
        [SerializeField] private float minValue;
        [SerializeField] private float maxValue;

        public float MinValue => minValue;
        public float MaxValue => maxValue;
        public float LengthLimit => Math.Abs(maxValue - minValue);

        public Limit(Limit limit)
        {
            this = limit;
            CheckRightValue();
        }
        
        public Limit(float minValue, float maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
            CheckRightValue();
        }

        private void CheckRightValue()
        {
            if (minValue > maxValue)
            {
                maxValue = minValue;
                ErrorAction();
            }
        }

        private void ErrorAction()
        {
            Debug.LogWarning("Class Limit: try set new object maxValue < minValue.Field MaxValue set as MinValue");
            //throw new ArgumentException();
        }
    }
}


