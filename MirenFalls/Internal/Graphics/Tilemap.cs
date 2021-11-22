using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Core;
using MirenFalls.Internal.Map;
using MirenFalls.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Graphics {
    public class Tilemap {

        private Tile[,] tileArray;
        public int width;
        public int height;
        
        public Tilemap(int width, int height) {
            this.width = width;
            this.height = height;
            tileArray = new Tile[width, height];
        }

        public void AddTile(int x, int y, Tile tile) {
            tileArray[x, y] = tile;
        }

        public void AddTile(int x, int y, HeightTile tile) {
            tileArray[x, y] = tile.tile;
        }

        public Tile GetTile(int x, int y) {
            return tileArray[x, y];
        }

        public bool IsEmpty(int x, int y) {
            return tileArray[x, y] == null;
        }

        public bool IsEmptyTiles(VectorInt[] vectors) {
            foreach(VectorInt vector in vectors) {
                if (!IsEmpty(vector.x, vector.y)) return false;
            }
            return true;
        }

        public void ClearTiles() {
            tileArray = new Tile[width, height];
        }

        public void Draw(SpriteBatch spritebatch) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    Tile tile = GetTile(x, y);
                    if (tile != null) {
                        Vector2 drawPos = new Vector2(x, y) * tile.size;
                        spritebatch.Draw(tile.texture, drawPos, Color.White);
                    }
                }
            }
        }

    }
}
