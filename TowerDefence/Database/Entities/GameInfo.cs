using System;
using LiteDB;

namespace TowerDefence.Database.Entities {
    public class GameInfo {
        [BsonId]
        public Guid Id { get; set; }
        public string PlayerName { get; set; }
        public int Level { get; set; }
        public int Points { get; set; }
        public int Life { get; set; }
        public decimal Money { get; set; }
    }
}
