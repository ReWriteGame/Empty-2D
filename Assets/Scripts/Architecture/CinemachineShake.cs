using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CinemachineShake : MonoBehaviour
{
    [SerializeField] private float amplitudeGain = 1;
    [SerializeField] private float frequencyGain = 1;
    [SerializeField] private AnimationCurve amplitudeGainCurve = AnimationCurve.Constant(0,1,1);
    [SerializeField] private AnimationCurve frequencyGainCurve = AnimationCurve.Constant(0,1,1);
    //[SerializeField] private bool playOnAwake = false;//todo

    public UnityEvent OnStartShakeEvent;
    public UnityEvent OnStopShakeEvent;
    
    private Coroutine shakeCoroutine;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    
    public void ShakeCamera(float time)
    {
        shakeCoroutine = StartCoroutine( ShakeCameraTimerCor(time));
    }
    
    public void StartShake(float time)
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = amplitudeGain;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frequencyGain;
        OnStartShakeEvent?.Invoke();
    }
    
    public void StopShake()
    {
        StopCoroutine(shakeCoroutine);
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
        cinemachineBasicMultiChannelPerlin.m_FrequencyGain = 0;
        OnStopShakeEvent?.Invoke();
    }
    
    private IEnumerator ShakeCameraTimerCor(float seconds)
    {
        OnStartShakeEvent?.Invoke();
        float elapsedTime = 0;
        while (elapsedTime < seconds)
        {
            elapsedTime += Time.deltaTime;
            float percent = elapsedTime / seconds;
            float amplitude = amplitudeGain * amplitudeGainCurve.Evaluate(percent);
            float frequency = frequencyGain * frequencyGainCurve.Evaluate(percent);
            
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = amplitude;
            cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frequency;
            yield return new WaitForEndOfFrame();
        }
        StopShake();
    }
}
