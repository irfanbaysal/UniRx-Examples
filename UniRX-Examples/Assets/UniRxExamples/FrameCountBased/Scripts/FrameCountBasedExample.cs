using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

namespace UniRxExamples.FrameCountBased.Scripts
{
    public class FrameCountBasedExample : MonoBehaviour
    {
        private void Awake()
        {
            //TimerFrame();
            //DelayFrame();
            //SampleFrame();
            //IntervalFrame();
            //ThrottleFrame();
            EveryUpdate();
        }

        private void TimerFrame()
        {
            Observable.TimerFrame(60).Subscribe(_ => Debug.Log("after 60 frame")).AddTo(this);
        }

        private void DelayFrame()
        {
            Observable.Range(1, 10).DelayFrame(60).Subscribe(value => Debug.Log($"Value: {value}")).AddTo(this);
        }
        
        private void SampleFrame()
        {
            Observable.Range(1, 10).SampleFrame(60).Subscribe(value => Debug.Log($"Value: {value}")).AddTo(this);
        }

        private void IntervalFrame()
        {
            Observable.IntervalFrame(30)
                .Subscribe(value => Debug.Log(value)).AddTo(this);
        }

        private void ThrottleFrame()
        {
             Observable.IntervalFrame(600)
            .ThrottleFrame(100).Subscribe(value => Debug.Log($"Value: {value} (emitted every 100 frames)")).AddTo(this);
        }
        
        
        private void EveryUpdate()
        {
            Observable.EveryUpdate().Subscribe(_ => Debug.Log("every update")).AddTo(this);
        }
    }
}