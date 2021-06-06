using UnityEngine.EventSystems;

namespace EcsLite.UI
{
    public sealed class EcsUiDropAction : EcsUiActionBase, IDropHandler
    {
        void IDropHandler.OnDrop(PointerEventData eventData)
        {
            if (IsValidForEvent())
            {
                ref var msg = ref Emitter.CreateEntity<EcsUiDropEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = gameObject;
                msg.Button = eventData.button;
            }
        }
    }
}