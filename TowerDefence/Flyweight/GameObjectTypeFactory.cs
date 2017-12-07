using System.Collections.Generic;
using TowerDefence.Common;
using TowerDefence.Proxy;

namespace TowerDefence.Flyweight {
    public class GameObjectTypeFactory {
        private readonly IGameObjectImageReader _gameObjectImageReader;
        private readonly Dictionary<string, GameObjectType> _gameObjectTypes;

        public GameObjectTypeFactory(IGameObjectImageReader gameObjectImageReader) {
            _gameObjectImageReader = gameObjectImageReader;
            _gameObjectTypes = new Dictionary<string, GameObjectType>();
        }

        public GameObjectType GetGameOjObjectType(string name) {
            if (_gameObjectTypes.TryGetValue(name, out var gameObjectType)) {
                return gameObjectType;
            }

            gameObjectType = new GameObjectType(name, _gameObjectImageReader.GetGameObjectImage(name));

            _gameObjectTypes.Add(name, gameObjectType);

            return gameObjectType;
        }
    }
}
