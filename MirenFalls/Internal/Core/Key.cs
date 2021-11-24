using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace MirenFalls.Internal.Core {
    public class Key {
        public Keys real;

        public Key(string localization) {
        }

        public Key(Keys key) {
            real = key;
        }



    }
}
