using System;
using System.Collections.Generic;
using TowerDefence.Database.Entities;

namespace TowerDefence.Database {
    public class NullDatabaseAdapter : IDatabaseAdapter{
        public void Save(GameInfo entity) {
            Logger.Instance().GetLogger().Info("Game info is saved to database");
        }

        public GameInfo Retrieve(string playerName) {
            Logger.Instance().GetLogger().Info("Game info retrieved from database");
            return new GameInfo {
                Id = Guid.NewGuid(),
                PlayerName = "Default game info"
            };
        }

        public List<GameInfo> RetrieveAll() {
            Logger.Instance().GetLogger().Info("Game info list retrieved from database");
            return new List<GameInfo> {
                new GameInfo {
                    Id = Guid.NewGuid(),
                    PlayerName = "Default game info list member"
                }
        };
        }
    }
}
