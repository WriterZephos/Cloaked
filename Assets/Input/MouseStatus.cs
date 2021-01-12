using System;
using System.Collections.Generic;
using System.Linq;
using Clkd.Assets.Interfaces;
using Microsoft.Xna.Framework;

namespace Clkd.Assets
{
    public class MouseStatus : IInputStatus
    {
        public MouseMapping MouseMapping { get; set; }
        public bool PreviouslyPressed { get; set; }
        private bool _pressed;
        public bool Pressed
        {
            get => _pressed;
            set
            {
                // Preserve last value;
                PreviouslyPressed = Pressed;
                _pressed = value;
            }
        }
        public TimeSpan Duration { get; set; }
        public TimeSpan DurationSinceLastPress { get; set; }
        public TimeSpan DurationSinceLastExecute { get; set; }
        public MouseStateWrapper PreviousMouseState { get; private set; }
        private MouseStateWrapper _mouseState;
        public MouseStateWrapper MouseState
        {
            get => _mouseState;
            set
            {
                // Preserve last value;
                PreviousMouseState = MouseState;
                _mouseState = value;
            }
        }

        public bool StopPropogation { get; set; }

        public MouseStatus(MouseMapping mouseMapping)
        {
            Pressed = false;
            Duration = default(TimeSpan);
            MouseMapping = mouseMapping;
        }

        public bool IsClicked()
        {
            return ((PreviouslyPressed != Pressed) && Pressed) || MouseMapping.AnyButton && ClickedButtons().Count() > 0;
        }

        public bool IsHeld()
        {
            return ((PreviouslyPressed == Pressed) && Pressed);
        }

        public bool IsReleased()
        {
            return ((PreviouslyPressed != Pressed) && !Pressed) || MouseMapping.AnyButton && ReleasedButtons().Count() > 0;
        }

        public bool IsDragged()
        {
            return ((PreviouslyPressed == Pressed) && Pressed)
                && (PreviousMouseState.X != MouseState.X || PreviousMouseState.Y != MouseState.Y);
        }

        public bool IsScrolled()
        {
            if (PreviousMouseState == null) return false;
            return MouseState.ScrollWheelValue != PreviousMouseState.ScrollWheelValue;
        }

        internal void Update(GameTime gameTime, MouseStateWrapper state)
        {
            bool anyPressed = state.PressedButtons.Count() > 0;
            bool pressed = true;

            // If both AnyButton and NoButton are true, then
            // pressed will always be true.
            if (MouseMapping.AnyButton || MouseMapping.NoButton)
            {
                if (!anyPressed && !MouseMapping.NoButton)
                {
                    pressed = false;
                }

                if (anyPressed && !MouseMapping.AnyButton)
                {
                    pressed = false;
                }
            }
            else
            {
                if (MouseMapping.Buttons.Except(state.PressedButtons).Count() > 0)
                {
                    pressed = false;
                }
            }

            Pressed = pressed;
            MouseState = state;
            Duration = PreviouslyPressed && Pressed ? Duration += gameTime.ElapsedGameTime : default(TimeSpan);
            DurationSinceLastPress = !PreviouslyPressed && !Pressed ? Duration += gameTime.ElapsedGameTime : default(TimeSpan);
            DurationSinceLastExecute = PreviouslyPressed && Pressed ? Duration += gameTime.ElapsedGameTime : default(TimeSpan);
        }

        internal void ResetDurationSinceLastExectute()
        {
            DurationSinceLastExecute = default(TimeSpan);
        }

        public IEnumerable<MouseButton> ClickedButtons()
        {
            if (PreviousMouseState == null) return MouseState.PressedButtons;
            else return MouseState.PressedButtons.Except(PreviousMouseState.PressedButtons);
        }

        public IEnumerable<MouseButton> PressedButtons()
        {
            return MouseState.PressedButtons;
        }

        public IEnumerable<MouseButton> HeldButtons()
        {
            if (PreviousMouseState == null) return MouseState.PressedButtons;
            else return MouseState.PressedButtons.Intersect(PreviousMouseState.PressedButtons);
        }

        public IEnumerable<MouseButton> ReleasedButtons()
        {
            if (PreviousMouseState == null) return new HashSet<MouseButton>();
            return PreviousMouseState.PressedButtons.Except(MouseState.PressedButtons);
        }
    }
}