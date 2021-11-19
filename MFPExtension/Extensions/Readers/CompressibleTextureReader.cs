using Microsoft.Xna.Framework.Content;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFPExtension.Extensions.Readers {
    public class CompressibleTextureReader : ContentTypeReader<CompressibleTexture> {
        protected override CompressibleTexture Read(ContentReader input, CompressibleTexture existingInstance) {
            Debug.Log("I WANNA DIE!!!");
            CompressibleTexture weapon = existingInstance;
           

            if (weapon == null) {
                weapon = new CompressibleTexture();
            }

            return weapon;
        }
    }
}
