using UnityEngine;
using UnityEngine.EventSystems;

namespace EcsLite.UI
{
    public struct EcsUiDragEvent
    {
        public string WidgetName;
        public GameObject Sender;
        public Vector2 Position;
        public int PointerId;
        public Vector2 Delta;
        public PointerEventData.InputButton Button;
    }
}