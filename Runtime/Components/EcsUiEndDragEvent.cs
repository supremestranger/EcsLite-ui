using UnityEngine;
using UnityEngine.EventSystems;

namespace EcsLite.UI
{
    public struct EcsUiEndDragEvent
    {
        public string WidgetName;
        public GameObject Sender;
        public Vector2 Position;
        public int PointerId;
        public PointerEventData.InputButton Button;
    }
}