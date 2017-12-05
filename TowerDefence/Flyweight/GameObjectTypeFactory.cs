using TowerDefence.Common;
using TowerDefence.Proxy;

namespace TowerDefence.Flyweight {
    public class GameObjectTypeFactory {
        private static GameObjectTypeProvider _gameObjectTypeProvider;

        public static GameObjectType GetGameObjectType(string name) {
            if (_gameObjectTypeProvider == null) {
                var proxy = new GameObjectImageCacheProxy();
                proxy.GetGameObjectImages();
                _gameObjectTypeProvider = new GameObjectTypeProvider(proxy);
            }

            return _gameObjectTypeProvider.GetGameOjObjectType(name);
        }
     }
}
