using UnityEngine;
using UniRx;
using UnityEngine.Networking;

namespace UniRxExamples.NetworkExample
{
    public class ObserveEveryValueChangedExample : MonoBehaviour
    {
        [SerializeField] private int testValue;
        public void Start()
        {
            
            var obs = this.ObserveEveryValueChanged(_=>testValue);
            obs.Subscribe(x =>
            {
                Debug.LogError($"test value is = {x}");
            }).AddTo(this);
        }

    }
}