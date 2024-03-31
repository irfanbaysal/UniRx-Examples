using System;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace UniRxExamples.CompositeDisposableExample.Scripts
{
    public class CompositeDisposableExample : MonoBehaviour
    {
        private CompositeDisposable _compositeDisposable;
        
        private void Start()
        {
            CreateCompositeDisposable(ref _compositeDisposable);
            //ObserveEveryUpdate();
            //TakeUntilDisable();
           
        }

        private void OnDestroy()
        {
            DisposeCompositeDisposable(_compositeDisposable);
        }

        private void ObserveEveryUpdate()
        {
            Observable.EveryUpdate().Subscribe(x =>
            {
                Debug.Log($"Frame {x}");
            }).AddTo(_compositeDisposable);
        }

        private void TakeUntilDisable()
        {
            Observable.IntervalFrame(60).TakeUntilDisable(this)
                .Subscribe(x => Debug.Log(x), () => Debug.Log("completed!"));
        }
        
        private void CreateCompositeDisposable(ref CompositeDisposable compositeDisposable)
        {
            compositeDisposable?.Dispose();
            compositeDisposable = new();
        }
        
        private void DisposeCompositeDisposable(CompositeDisposable compositeDisposable)
        {
            if (compositeDisposable == null) return;
            if (compositeDisposable.IsDisposed) return;
            compositeDisposable.Dispose();
        }
        
        [Button]
        private void CreateCompositeDisposableButton()
        {
            CreateCompositeDisposable(ref _compositeDisposable);
            ObserveEveryUpdate();
        }


        [Button]
        private void DisposeCompositeDisposableButton()
        {
            DisposeCompositeDisposable(_compositeDisposable);
        }
        
        
    }
}