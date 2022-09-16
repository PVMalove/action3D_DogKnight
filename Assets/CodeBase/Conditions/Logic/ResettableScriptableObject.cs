using UnityEngine;

namespace CodeBase.Conditions.Logic
{
    public abstract class ResettableScriptableObject : ScriptableObject
    {
        public abstract void Reset();
    }
}