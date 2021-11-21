using Microsoft.Xna.Framework.Content;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.PipelineExtension {
    public class CompressibleTextureReader : ContentTypeReader<CompressibleTexture> {
        protected override CompressibleTexture Read(ContentReader input, CompressibleTexture existingInstance) {
            return new CompressibleTexture(input.ReadString());
        }
    }
}
