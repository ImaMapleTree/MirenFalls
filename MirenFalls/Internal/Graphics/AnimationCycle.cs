using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Graphics {
    public class AnimationCycle {
        public List<int> frames { get; set; }
        public bool isLooping { get; set; }
        public float frameDuration { get; set; }

    }
}
