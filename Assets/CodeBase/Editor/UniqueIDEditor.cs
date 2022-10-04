using System.Linq;
using CodeBase.Logic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(UniqueID))]
    public class UniqueIDEditor : UnityEditor.Editor
    {
        private void OnEnable()
        {
            var uniqueID = (UniqueID)target;

            if (isPrefab(uniqueID))
                return;

            if (string.IsNullOrEmpty(uniqueID.ID))
                Generate(uniqueID);
            else
            {
                UniqueID[] uniqueIds = FindObjectsOfType<UniqueID>();

                if (uniqueIds.Any(other => other != uniqueID && other.ID == uniqueID.ID))
                    Generate(uniqueID);
            }
        }

        private bool isPrefab(UniqueID uniqueID) =>
            uniqueID.gameObject.scene.rootCount == 0;

        private void Generate(UniqueID uniqueID)
        {
            uniqueID.GenerateId();

            if (!Application.isPlaying)
            {
                EditorUtility.SetDirty(uniqueID);
                EditorSceneManager.MarkSceneDirty(uniqueID.gameObject.scene);
            }
        }
    }
}