using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class UEvents : MonoBehaviour
{
   [SerializeField, Range(0, 30)] private float delayActivation = 0;

   public UnityEvent OnActivateEvent;

   public void Activate()
   {
      StartCoroutine(RespondCor());
   }

   private void CallEvent()
   {
      if (OnActivateEvent != null)
         OnActivateEvent.Invoke();
   }
   
   private IEnumerator RespondCor()
   {
      yield return new WaitForSeconds(delayActivation);
      CallEvent();
      yield break;
   }
}
