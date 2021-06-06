using System;
using System.Collections.Generic;
using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLite.UI
{
    public class EcsUiEmitter : MonoBehaviour
    {
        private EcsWorld _world;
        readonly Dictionary<int, GameObject> _actions = new Dictionary<int, GameObject> (64);
        
        public virtual EcsWorld GetWorld()
        {
            return _world;
        }

        internal void SetWorld(EcsWorld world)
        {
#if DEBUG
            if (_world != null) { throw new Exception ("World already attached."); }
#endif
            _world = world;
        }
        
        public virtual ref C CreateEntity<C>() where C : struct
        {
            ValidateEcsFields ();
            var newEntity = _world.NewEntity();
            var pool = _world.GetPool<C>();
            pool.Add(newEntity);
            return ref pool.Get(newEntity);
        }
        
        public virtual void SetNamedObject(string widgetName, GameObject go) {
            if (!string.IsNullOrEmpty (widgetName)) {
                var id = widgetName.GetHashCode ();
                if (_actions.ContainsKey (id)) {
                    if (!go) {
                        _actions.Remove (id);
                    } else {
                        throw new Exception ($"Action with \"{widgetName}\" name already registered");
                    }
                } else {
                    if ((object) go != null) {
                        _actions[id] = go.gameObject;
                    }
                }
            }
        }
        
        [System.Diagnostics.Conditional ("DEBUG")]
        private void ValidateEcsFields()
        {
#if DEBUG
            if (_world == null)
            {
                throw new Exception ("[EcsUiEmitter] Call EcsSystems.InjectUi() first.");
            }
#endif
        }

        public virtual GameObject GetNamedObject(string widgetName)
        {
            _actions.TryGetValue (widgetName.GetHashCode (), out var retVal);
            return retVal;
        }
    }
}