using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Map {

    using Internal.Graphics;
    using MirenFalls.Internal.Core;
    using MirenFalls.Internal.Utils;

    // Fancy data container that stores an array of the current tiles and renders them to the background.

    public class GameMap {
        public int width;
        public int height;

        public Biome[,] biomeArray;
        public Tilemap tilemap;

        public VectorInt minBound;
        public VectorInt maxBound;

        public GameMap(int width, int height) {
            this.width = width;
            this.height = height;
            this.biomeArray = new Biome[width, height];
            this.tilemap = new Tilemap(width, height);
            minBound = new VectorInt(0, 0);
            maxBound = new VectorInt(width, height);
        }

        public void Initialize(string seed = null) {
            seed = seed != null ? seed : System.DateTime.Now.ToString();
            Procedural.InitState(seed);

            Procedural.InitializeMap(this);
        }

        public void Shift(VectorInt direction) {
            tilemap.Shift(direction.x, direction.y);
            Procedural.GenerateEdge(direction.x, direction.y);
            maxBound += direction;
            minBound += direction;
        }

        public void Draw(SpriteBatch spriteBatch) {
            this.tilemap.Draw(spriteBatch);
        }
    }
}
