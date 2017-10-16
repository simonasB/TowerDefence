using System;
using LiteDB;

namespace TowerDefence.Database.Entities {
    public class GameInfo {
        [BsonId]
        public Guid Id { get; set; }
        public string PlayerName { get; set; }
    }
}
