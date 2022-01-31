using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
public class TestShakeCamera : MonoBehaviour
{
   [SerializeField] private float amplitudeGainMin = 1;
   [SerializeField] private float amplitudeGainMax = 1;
   
   [SerializeField] private float frequencyGain = 1;

   [SerializeField] private AnimationCurve amplitudeGainCurveStart = AnimationCurve.Constant(0,1,1);
   [SerializeField] private AnimationCurve amplitudeGainCurveEnd = AnimationCurve.Constant(0,1,1);
   [SerializeField] private AnimationCurve frequencyGainCurveStart = AnimationCurve.Constant(0,1,1);
   [SerializeField] private AnimationCurve frequencyGainCurveEnd = AnimationCurve.Constant(0,1,1);
   
   public UnityEvent startShakeEvent;
   public UnityEvent stopShakeEvent;
   public UnityEvent isMinShakeEvent;
   public UnityEvent isMaxShakeEvent;
   
   private Coroutine shakeCoroutine;
   private CinemachineVirtualCamera cinemachineVirtualCamera;
   private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;
   
   private void Awake()
   {
      cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
      cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
   }
   
   public void StartShake()
   {
      startShakeEvent?.Invoke();
      cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = amplitudeGainMin;
      //cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frequencyGain;
   }
   
   public void StartShake(float time)
   {
      shakeCoroutine = StartCoroutine( ShakeCameraTimerCor(time, amplitudeGainCurveStart));
   }
   
   public void StopShake()
   {
      stopShakeEvent?.Invoke();
      cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
      //cinemachineBasicMultiChannelPerlin.m_FrequencyGain = 0;
   }
   
   public void StopShake(float time)
   {
      shakeCoroutine = StartCoroutine( ShakeCameraTimerCor(time, amplitudeGainCurveEnd));
   }
   
   private IEnumerator ShakeCameraTimerCor(float seconds, AnimationCurve curve)
   {
      float elapsedTime = 0;
      while (elapsedTime < seconds)
      {
         elapsedTime += Time.deltaTime;
         float percent = elapsedTime / seconds;

        
            float amplitude = amplitudeGainMin * curve.Evaluate(percent);
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = amplitude;
            
            
         yield return new WaitForEndOfFrame();
      }
   }
   
   
}
