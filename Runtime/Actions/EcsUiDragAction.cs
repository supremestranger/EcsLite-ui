using UnityEngine.EventSystems;

namespace EcsLite.UI
{
    public sealed class EcsUiDragAction : EcsUiActionBase, IBeginDragHandler, IDragHandler, IEndDragHandler {
        void IBeginDragHandler.OnBeginDrag(PointerEventData eventData) {
            if (IsValidForEvent ()) {
                ref var msg = ref Emitter.CreateEntity<EcsUiBeginDragEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = gameObject;
                msg.Position = eventData.position;
                msg.PointerId = eventData.pointerId;
                msg.Button = eventData.button;
            }
        }

        void IDragHandler.OnDrag(PointerEventData eventData) {
            if (IsValidForEvent ()) {
                ref var msg = ref Emitter.CreateEntity<EcsUiDragEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = gameObject;
                msg.Position = eventData.position;
                msg.PointerId = eventData.pointerId;
                msg.Delta = eventData.delta;
                msg.Button = eventData.button;
            }
        }

        void IEndDragHandler.OnEndDrag(PointerEventData eventData) {
            if (IsValidForEvent ()) {
                ref var msg = ref Emitter.CreateEntity<EcsUiEndDragEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = gameObject;
                msg.Position = eventData.position;
                msg.PointerId = eventData.pointerId;
                msg.Button = eventData.button;
            }
        }
    }
}