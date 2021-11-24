using MirenFalls.Internal.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Graphics {
    public class Tileset {
        public List<HeightTile> biomeTiles;
        public List<MultiTile> biomeObjects;


        public Tileset() {
            biomeTiles = new List<HeightTile>();
            biomeObjects = new List<MultiTile>();
        }

        public Tileset(List<HeightTile> biomeTiles, List<MultiTile> biomeObjects) {
            this.biomeTiles = biomeTiles;
            this.biomeObjects = biomeObjects;
        }

        public void AddHeightTile(HeightTile tile) {
            biomeTiles.Add(tile);
        }

        public void AddMultiTile(MultiTile multiTile) {
            biomeObjects.Add(multiTile);
        }

    }
}
