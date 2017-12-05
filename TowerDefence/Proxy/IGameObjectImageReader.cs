using System.Collections.Generic;
using System.Drawing;

namespace TowerDefence.Proxy {
    public interface IGameObjectImageReader {
        Dictionary<string, Image> GetGameObjectImages();
        Image GetGameObjectImage(string name);
    }
}
