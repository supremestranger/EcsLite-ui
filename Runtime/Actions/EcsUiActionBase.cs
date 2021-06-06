using System;
using UnityEngine;

namespace EcsLite.UI
{
    enum EcsUiActionNameRegistrationType {
        None,
        OnAwake,
        OnStart
    }
    
    public abstract class EcsUiActionBase : MonoBehaviour
    {
        [SerializeField] protected string WidgetName = null;
        
        [SerializeField] protected EcsUiEmitter Emitter = null;

        [SerializeField] EcsUiActionNameRegistrationType _nameRegistrationType = EcsUiActionNameRegistrationType.None;

        [SerializeField] UnityEngine.UI.Selectable _selectable = null;

        private void Awake()
        {
            if (_nameRegistrationType == EcsUiActionNameRegistrationType.OnAwake) {
                ValidateEmitter();
                RegisterName(true);
            }
        }

        private void Start()
        {
            ValidateEmitter();
            if (_nameRegistrationType == EcsUiActionNameRegistrationType.OnStart) {
                RegisterName(true);
            }
        }

        private void OnDestroy()
        {
            RegisterName(false);
        }

        private void RegisterName(bool state)
        {
            if (Emitter)
            {
                Emitter.SetNamedObject(WidgetName, state ? gameObject : null);
            }
        }
        
        protected bool IsValidForEvent ()
        {
            return Emitter && Emitter.GetWorld().IsAlive () && (_selectable == null || _selectable.interactable);
        }

        private void ValidateEmitter()
        {
            if (Emitter == null)
            {
                Emitter = GetComponentInParent<EcsUiEmitter> ();
            }
#if DEBUG
            if (Emitter == null)
            {
                Debug.LogError("EcsUiEmitter not found in hierarchy", this);
            }
#endif
        }
        
        public static T AddAction<T>(GameObject go, string widgetName = null, EcsUiEmitter emitter = null) where T : EcsUiActionBase
        {
            var action = go.AddComponent<T> ();
            if (widgetName != null) {
                action.WidgetName = widgetName;
                action._nameRegistrationType = EcsUiActionNameRegistrationType.OnStart;
            }
            action.Emitter = emitter;
            return action;
        }
    }
}