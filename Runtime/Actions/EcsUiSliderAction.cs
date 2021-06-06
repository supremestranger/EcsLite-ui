using UnityEngine;
using UnityEngine.UI;

namespace EcsLite.UI
{
    [RequireComponent (typeof (Slider))]
    public sealed class EcsUiSliderAction : EcsUiActionBase
    {
        Slider _slider;

        void Awake ()
        {
            _slider = GetComponent<Slider>();
            _slider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        void OnSliderValueChanged (float value)
        {
            if (IsValidForEvent ())
            {
                ref var msg = ref Emitter.CreateEntity<EcsUiSliderChangeEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = _slider;
                msg.Value = value;
            }
        }
    }
}