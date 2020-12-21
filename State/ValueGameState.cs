using System;
using System.Collections.Generic;

using Clkd.Main;

namespace Clkd.State
{

    //TODO: Implement the rest of the features for each type.

    public class ValueGameState : AbstractComponent
    {
        public Dictionary<string, bool> BoolFlags { get; set; }
        public Dictionary<string, string> StringValues { get; set; }
        public Dictionary<string, int> IntValues { get; set; }
        public Dictionary<string, float> FloatValues { get; set; }
        public Dictionary<string, long> LongValues { get; set; }
        public Dictionary<string, char> CharValues { get; set; }
        public Dictionary<string, TimeSpan> TimeSpanValues { get; set; }

        public bool SetBoolValue(string flagName, bool value)
        {
            ensureDictionaryIsInitialized<bool>(BoolFlags);
            BoolFlags.TryGetValue(flagName, out bool previous);
            BoolFlags[flagName] = value;
            return previous;
        }

        public bool GetBoolValue(string flagName)
        {
            ensureDictionaryIsInitialized<bool>(BoolFlags);
            BoolFlags.TryGetValue(flagName, out bool flag);
            return flag;
        }

        public string SetStringValue(string valueName, string value)
        {
            ensureDictionaryIsInitialized<string>(StringValues);
            StringValues.TryGetValue(valueName, out string previous);
            StringValues[valueName] = value;
            return previous;
        }

        public string GetStringValue(string valueName)
        {
            ensureDictionaryIsInitialized<string>(StringValues);
            StringValues.TryGetValue(valueName, out string val);
            return val;
        }

        public int SetIntValue(string valueName, int value)
        {
            ensureDictionaryIsInitialized<int>(IntValues);
            IntValues.TryGetValue(valueName, out int previous);
            IntValues[valueName] = value;
            return previous;
        }

        public int GetIntValue(string valueName)
        {
            ensureDictionaryIsInitialized<int>(IntValues);
            IntValues.TryGetValue(valueName, out int val);
            return val;
        }

        public float SetFloatValue(string valueName, float value)
        {
            ensureDictionaryIsInitialized<float>(FloatValues);
            FloatValues.TryGetValue(valueName, out float previous);
            FloatValues[valueName] = value;
            return previous;
        }

        public float GetFloatValue(string valueName)
        {
            ensureDictionaryIsInitialized(FloatValues);
            FloatValues.TryGetValue(valueName, out float val);
            return val;
        }

        public long SetLongValue(string valueName, long value)
        {
            ensureDictionaryIsInitialized<long>(LongValues);
            LongValues.TryGetValue(valueName, out long previous);
            LongValues[valueName] = value;
            return previous;
        }

        public long GetLongValue(string valueName)
        {
            ensureDictionaryIsInitialized(LongValues);
            LongValues.TryGetValue(valueName, out long val);
            return val;
        }

        public char SetCharValue(string valueName, char value)
        {
            ensureDictionaryIsInitialized<char>(CharValues);
            CharValues.TryGetValue(valueName, out char previous);
            CharValues[valueName] = value;
            return previous;
        }

        public char GetCharValue(string valueName)
        {
            ensureDictionaryIsInitialized(CharValues);
            CharValues.TryGetValue(valueName, out char val);
            return val;
        }

        public TimeSpan SetTimeSpanValue(string valueName, TimeSpan value)
        {
            ensureDictionaryIsInitialized<TimeSpan>(TimeSpanValues);
            TimeSpanValues.TryGetValue(valueName, out TimeSpan previous);
            TimeSpanValues[valueName] = value;
            return previous;
        }

        public TimeSpan GetTimeSpanValue(string valueName)
        {
            ensureDictionaryIsInitialized(TimeSpanValues);
            TimeSpanValues.TryGetValue(valueName, out TimeSpan val);
            return val;
        }

        private void ensureDictionaryIsInitialized<T>(Dictionary<string, T> dictionary)
        {
            if (dictionary == null)
            {
                dictionary = new Dictionary<string, T>();
            }
        }
    }
}
