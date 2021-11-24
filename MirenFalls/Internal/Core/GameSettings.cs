using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Core {
    public static class GameSettings {

        public static Dictionary<string, string> keyBindings;

        public static void Initialize() {
            keyBindings = Resources.loadJson<Dictionary<string, string>>("Content/Settings/key_bindings.json");
        }
    }
}
