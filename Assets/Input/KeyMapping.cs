using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

namespace Clkd.Assets
{
    public class KeyMapping
    {
        public HashSet<Keys> Keys { get; set; }
        public bool AnyKey { get; set; }
        public string ActionName { get; set; }

        public KeyMapping(string actionName, params Keys[] keys)
        {
            Keys = new HashSet<Keys>(keys);
            ActionName = actionName;
        }

        public KeyMapping(string actionName, HashSet<Keys> keys)
        {
            Keys = keys;
            ActionName = actionName;
        }

        public static KeyMapping GetMappingToAnyKey(string actionName)
        {
            var mapping = new KeyMapping(actionName);
            mapping.AnyKey = true;
            return mapping;
        }

    }
}
