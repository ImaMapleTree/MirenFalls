using MirenFalls.Internal.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using static MirenFalls.Internal.Utils.Utilities;

namespace MirenFalls.Internal.Utils {

    public static class Debug {
        public static void Log(params object[] messages) {
            foreach (object message in messages) {
                string output;
                if (message != null) {
                    output = message.ToString();

                    if (IsList(message)) {
                        output = "[";

                        IList collection = (IList)message;

                        for (int i = 0; i < collection.Count; i++) {
                            output += collection[i].ToString();
                            if (i < collection.Count - 1) output += ", ";
                        }
                        output += "]";
                    } else if (IsDictionary(message)) {
                        // Messy conversion here maybe fix these eventually
                        IDictionary<string, object> dict = Adapters.ObjectToDictionary(message);
                        List<object> keys = new List<object>((IEnumerable<object>)dict["Keys"]);
                        List<object> values = new List<object>((IEnumerable<object>)dict["Values"]);

                        output = "{";

                        for (int i = 0; i < keys.Count; i++) {
                            output += $"{keys[i]}: {values[i]}";
                            if (i < dict.Count - 1) output += ", ";
                        }
                        output += "}";
                    }
                } else {
                    output = "null";
                }
                Console.Write(output + "\n");
            }
        }

        public static void Warning(object message) {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Warning: ");
            Console.ResetColor();
            Log(message);
        }
    }
}
