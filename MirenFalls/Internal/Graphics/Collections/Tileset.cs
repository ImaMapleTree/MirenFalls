using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Map.Collections {
    public class Tileset {
        public List<HeightTile> biomeTiles;
        public List<MultiTile> biomeObjects;


        public Tileset() {
            this.biomeTiles = new List<HeightTile>();
            this.biomeObjects = new List<MultiTile>();
        }

        public Tileset(List<HeightTile> biomeTiles, List<MultiTile> biomeObjects) {
            this.biomeTiles = biomeTiles;
            this.biomeObjects = biomeObjects;
        }

        public void AddHeightTile(HeightTile tile) {
            this.biomeTiles.Add(tile);
        }

        public void AddMultiTile(MultiTile multiTile) {
            this.biomeObjects.Add(multiTile);
        }

    }
}
