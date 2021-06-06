using UnityEngine.EventSystems;

namespace EcsLite.UI
{
    public sealed class EcsUiDownUpAction : EcsUiActionBase, IPointerDownHandler, IPointerUpHandler
    {
        void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
        {
            if (IsValidForEvent())
            {
                ref var msg = ref Emitter.CreateEntity<EcsUiDownEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = gameObject;
                msg.Position = eventData.position;
                msg.PointerId = eventData.pointerId;
                msg.Button = eventData.button;
            }
        }

        void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
        {
            if (IsValidForEvent())
            {
                ref var msg = ref Emitter.CreateEntity<EcsUiUpEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = gameObject;
                msg.Position = eventData.position;
                msg.PointerId = eventData.pointerId;
                msg.Button = eventData.button;
            }
        }
    }
}