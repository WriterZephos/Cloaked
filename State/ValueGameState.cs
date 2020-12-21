using System;
using System.Collections.Generic;

using Clkd.Main;

namespace Clkd.State
{

    //TODO: Implement the rest of the features for each type.

    public class ValueGameState : AbstractComponent
    {
        private Lazy<Dictionary<string, bool>> _boolValues = new Lazy<Dictionary<string, bool>>();
        public Dictionary<string, bool> BoolValues { get => _boolValues.Value; }
        private Lazy<Dictionary<string, string>> _stringValues = new Lazy<Dictionary<string, string>>();
        public Dictionary<string, string> StringValues { get => _stringValues.Value; }
        private Lazy<Dictionary<string, int>> _intValues = new Lazy<Dictionary<string, int>>();
        public Dictionary<string, int> IntValues { get => _intValues.Value; }
        private Lazy<Dictionary<string, float>> _floatValues = new Lazy<Dictionary<string, float>>();
        public Dictionary<string, float> FloatValues { get => _floatValues.Value; }
        private Lazy<Dictionary<string, long>> _longValues = new Lazy<Dictionary<string, long>>();
        public Dictionary<string, long> LongValues { get => _longValues.Value; }
        private Lazy<Dictionary<string, char>> _charValues = new Lazy<Dictionary<string, char>>();
        public Dictionary<string, char> CharValues { get => _charValues.Value; }
        private Lazy<Dictionary<string, TimeSpan>> _timeSpanValues = new Lazy<Dictionary<string, TimeSpan>>();
        public Dictionary<string, TimeSpan> TimeSpanValues { get => _timeSpanValues.Value; }

        public bool SetBoolValue(string flagName, bool value)
        {
            BoolValues.TryGetValue(flagName, out bool previous);
            BoolValues[flagName] = value;
            return previous;
        }

        public bool GetBoolValue(string flagName)
        {
            BoolValues.TryGetValue(flagName, out bool flag);
            return flag;
        }

        public string SetStringValue(string valueName, string value)
        {
            StringValues.TryGetValue(valueName, out string previous);
            StringValues[valueName] = value;
            return previous;
        }

        public string GetStringValue(string valueName)
        {
            StringValues.TryGetValue(valueName, out string val);
            return val;
        }

        public int SetIntValue(string valueName, int value)
        {
            IntValues.TryGetValue(valueName, out int previous);
            IntValues[valueName] = value;
            return previous;
        }

        public int GetIntValue(string valueName)
        {
            IntValues.TryGetValue(valueName, out int val);
            return val;
        }

        public float SetFloatValue(string valueName, float value)
        {
            FloatValues.TryGetValue(valueName, out float previous);
            FloatValues[valueName] = value;
            return previous;
        }

        public float GetFloatValue(string valueName)
        {
            FloatValues.TryGetValue(valueName, out float val);
            return val;
        }

        public long SetLongValue(string valueName, long value)
        {
            LongValues.TryGetValue(valueName, out long previous);
            LongValues[valueName] = value;
            return previous;
        }

        public long GetLongValue(string valueName)
        {
            LongValues.TryGetValue(valueName, out long val);
            return val;
        }

        public char SetCharValue(string valueName, char value)
        {
            CharValues.TryGetValue(valueName, out char previous);
            CharValues[valueName] = value;
            return previous;
        }

        public char GetCharValue(string valueName)
        {
            CharValues.TryGetValue(valueName, out char val);
            return val;
        }

        public TimeSpan SetTimeSpanValue(string valueName, TimeSpan value)
        {
            TimeSpanValues.TryGetValue(valueName, out TimeSpan previous);
            TimeSpanValues[valueName] = value;
            return previous;
        }

        public TimeSpan GetTimeSpanValue(string valueName)
        {
            TimeSpanValues.TryGetValue(valueName, out TimeSpan val);
            return val;
        }
    }
}
