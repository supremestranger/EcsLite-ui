using UnityEditor;
using UnityEditor.UI;

namespace EcsLite.UI
{
    [CustomEditor (typeof (EcsUiNonVisualWidget), false)]
    [CanEditMultipleObjects]
    sealed class EcsUiNonVisualWidgetInspector : GraphicEditor {
        public override void OnInspectorGUI () {
            serializedObject.Update ();
            EditorGUILayout.PropertyField (m_Script);
            RaycastControlsGUI ();
            serializedObject.ApplyModifiedProperties ();
        }
    }
}