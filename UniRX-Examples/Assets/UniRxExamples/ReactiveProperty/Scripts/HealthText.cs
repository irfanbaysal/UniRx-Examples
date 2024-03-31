using Cysharp.Threading.Tasks;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UniRxExamples.ReactiveProperty.Scripts
{
    public class HealthText : UIBehaviour
    {
        [SerializeField] private ReactivePropertyExample reactivePropertyExample;
        [SerializeField] private TextMeshProUGUI healthTMP;

        protected override void OnEnable()
        {
            base.OnEnable();
            reactivePropertyExample.healthPoints.Subscribe(value =>
            {
                healthTMP.SetText($"Health :{value}");
                healthTMP.color = value switch
                {
                    <= 25 => Color.red,
                    <= 50 => Color.yellow,
                    _ => healthTMP.color
                };
            });
        }
    }
}