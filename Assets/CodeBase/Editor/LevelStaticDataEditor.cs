using System.Linq;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.Logic;
using CodeBase.Logic.EnemySpawners;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private const string StartingPointTeg = "StartingPoint";
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelData = (LevelStaticData)target;

            if (GUILayout.Button("Collect"))
            {
                levelData.EnemySpawners = FindObjectsOfType<SpawnMarker>()
                    .Select(x => new EnemySpawnerData(x.GetComponent<UniqueID>().ID, 
                        x.EnemyType, x.transform.position)).ToList();

                levelData.LevelKey = SceneManager.GetActiveScene().name;

                levelData.InitialHeroPosition = GameObject.FindWithTag(StartingPointTeg).transform.position;

            }

            EditorUtility.SetDirty(target);
        }
    }
}