using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using System.Collections.Generic;

namespace MFPExtension.Extensions.Shells {
    public class SpriteSheetShell {
        public SpriteSheetShell() { }
        public TextureAtlasShell textureAtlas { get; set; }
        public Dictionary<string, SpriteSheetAnimationCycle> cycles { get; set; }

        public SpriteSheet Identify(GraphicsDevice gd) {
            SpriteSheet spriteSheet = new SpriteSheet();
            spriteSheet.TextureAtlas = TextureAtlas.Create("atlas", Texture2D.FromFile(gd, textureAtlas.texture), textureAtlas.regionWidth, textureAtlas.regionHeight);
            spriteSheet.Cycles = cycles;
            return spriteSheet;
        }

    }
}
