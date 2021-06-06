using UnityEngine;
using UnityEngine.UI;

namespace EcsLite.UI
{
    [RequireComponent (typeof (CanvasRenderer))]
    [RequireComponent (typeof (RectTransform))]
    public class EcsUiNonVisualWidget : Graphic
    {
        public override void SetMaterialDirty () { }
        public override void SetVerticesDirty () { }
        public override Material material { get { return defaultMaterial; } set { } }
        public override void Rebuild (CanvasUpdate update) { }
    }
}