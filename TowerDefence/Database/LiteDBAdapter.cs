using System.Collections.Generic;
using LiteDB;
using TowerDefence.Database.Entities;

namespace TowerDefence.Database {
    public class LiteDBAdapter : IDatabaseAdapter {
        private readonly LiteRepository _repository;

        public LiteDBAdapter(LiteRepository repository) {
            _repository = repository;
        }

        public void Save(GameInfo entity) {
            _repository.Insert(entity);
        }

        public GameInfo Retrieve(string playerName) {
            return _repository.Query<GameInfo>().Where(o => o.PlayerName == playerName).FirstOrDefault();
        }

        public List<GameInfo> RetrieveAll() {
            return _repository.Query<GameInfo>().ToList();
        }
    }
}
