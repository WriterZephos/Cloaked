using System.Collections.Generic;
using Clkd.Assets;
using Microsoft.Xna.Framework.Input;

namespace Clkd.Assets
{
    public class MouseStateWrapper
    {
        public MouseState MouseState { get; set; }

        public Dictionary<MouseButton, ButtonState> ButtonStates { get; set; }

        public int X { get => MouseState.X; }
        public int Y { get => MouseState.Y; }
        public ButtonState LeftButton { get => MouseState.LeftButton; }
        public ButtonState MiddleButton { get => MouseState.MiddleButton; }
        public ButtonState RightButton { get => MouseState.RightButton; }
        public ButtonState XButton1 { get => MouseState.XButton1; }
        public ButtonState XButton2 { get => MouseState.XButton2; }
        public int ScrollWheelValue { get => MouseState.ScrollWheelValue; }
        public int HorizontalScrollWheelValue { get => MouseState.HorizontalScrollWheelValue; }

        public MouseStateWrapper(MouseState state)
        {
            MouseState = state;
            ButtonStates = new Dictionary<MouseButton, ButtonState>();
            ButtonStates.Add(MouseButton.LeftButton, state.LeftButton);
            ButtonStates.Add(MouseButton.MiddleButton, state.MiddleButton);
            ButtonStates.Add(MouseButton.RightButton, state.RightButton);
            ButtonStates.Add(MouseButton.XButton1, state.XButton1);
            ButtonStates.Add(MouseButton.XButton2, state.XButton2);

        }
    }
}