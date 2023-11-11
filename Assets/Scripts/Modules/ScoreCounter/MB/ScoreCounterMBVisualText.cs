using Modules.Score.Visual;
using UnityEngine;

[RequireComponent(typeof(ScoreCounterVisualText))]
public class ScoreCounterMBVisualText : MonoBehaviour
{
  [SerializeField] private ScoreCounterMB counterMB;
  [SerializeField] private ScoreCounterVisualText counterVisualMB;

  private void Awake() =>  counterVisualMB.SetScoreCounter(counterMB.ScoreCounter);
}
