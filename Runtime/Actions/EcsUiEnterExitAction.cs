using UnityEngine.EventSystems;

namespace EcsLite.UI
{
    public sealed class EcsUiEnterExitAction : EcsUiActionBase, IPointerEnterHandler, IPointerExitHandler {
        void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
        {
            if (IsValidForEvent())
            {
                ref var msg = ref Emitter.CreateEntity<EcsUiEnterEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = gameObject;
            }
        }

        void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
        {
            if (IsValidForEvent())
            {
                ref var msg = ref Emitter.CreateEntity<EcsUiExitEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = gameObject;
            }
        }
    }
}