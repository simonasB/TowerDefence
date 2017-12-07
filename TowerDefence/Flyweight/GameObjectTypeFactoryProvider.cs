using TowerDefence.Common;
using TowerDefence.Proxy;

namespace TowerDefence.Flyweight {
    public class GameObjectTypeFactoryProvider {
        private static GameObjectTypeFactory _gameObjectTypeFactory;

        public static GameObjectType GetGameObjectType(string name) {
            if (_gameObjectTypeFactory == null) {
                var proxy = new GameObjectImageCacheProxy();
                proxy.GetGameObjectImages();
                _gameObjectTypeFactory = new GameObjectTypeFactory(proxy);
            }

            return _gameObjectTypeFactory.GetGameOjObjectType(name);
        }
     }
}
