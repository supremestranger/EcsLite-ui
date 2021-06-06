using UnityEngine.UI;

namespace EcsLite.UI
{
    public struct EcsUiSliderChangeEvent
    {
        public string WidgetName;
        public Slider Sender;
        public float Value;
    }
}