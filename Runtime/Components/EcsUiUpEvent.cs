using UnityEngine;
using UnityEngine.EventSystems;

namespace EcsLite.UI
{
    public struct EcsUiUpEvent
    {
        public string WidgetName;
        public GameObject Sender;
        public Vector2 Position;
        public int PointerId;
        public PointerEventData.InputButton Button;
    }
}