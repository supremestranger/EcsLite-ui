using UnityEngine;
using UnityEngine.EventSystems;

namespace EcsLite.UI
{
    public struct EcsUiBeginDragEvent
    {
        public string WidgetName;
        public GameObject Sender;
        public Vector2 Position;
        public int PointerId;
        public PointerEventData.InputButton Button;
    }
}