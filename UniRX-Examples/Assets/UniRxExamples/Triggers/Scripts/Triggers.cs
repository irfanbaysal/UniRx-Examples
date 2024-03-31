using System;
using System.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;

namespace UniRxExamples.Triggers.Scripts
{
    public class Triggers : MonoBehaviour
    {
        [SerializeField] private GameObject examplePrefab;
        [SerializeField] private Button button;
        private GameObject _prefab;
        
        private void Start()
        {
            _prefab = Instantiate(examplePrefab, transform);
            _prefab.AddComponent<ObservableEnableTrigger>()
                .StartAsObservable()
                .Subscribe(OnEnableTrigger).AddTo(this);
            
            
            _prefab.AddComponent<ObservableDestroyTrigger>()
                .OnDestroyAsObservable().
                Subscribe(OnDestroyTrigger).AddTo(this);
            
            var trigger = button.gameObject.AddComponent<ObservableLongPointerDownTrigger>();

            trigger.OnLongPointerDownAsObservable().Subscribe(x=>Debug.Log(x));
            
        }

      
        private void OnDestroyTrigger(Unit x)
        {
            Debug.Log("destroyed");
        }

        private async void OnEnableTrigger(Unit x)
        {
            Debug.Log("created");
            try
            {
                await Task.Delay(TimeSpan.FromSeconds(3f));
              //  Destroy(_prefab.gameObject);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}