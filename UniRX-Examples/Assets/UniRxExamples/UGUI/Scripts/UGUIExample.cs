using System;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UniRxExamples.UGUI.Scripts
{
    public class UGUIExample : UIBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Slider slider;

        protected override void Start()
        {
            base.Start();
            Click();
            Slide();
        }

        private void Click()
        {
            button.onClick.AsObservable().Subscribe(x =>
            {
                var canClick = Math.Abs(button.GetComponent<Image>().color.a - 1f) < 0.01f;
                Debug.Log(canClick ? "clicked" : "make slider value 1 to click");
            }).AddTo(this);
        }
        
        private void Slide()
        {
            slider.OnValueChangedAsObservable()
                .Subscribe(x =>
                {
                    var image = button.GetComponent<Image>();
                    var color = image.color;
                    color.a = x;
                    image.color = color;
                }).AddTo(this);
        }

  
    }
}