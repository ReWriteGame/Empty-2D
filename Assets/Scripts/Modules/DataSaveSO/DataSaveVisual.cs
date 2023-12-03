using UnityEngine;
using TMPro;

public class DataSaveVisual : MonoBehaviour
{
    [SerializeField] private DataSave dataSave;
    [SerializeField] private TextMeshProUGUI lastScoreLabel;
    [SerializeField] private TextMeshProUGUI heightScoreLabel;
    [SerializeField] private TextMeshProUGUI allScoreLabel;
    
    private void Start() => dataSave.OnUpdateData += UpdateTextVisual;
    private void OnDestroy() => dataSave.OnUpdateData -= UpdateTextVisual;
    private void OnEnable() => UpdateTextVisual();
    
    private void UpdateTextVisual()
    {
        if (lastScoreLabel) lastScoreLabel.text = $"{dataSave.LastScore}";
        if (heightScoreLabel) heightScoreLabel.text = $"{dataSave.HeightScore}";
        if (allScoreLabel) allScoreLabel.text = $"{dataSave.AllScore}";
    }
}