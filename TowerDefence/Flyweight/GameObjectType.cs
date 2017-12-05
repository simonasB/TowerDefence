using System.Drawing;

namespace TowerDefence.Common {
    public class GameObjectType {
        private readonly string _name;
        private readonly Image _image;

        public GameObjectType(string name, Image image) {
            _name = name;
            _image = image;
        }

        public void Draw(Graphics gfx, int x, int y, int width, int height) {
            gfx.DrawImageUnscaled(_image, x, y, width, height);
        }
    }
}
