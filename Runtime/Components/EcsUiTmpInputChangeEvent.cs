using TMPro;

namespace EcsLite.UI
{
    public struct EcsUiTmpInputChangeEvent
    {
        public string WidgetName;
        public TMP_InputField Sender;
        public string Value;
    }
}