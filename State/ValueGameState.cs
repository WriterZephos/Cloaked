using System;
using System.Collections.Generic;

using Clkd.Main;

namespace Clkd.State
{

    //TODO: Implement the rest of the features for each type.

    public class ValueGameState : AbstractComponent
    {
        public Dictionary<string, bool> BoolFlags = new Dictionary<string, bool>();
        public Dictionary<string, string> StringValues = new Dictionary<string, string>();
        public Dictionary<string, int> IntValues = new Dictionary<string, int>();
        public Dictionary<string, float> FloatValues = new Dictionary<string, float>();
        public Dictionary<string, long> LongValues = new Dictionary<string, long>();
        public Dictionary<string, char> CharValues = new Dictionary<string, char>();
        public Dictionary<string, TimeSpan> TimeSpanValues = new Dictionary<string, TimeSpan>();

        public bool SetFlag(string flagName, bool value)
        {
            BoolFlags.TryGetValue(flagName, out bool previous);
            BoolFlags[flagName] = value;
            return previous;
        }

        public bool GetBoolFlag(string flagName)
        {
            BoolFlags.TryGetValue(flagName, out bool flag);
            return flag;
        }

        public string SetStringValue(string valueName, string value)
        {
            StringValues.TryGetValue(valueName, out string previous);
            StringValues[valueName] = value;
            return previous;
        }

        public bool GetStringValue(string valueName)
        {
            BoolFlags.TryGetValue(valueName, out bool val);
            return val;
        }
    }
}
