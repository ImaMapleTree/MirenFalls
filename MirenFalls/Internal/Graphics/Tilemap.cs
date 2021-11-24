using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MirenFalls.Internal.Core;
using MirenFalls.Internal.Core.Collections;
using MirenFalls.Internal.Map;

namespace MirenFalls.Internal.Graphics {
    public class Tilemap {

        private ShiftableArray<Tile> tileArray;
        public int width;
        public int height;

        public Vector2 tileSize = new Vector2(16, 16);

        public Vector2 drawPosition;
        
        public Tilemap(int width, int height) {
            this.width = width;
            this.height = height;
            tileArray = new ShiftableArray<Tile>(width, height);
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
            tileArray = new ShiftableArray<Tile>(width, height);
        }

        public void Shift(int x, int y) {
            tileArray.Shift(-x, y);
            drawPosition += new Vector2(tileSize.X * x, tileSize.Y * y);
        }

        public void Draw(SpriteBatch spritebatch) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    Tile tile = GetTile(x, y);
                    if (tile != null) {
                        Vector2 drawPos = new Vector2(x, y) * tile.size + drawPosition;
                        spritebatch.Draw(tile.texture, drawPos, Color.White);
                    }
                }
            }
        }

    }
}
