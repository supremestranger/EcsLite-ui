using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Leopotam.EcsLite;
using UnityEngine;

namespace EcsLite.UI
{
    /// <summary>
    /// Marks field of IEcsSystem class to be injected with named UI object.
    /// </summary>
    public sealed class EcsUiNamedAttribute : Attribute
    {
        public readonly string Name;

        public EcsUiNamedAttribute(string name)
        {
            Name = name;
        }
    }

    public static class EcsSystemsExtensions
    {
        public static EcsSystems InjectUI(this EcsSystems ecsSystems, EcsUiEmitter emitter, bool skipNoExists = false,
            bool skipOneFrames = false)
        {
            if (!skipOneFrames) { InjectOneFrames(ecsSystems); }
            if (emitter.GetWorld() == null) { emitter.SetWorld(ecsSystems.GetWorld()); }
            var uiNamedType = typeof (EcsUiNamedAttribute);
            var goType = typeof (GameObject);
            var componentType = typeof (Component);
            var systems = ecsSystems.GetAllSystems();
            
            for (int i = 0, iMax = systems.Count; i < iMax; i++) {
                var system = systems[i];
                var systemType = system.GetType ();
                foreach (var f in systemType.GetFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)) {
                    // skip statics or fields without [EcsUiNamed] attribute.
                    if (f.IsStatic || !Attribute.IsDefined (f, uiNamedType)) {
                        continue;
                    }
                    var name = ((EcsUiNamedAttribute) Attribute.GetCustomAttribute (f, uiNamedType)).Name;
#if DEBUG
                    if (string.IsNullOrEmpty (name)) { throw new Exception ($"Cant Inject field \"{f.Name}\" at \"{systemType}\" due to [EcsUiNamed] \"Name\" parameter is invalid."); }
                    if (!(f.FieldType == goType || componentType.IsAssignableFrom (f.FieldType))) {
                        throw new Exception ($"Cant Inject field \"{f.Name}\" at \"{systemType}\" due to [EcsUiNamed] attribute can be applied only to GameObject or Component type.");
                    }
                    if (!skipNoExists && !emitter.GetNamedObject (name)) { throw new Exception ($"Cant Inject field \"{f.Name}\" at \"{systemType}\" due to there is no UI action with name \"{name}\"."); }
#endif
                    var go = emitter.GetNamedObject (name);
                    // GameObject.
                    if (f.FieldType == goType) {
                        f.SetValue (system, go);
                        continue;
                    }
                    // Component.
                    if (componentType.IsAssignableFrom (f.FieldType)) {
                        f.SetValue (system, go != null ? go.GetComponent (f.FieldType) : null);
                    }
                }
            }
            
            return ecsSystems;
        }

        public static List<IEcsSystem> GetAllSystems(this EcsSystems ecsSystems)
        {
            ParameterExpression ecsSystemsArg = Expression.Parameter(typeof(EcsSystems), "getAllSystems");
            Expression ecsSystemsAccessor = Expression.Field(ecsSystemsArg, "_allSystems");
            var lambda = Expression.Lambda<Func<EcsSystems, List<IEcsSystem>>>(ecsSystemsAccessor, ecsSystemsArg);
            var func = lambda.Compile();

            return func(ecsSystems);
        }

        private static void InjectOneFrames(EcsSystems ecsSystems)
        {
            ecsSystems.DelHere<EcsUiBeginDragEvent> ();
            ecsSystems.DelHere<EcsUiDragEvent> ();
            ecsSystems.DelHere<EcsUiEndDragEvent> ();
            ecsSystems.DelHere<EcsUiDropEvent> ();
            ecsSystems.DelHere<EcsUiClickEvent> ();
            ecsSystems.DelHere<EcsUiDownEvent> ();
            ecsSystems.DelHere<EcsUiUpEvent> ();
            ecsSystems.DelHere<EcsUiEnterEvent> ();
            ecsSystems.DelHere<EcsUiExitEvent> ();
            ecsSystems.DelHere<EcsUiScrollViewEvent> ();
            ecsSystems.DelHere<EcsUiSliderChangeEvent> ();
            ecsSystems.DelHere<EcsUiTmpDropdownChangeEvent> ();
            ecsSystems.DelHere<EcsUiTmpInputChangeEvent> ();
            ecsSystems.DelHere<EcsUiTmpInputEndEvent> ();
        }
    }
} 