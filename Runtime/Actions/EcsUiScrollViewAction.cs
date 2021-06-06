using UnityEngine;
using UnityEngine.UI;

namespace EcsLite.UI
{
    [RequireComponent (typeof (ScrollRect))]
    public sealed class EcsUiScrollViewAction : EcsUiActionBase
    {
        ScrollRect _scrollView;

        void Awake()
        {
            _scrollView = GetComponent<ScrollRect>();
            _scrollView.onValueChanged.AddListener(OnScrollViewValueChanged);
        }

        void OnScrollViewValueChanged(Vector2 value)
        {
            if (IsValidForEvent())
            {
                ref var msg = ref Emitter.CreateEntity<EcsUiScrollViewEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = _scrollView;
                msg.Value = value;
            }
        }
    }
}