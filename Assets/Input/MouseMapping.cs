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

    public class MouseMapping
    {
        public HashSet<MouseButton> Buttons { get; set; }
        public bool AnyButton { get; set; }
        public bool NoButton { get; set; }
        public string ActionName { get; set; }

        public MouseMapping(string actionName, params MouseButton[] buttons)
        {
            Buttons = new HashSet<MouseButton>(buttons);
            ActionName = actionName;
        }

        public MouseMapping(string actionName, HashSet<MouseButton> buttons)
        {
            Buttons = buttons;
            ActionName = actionName;
        }

        public static MouseMapping GetMappingToAnyButton(string actionName)
        {
            var mapping = new MouseMapping(actionName);
            mapping.AnyButton = true;
            return mapping;
        }

        public static MouseMapping GetMappingToNoButton(string actionName)
        {
            var mapping = new MouseMapping(actionName);
            mapping.NoButton = true;
            return mapping;
        }

        public static MouseMapping GetConstantMapping(string actionName)
        {
            var mapping = new MouseMapping(actionName);
            mapping.AnyButton = true;
            mapping.NoButton = true;
            return mapping;
        }
    }
}