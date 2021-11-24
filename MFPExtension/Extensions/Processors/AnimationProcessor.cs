using Microsoft.Xna.Framework.Content.Pipeline;
using MirenFalls.Internal.Graphics;

namespace MFPExtension.Extensions.Processors {
    [ContentProcessor(DisplayName = "AnimationProcessor - MFPE")]
    public class AnimationProcessor : ContentProcessor<Animation, Animation> {
        public override Animation Process(Animation input, ContentProcessorContext context) {
            return input;
        }
    }
}