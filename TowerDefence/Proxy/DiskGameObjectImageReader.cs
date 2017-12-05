using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace TowerDefence.Proxy {
    public class DiskGameObjectImageReader : IGameObjectImageReader {
        public Dictionary<string, Image> GetGameObjectImages() {
            var map = new Dictionary<string, Image>();

            foreach (var imageName in new [] {"archerTower.png", "beast.png", "canonTower.png", "dragon.png", "heavyBullet.png", "simpleBullet.png"}) {
                var image = Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"pics/{imageName}"));
                map.Add(imageName.Substring(0, imageName.Length - ".png".Length), image);
            }

            return map;
        }

        public Image GetGameObjectImage(string name) {
            return Image.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"pics/{name}.png"));
        }
    }
}
