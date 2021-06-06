using UnityEngine;
using UnityEngine.EventSystems;

namespace EcsLite.UI
{
    public sealed class EcsUiClickAction : EcsUiActionBase, IPointerClickHandler
    {
        [Range (1f, 2048f)]
        public float DragTreshold = 5f;

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            if ((eventData.pressPosition - eventData.position).sqrMagnitude < DragTreshold * DragTreshold)
            {
                if (IsValidForEvent())
                { 
                    ref var msg = ref Emitter.CreateEntity<EcsUiClickEvent>();
                    msg.WidgetName = WidgetName;
                    msg.Sender = gameObject;
                    msg.Position = eventData.position;
                    msg.Button = eventData.button;
                }
            }
        }
    }
}