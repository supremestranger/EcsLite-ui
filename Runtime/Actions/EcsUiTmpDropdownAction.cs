using TMPro;
using UnityEngine;

namespace EcsLite.UI
{
    [RequireComponent (typeof (TMP_Dropdown))]
    public sealed class EcsUiTmpDropdownAction : EcsUiActionBase
    {
        TMP_Dropdown _dropdown;

        void Awake ()
        {
            _dropdown = GetComponent<TMP_Dropdown>();
            _dropdown.onValueChanged.AddListener(OnDropdownValueChanged);
        }

        void OnDropdownValueChanged (int value)
        {
            if (IsValidForEvent())
            {
                ref var msg = ref Emitter.CreateEntity<EcsUiTmpDropdownChangeEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = _dropdown;
                msg.Value = value;
            }
        }
    }
}