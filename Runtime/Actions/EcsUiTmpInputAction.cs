using TMPro;
using UnityEngine;

namespace EcsLite.UI
{
    [RequireComponent (typeof (TMP_InputField))]
    public sealed class EcsUiTmpInputAction : EcsUiActionBase
    {
        TMP_InputField _input;

        void Awake () {
            _input = GetComponent<TMP_InputField> ();
            _input.onValueChanged.AddListener (OnInputValueChanged);
            _input.onEndEdit.AddListener (OnInputEnded);
        }

        void OnInputValueChanged (string value)
        {
            if (IsValidForEvent ())
            {
                ref var msg = ref Emitter.CreateEntity<EcsUiTmpInputChangeEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = _input;
                msg.Value = value;
            }
        }

        void OnInputEnded (string value)
        {
            if (IsValidForEvent())
            {
                ref var msg = ref Emitter.CreateEntity<EcsUiTmpInputEndEvent>();
                msg.WidgetName = WidgetName;
                msg.Sender = _input;
                msg.Value = value;
            }
        }
    }
}