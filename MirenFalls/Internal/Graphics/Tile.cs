using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Graphics {
    public enum Collision {
        None = 0, // Any collidable can move through
        Player = 1, // Player cannot move through
        Nonplayer = 2, // Any non player cannot move through
    }

    public class Tile {
        public CompressibleTexture texture;
        public Collision collision;
        public int width;
        public int height;

        public Vector2 size;

        public Tile() {
        }


        public Tile(CompressibleTexture texture, Collision collision) {
            this.texture = texture;
            this.collision = collision;
            this.width = this.texture.Width;
            this.height = this.texture.Height;
            this.size = new Vector2(this.width, this.height);
        }
    }
}
