using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MirenFalls.Internal.Graphics {
    public class TextureRegion {

        public Texture2D texture;
        public int x;
        public int y;
        public int width;
        public int height;
        public Rectangle bounds;

        public TextureRegion() { }

        public TextureRegion(Texture2D texture, int x, int y, int width, int height) {
            this.texture = texture;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.bounds = new Rectangle(x, y, width, height);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position) {
            spriteBatch.Draw(texture, position, bounds, Color.White);
        }
    }
}
