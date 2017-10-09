using System.Collections.Generic;
using TowerDefence.Database.Entities;

namespace TowerDefence.Database {
    public interface IDatabaseAdapter {
        void Save(GameInfo entity);
        GameInfo Retrieve(string playerName);
        List<GameInfo> RetrieveAll();
    }
}
