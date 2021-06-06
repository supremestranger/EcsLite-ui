using UnityEngine;
using UnityEngine.EventSystems;

namespace EcsLite.UI
{
    public struct EcsUiDropEvent
    {
        public string WidgetName;
        public GameObject Sender;
        public PointerEventData.InputButton Button;
    }
}