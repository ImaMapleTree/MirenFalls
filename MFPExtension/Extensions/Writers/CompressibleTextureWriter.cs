using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using MirenFalls.Internal.Graphics;
using MirenFalls.Internal.PipelineExtension;
using System;
using System.Collections.Generic;
using System.Text;

namespace MFPExtension.Extensions.Writers {
    [ContentTypeWriter]
    public class CompressibleTextureWriter : ContentTypeWriter<CompressibleTexture> {
        protected override void Write(ContentWriter output, CompressibleTexture value) {
            output.Write(value.path);
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform) {
            return typeof(CompressibleTexture).AssemblyQualifiedName;
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform) {
            return typeof(CompressibleTextureReader).AssemblyQualifiedName;
        }
    }
}
