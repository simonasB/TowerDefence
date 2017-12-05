using System.Collections.Generic;
using System.Drawing;

namespace TowerDefence.Proxy {
    public class GameObjectImageCacheProxy : IGameObjectImageReader {
        private readonly IGameObjectImageReader _gameObjectImageReader;
        private Dictionary<string, Image> _cache;

        public GameObjectImageCacheProxy() {
            _gameObjectImageReader = new DiskGameObjectImageReader();
            _cache = new Dictionary<string, Image>();
        }


        public Dictionary<string, Image> GetGameObjectImages() {
            if (_cache.Count == 0) {
                _cache = _gameObjectImageReader.GetGameObjectImages();
            }

            return _cache;
        }

        public Image GetGameObjectImage(string name) {
            if (_cache.TryGetValue(name, out var image)) {
                return image;
            }

            image = _gameObjectImageReader.GetGameObjectImage(name);

            return image;
        }
    }
}
