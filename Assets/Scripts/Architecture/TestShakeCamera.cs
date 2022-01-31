using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
public class TestShakeCamera : MonoBehaviour
{
   //[SerializeField] private float amplitudeGainMin = 1;
   [SerializeField] private float amplitudeGainMax = 1;
   //[SerializeField] private float frequencyGainMin = 1;
   [SerializeField] private float frequencyGainMax = 1;
   
   [SerializeField] private AnimationCurve amplitudeGainCurveStart = AnimationCurve.Constant(0,1,1);
   [SerializeField] private AnimationCurve amplitudeGainCurveEnd = AnimationCurve.Constant(0,1,1);
   [SerializeField] private AnimationCurve frequencyGainCurveStart = AnimationCurve.Constant(0,1,1);
   [SerializeField] private AnimationCurve frequencyGainCurveEnd = AnimationCurve.Constant(0,1,1);
   //[SerializeField] private AnimationCurve impulse = AnimationCurve.Constant(0,1,1);
   
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

      StopShake();
   }
   
 
   public void MoveToMin(float time)// добавить чистовой проход логика на амплитуде
   {
      float currentTimeCorrection = time - cinemachineBasicMultiChannelPerlin.m_AmplitudeGain / amplitudeGainMax * time;
      shakeCoroutine = StartCoroutine( ShakeCameraTimerCor(time, amplitudeGainCurveEnd, frequencyGainCurveEnd, currentTimeCorrection));
   }
   
   public void MoveToMax(float time)
   {
      float currentTimeCorrection = cinemachineBasicMultiChannelPerlin.m_AmplitudeGain / amplitudeGainMax * time;
      shakeCoroutine = StartCoroutine( ShakeCameraTimerCor(time, amplitudeGainCurveStart,frequencyGainCurveStart, currentTimeCorrection));
   }
   
   public void StopChangeShake()
   {
     if(shakeCoroutine != null) StopCoroutine(shakeCoroutine);
   }
   
 
   public void StopShake()
   {
      cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0;
      cinemachineBasicMultiChannelPerlin.m_FrequencyGain = 0;
   }
 
   private IEnumerator ShakeCameraTimerCor(float seconds, AnimationCurve amplitudeCurve, AnimationCurve frequencyCurve, float startTime = 0)
   {
      float elapsedTime = startTime;
      while (elapsedTime < seconds)
      {
         elapsedTime += Time.deltaTime;
         float percent = elapsedTime / seconds;
         
         float amplitude = amplitudeGainMax * amplitudeCurve.Evaluate(percent);
         cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = amplitude;
         
         float frequency = frequencyGainMax * frequencyCurve.Evaluate(percent);
         cinemachineBasicMultiChannelPerlin.m_FrequencyGain = frequency;
         
         yield return new WaitForEndOfFrame();
      }
   }
   
   
}
