using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Clkd.Assets
{
    public class KeyMapping
    {
        public List<Keys> Keys { get; set; }
        public bool AnyKey { get; set; }
        public string ActionName { get; set; }

        public KeyMapping(string actionName, params Keys[] keys)
        {
            Keys = new List<Keys>(keys);
            ActionName = actionName;
        }

        public KeyMapping(string actionName, List<Keys> keys)
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
