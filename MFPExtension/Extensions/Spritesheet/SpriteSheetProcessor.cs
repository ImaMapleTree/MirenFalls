using System;
using System.Collections.Generic;
using MFPExtension.Extensions.Biome;
using Microsoft.Xna.Framework.Content.Pipeline;
using MonoGame.Extended.Sprites;

namespace MFPExtension.Extensions.Spritesheet {
    [ContentProcessor(DisplayName = "SpriteSheetProcessor - MFPE")]
    public class SpriteSheetProcessor : ContentProcessor<SpriteSheetShell, SpriteSheetShell> {
        public override SpriteSheetShell Process(SpriteSheetShell input, ContentProcessorContext context) {
            return input;
        }
    }
}