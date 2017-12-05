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
            gfx.DrawImageUnscaled(new Bitmap(_image, new Size(width, height)), x, y, width, height);
        }
    }
}
