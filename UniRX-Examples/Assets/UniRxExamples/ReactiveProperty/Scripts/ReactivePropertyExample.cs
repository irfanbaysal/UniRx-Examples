using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace UniRxExamples.ReactiveProperty.Scripts
{
    public class ReactivePropertyExample : MonoBehaviour
    {

        public ReactiveProperty<int> healthPoints = new();
        
        private void Start()
        {
            healthPoints.Subscribe(value =>
            {
                Debug.Log($"Health: {value}");
            });
        }
        
        [Button]
        public void TakeDamage(int damage)
        {
            healthPoints.Value -= damage;
            if (healthPoints.Value <= 0)
            {
                Debug.Log("Player Died!");
            }
        }

    }
}