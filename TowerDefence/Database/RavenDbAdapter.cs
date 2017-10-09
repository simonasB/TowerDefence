using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client;
using TowerDefence.Database.Entities;

namespace TowerDefence.Database {
    public class RavenDbAdapter : IDatabaseAdapter {
        private readonly IDocumentStore _store;

        public RavenDbAdapter(IDocumentStore store) {
            _store = store;
        }
        public void Save(GameInfo entity) {
            using (IDocumentSession session = _store.OpenSession()) {
                session.Store(entity);
                session.SaveChanges();
            }
        }

        public GameInfo Retrieve(string playerName) {
            using (IDocumentSession session = _store.OpenSession()) {
                return session.Query<GameInfo>().FirstOrDefault(o => o.PlayerName == playerName);
            }
        }

        public List<GameInfo> RetrieveAll() {
            using (IDocumentSession session = _store.OpenSession()) {
                return session.Load<GameInfo>().ToList();
            }
        }
    }
}
