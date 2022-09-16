using UnityEditor;
using UnityEngine;

namespace CodeBase.Conditions.Logic
{
    [CustomEditor(typeof(Condition))]
    public class ConditionEditor : Editor
    {
        private const string Satisfied = "IsSatisfied";

        public override void OnInspectorGUI()
        {
            Condition condition = (Condition)target;

            GUILayout.BeginHorizontal(GUI.skin.box);
            condition.Description = GUILayout.TextField(condition.Description);

            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            GUILayout.Label(Satisfied);
            condition.IsSatisfied = EditorGUILayout.Toggle(condition.IsSatisfied);

            GUILayout.EndHorizontal();
        }
    }
}