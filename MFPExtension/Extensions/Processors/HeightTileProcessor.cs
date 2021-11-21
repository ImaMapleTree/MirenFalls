using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Map;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFPExtension.Extensions.Processors {
    [ContentProcessor(DisplayName = "HeightTileProcessor - MFPE")]
    public class HeightTileProcessor : ContentProcessor<HeightTile, HeightTile> {
        public override HeightTile Process(HeightTile input, ContentProcessorContext context) {
            return input;
        }
    }
}
