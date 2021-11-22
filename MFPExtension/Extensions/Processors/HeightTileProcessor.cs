using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Core;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.Map;
using MirenFalls.Internal.Utils;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MFPExtension.Extensions.Processors {
    [ContentProcessor(DisplayName = "HeightTileProcessor - MFPE")]
    public class HeightTileProcessor : ContentProcessor<Dictionary<string, string>, HeightTile> {

        string _range = "[0, 1]";


        public string HeightRange {
            get { return _range; }
            set { _range = value; }
        }


        public override HeightTile Process(Dictionary<string, string> input, ContentProcessorContext context) {
            Pipeline.Initialize();

            string directory = input.ContainsKey("directory") ? Path.Combine(Path.GetDirectoryName(input["filename"]), input["directory"]) : Path.GetDirectoryName(input["filename"]);

            string path = Path.Combine(directory, input["tileTexture"]);

            Tile tile = new Tile(new CompressibleTexture(path), Collision.None);

            Range range = input.ContainsKey("range") ? Range.FromString(input["range"]) : Range.FromString(_range);

            HeightTile heightTile = new HeightTile(tile, range);

            return heightTile;
        }
    }
}
