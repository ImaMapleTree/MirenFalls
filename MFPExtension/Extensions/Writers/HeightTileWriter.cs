using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using MirenFalls.Internal.Map;
using MirenFalls.Internal.PipelineExtension;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFPExtension.Extensions.Writers {
    [ContentTypeWriter]
    class HeightTileWriter : ContentTypeWriter<HeightTile> {
        protected override void Write(ContentWriter output, HeightTile value) {
            output.Write(value.tile.texture.path);
            output.Write(value.heightRange.ToString());
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform) {
            return typeof(HeightTile).AssemblyQualifiedName;
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform) {
            return typeof(HeightTileReader).AssemblyQualifiedName;
        }
    }
}
