#region Version scripts = 0.1 // test script
#endregion

using System;
using TMPro;
using UnityEngine;

namespace Modules.Score.Visual
{
    public class ScoreCounterVisualText : MonoBehaviour 
    {
        [SerializeField] private Label valueLabel;
        [SerializeField] private Label valueMinLabel;
        [SerializeField] private Label valueMaxLabel;
        [SerializeField] private bool showValueInPercent = false;

        private ScoreCounter scoreCounter;

        public void SetScoreCounter(ScoreCounter scoreCounter)
        {
            if (this.scoreCounter != null) Unsubscribe();
            this.scoreCounter = scoreCounter;
            Subscribe();
            UpdateScore(scoreCounter.Value);
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            if (scoreCounter == null) return;
            scoreCounter.OnChangeValue += UpdateScore;
            scoreCounter.OnChangeLimitMin += UpdateLimitMin;
            scoreCounter.OnChangeLimitMax += UpdateLimitMax;
        }

        private void Unsubscribe()
        {
            if (scoreCounter == null) return;
            scoreCounter.OnChangeValue -= UpdateScore;
            scoreCounter.OnChangeLimitMin -= UpdateLimitMin;
            scoreCounter.OnChangeLimitMax -= UpdateLimitMax;
        }

        public void UpdateScore(float value)
        {
            ShowValue(valueLabel.label, value, valueLabel.textFormat, valueLabel.centerSymbol);
        }

        private void UpdateLimitMin(float value)
        {
            ShowValue(valueMinLabel.label, value, valueMinLabel.textFormat, valueMinLabel.centerSymbol);
        }

        private void UpdateLimitMax(float value)
        {
            ShowValue(valueMaxLabel.label, value, valueMaxLabel.textFormat, valueMaxLabel.centerSymbol);
        }

        private void ShowValue(TextMeshProUGUI label, float value, string format = "00.00", string replaceSymbol = ".")
        {
            if (label == null || scoreCounter == null) return;

            if (showValueInPercent) value = ShowInPercent(value, scoreCounter.MinValue, scoreCounter.MaxValue);
            string formatValue = value.ToString(format: $"{format}").Replace(",", $"{replaceSymbol}");
            label.text = formatValue;
        }
       
        private float ShowInPercent(float value, float minValue, float maxValue)
        {
            float sizeLimit = Mathf.Abs(maxValue - minValue);
            float valueInLimit = Mathf.Abs(value - minValue);
            float percentValue = sizeLimit / valueInLimit;
            return 100 / percentValue;
            //todo make this metods in scorecounter
        }

        [Serializable]
        private class Label
        {
            public TextMeshProUGUI label;
            public string textFormat = "00.00";
            public string centerSymbol = ".";
        }
    }
}

