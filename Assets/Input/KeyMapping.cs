using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Input;

namespace Clkd.Assets
{
    public class KeyMapping : IComparable<KeyMapping>
    {
        public HashSet<Keys> Keys { get; set; }
        public bool AnyKey { get; set; }
        public string ActionName { get; set; }
        private int _priority;
        public int Priority
        {
            get => _priority;
            private set
            {
                _priority = value;
            }
        }

        public KeyMapping(string actionName, int priority = 1, bool anyKey = false, params Keys[] keys)
        {
            Keys = new HashSet<Keys>(keys);
            ActionName = actionName;
            Priority = priority;
            AnyKey = anyKey;
        }

        public KeyMapping(string actionName, HashSet<Keys> keys, int priority = 1, bool anyKey = false)
        {
            Keys = keys;
            ActionName = actionName;
            Priority = priority;
            AnyKey = anyKey;
        }

        public static KeyMapping GetMappingToAnyKey(string actionName, int priority = 1)
        {
            return new KeyMapping(actionName, priority, true);
        }

        public int CompareTo(KeyMapping other)
        {
            if (other == null) return 1;

            if (Priority < other.Priority) return 1;

            if (Priority > other.Priority) return -1;

            return 0;
        }
    }
}
