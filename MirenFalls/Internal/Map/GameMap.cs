using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Map {

    using Internal.Graphics;

    // Fancy data container that stores an array of the current tiles and renders them to the background.

    public class GameMap {
        public int width;
        public int height;

        public Biome[,] biomeArray;
        public Tilemap tilemap;

        public GameMap(int width, int height) {
            this.width = width;
            this.height = height;
            this.biomeArray = new Biome[width, height];
            this.tilemap = new Tilemap(width, height);
        }

        public void Initialize(string seed = null) {
            seed = seed != null ? seed : System.DateTime.Now.ToString();
            Procedural.InitState(seed);

            Procedural.InitializeMap(this);
        }

        public void Draw(SpriteBatch spriteBatch) {
            this.tilemap.Draw(spriteBatch);
        }
    }
}
