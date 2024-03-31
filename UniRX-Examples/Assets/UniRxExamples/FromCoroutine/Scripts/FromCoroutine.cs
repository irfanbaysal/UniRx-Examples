using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace UniRxExamples.NetworkExample
{
    public class FromCoroutine : MonoBehaviour
    {
        [SerializeField] private bool toggleMe;

        private IDisposable _coroutineDisposable;
        
        public void Start()
        {
            _coroutineDisposable = Observable.FromCoroutine(CRWaitToggleMe)
                .SelectMany(CRWaitUnToggleMe)
                .Subscribe().AddTo(this);

        }

        private IEnumerator CRWaitToggleMe()
        {
            Debug.Log("wait toggle me starts");
            yield return new WaitUntil(()=>toggleMe);
            Debug.Log("wait toggle me ends");
        }


        private IEnumerator CRWaitUnToggleMe()
        {
            yield return new WaitForSeconds(1f);
            Debug.Log("wait untoggle me starts");
            yield return new WaitUntil(()=>!toggleMe);       
            Debug.Log("wait untoggle me ends");
            Dispose();
        }

        private void Dispose()
        {
            _coroutineDisposable.Dispose();    
        }
    }
}