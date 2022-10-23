using CodeBase.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;

namespace CodeBase.Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void Load();
        EnemyStaticData ForEnemy(EnemyTypeID typeID);
        LevelStaticData ForLevel(string key);
        WindowConfig ForWindow(WindowID shop);
    }
}