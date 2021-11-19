using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFPExtension.Extensions.Spritesheet {
    public class SpriteSheetShell {
        public SpriteSheetShell() { }
        public TextureAtlasShell textureAtlas { set; get; }
        public Dictionary<string, SpriteSheetAnimationCycle> cycles { set; get; }

        public SpriteSheet Identify(GraphicsDevice gd) {
            SpriteSheet spriteSheet = new SpriteSheet();
            spriteSheet.TextureAtlas = TextureAtlas.Create("atlas", Texture2D.FromFile(gd, textureAtlas.texture), textureAtlas.regionWidth, textureAtlas.regionHeight);
            spriteSheet.Cycles = cycles;
            return spriteSheet;
        }

    }
}
