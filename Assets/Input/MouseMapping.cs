using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Clkd.Assets
{
    public enum MouseButton
    {
        LeftButton,
        MiddleButton,
        RightButton,
        XButton1,
        XButton2
    }

    public class MouseMapping : IComparable<MouseMapping>
    {
        public HashSet<MouseButton> Buttons { get; set; }
        public bool AnyButton { get; set; }
        public bool NoButton { get; set; }
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

        public MouseMapping(string actionName, int priority = 1, bool anyButton = false, bool noButton = false, params MouseButton[] buttons)
        {
            Buttons = new HashSet<MouseButton>(buttons);
            ActionName = actionName;
            Priority = priority;
            AnyButton = anyButton;
            NoButton = noButton;
        }

        public MouseMapping(string actionName, HashSet<MouseButton> buttons, int priority = 1, bool anyButton = false, bool noButton = false)
        {
            Buttons = buttons;
            ActionName = actionName;
            Priority = priority;
            AnyButton = anyButton;
            NoButton = noButton;
        }

        public static MouseMapping GetMappingToAnyButton(string actionName, int priority = 1)
        {
            return new MouseMapping(actionName, priority, anyButton: true);
        }

        public static MouseMapping GetMappingToNoButton(string actionName, int priority = 1)
        {
            return new MouseMapping(actionName, priority, noButton: true);
        }

        public static MouseMapping GetConstantMapping(string actionName, int priority = 1)
        {
            return new MouseMapping(actionName, priority, true, true);
        }

        public int CompareTo(MouseMapping other)
        {
            if (other == null) return 1;

            if (Priority < other.Priority) return 1;

            if (Priority > other.Priority) return -1;

            return 0;
        }
    }
}