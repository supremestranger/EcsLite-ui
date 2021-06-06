using UnityEngine;
using UnityEngine.UI;

namespace EcsLite.UI
{
    public struct EcsUiScrollViewEvent
    {
        public string WidgetName;
        public ScrollRect Sender;
        public Vector2 Value;
    }
}