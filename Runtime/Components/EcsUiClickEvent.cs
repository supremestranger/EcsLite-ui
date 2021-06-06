using UnityEngine;
using UnityEngine.EventSystems;

namespace EcsLite.UI
{
    public struct EcsUiClickEvent
    {
        public string WidgetName;
        public GameObject Sender;
        public Vector2 Position;
        public PointerEventData.InputButton Button;
    }
}
