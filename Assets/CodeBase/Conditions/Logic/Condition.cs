using UnityEngine;

namespace CodeBase.Conditions.Logic
{
    [CreateAssetMenu(menuName = "Condition")]
    public class Condition : ResettableScriptableObject
    {
        public string Description = "New Description";

        public virtual bool IsSatisfied { get; set; } = false;

        public override void Reset()
        {
            IsSatisfied = false;
        }

        public virtual void Satisfy()
        {
            IsSatisfied = true;
        }
    }
}