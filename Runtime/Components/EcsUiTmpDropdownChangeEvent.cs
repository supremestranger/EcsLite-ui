using TMPro;

namespace EcsLite.UI
{
    public struct EcsUiTmpDropdownChangeEvent
    {
        public string WidgetName;
        public TMP_Dropdown Sender;
        public int Value;
    }
}