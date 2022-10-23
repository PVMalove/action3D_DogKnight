using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string StaticDataEnemyPath = "StaticData/Enemy";
        private const string StaticDataLevelsPath = "StaticData/Levels";
        private const string StaticDataWindowsPath = "StaticData/UI/WindowStaticData";
        
        private Dictionary<EnemyTypeID, EnemyStaticData> _enemies;
        private Dictionary<string, LevelStaticData> _levels;
        private Dictionary<WindowID,WindowConfig> _windowConfigs;

        public void Load()
        {
            _enemies = Resources
                .LoadAll<EnemyStaticData>(StaticDataEnemyPath)
                .ToDictionary(x => x.EnemyTypeID, x => x);

            _levels = Resources
                .LoadAll<LevelStaticData>(StaticDataLevelsPath)
                .ToDictionary(x => x.LevelKey, x => x);
            
            _windowConfigs = Resources
                .Load<WindowStaticData>(StaticDataWindowsPath)
                .Configs
                .ToDictionary(x => x.WindowID, x => x);
        }

        public EnemyStaticData ForEnemy(EnemyTypeID typeID) =>
            _enemies.TryGetValue(typeID, out EnemyStaticData staticData)
                ? staticData
                : null;

        public LevelStaticData ForLevel(string key) =>
            _levels.TryGetValue(key, out LevelStaticData staticData)
                ? staticData
                : null;

        public WindowConfig ForWindow(WindowID windowID) =>
            _windowConfigs.TryGetValue(windowID, out WindowConfig windowConfig)
                ? windowConfig
                : null;
    }
}