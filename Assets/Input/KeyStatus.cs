using System;
using System.Collections.Generic;
using System.Linq;
using Clkd.Assets.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Clkd.Assets
{
    public class KeyStatus : EventArgs, IInputStatus
    {
        public KeyMapping KeyMapping { get; set; }
        public bool PreviouslyPressed { get; set; }

        public KeyboardState PreviousKeyBoardState { get; private set; }
        private KeyboardState _keyboardState;
        public KeyboardState KeyboardState
        {
            get => _keyboardState;
            set
            {
                // Preserve last value;
                PreviousKeyBoardState = KeyboardState;
                _keyboardState = value;
            }
        }

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
        public bool StopPropogation { get; set; }

        public KeyStatus(KeyMapping keyMapping)
        {
            KeyMapping = keyMapping;
            Pressed = false;
            Duration = default(TimeSpan);
        }

        public bool IsKeyPressed()
        {
            return ((PreviouslyPressed != Pressed) && Pressed) || KeyMapping.AnyKey && PressedKeys().Count() > 0;
        }

        public bool IsKeyDown()
        {
            return Pressed;
        }

        public bool IsKeyHeld()
        {
            return ((PreviouslyPressed == Pressed) && Pressed);
        }

        public bool IsKeyReleased()
        {
            return ((PreviouslyPressed != Pressed) && !Pressed) || KeyMapping.AnyKey && ReleasedKeys().Count() > 0;
        }

        internal void Update(GameTime gameTime, KeyboardState state)
        {
            KeyboardState = state;
            Pressed = KeyMapping.Keys.Except(KeyboardState.GetPressedKeys()).Count() == 0
                || (KeyMapping.AnyKey && KeyboardState.GetPressedKeyCount() > 0);
            Duration = PreviouslyPressed && Pressed ? Duration += gameTime.ElapsedGameTime : default(TimeSpan);
            DurationSinceLastPress = !PreviouslyPressed && !Pressed ? Duration += gameTime.ElapsedGameTime : default(TimeSpan);
            DurationSinceLastExecute = PreviouslyPressed && Pressed ? Duration += gameTime.ElapsedGameTime : default(TimeSpan);
        }

        internal void ResetDurationSinceLastExectute()
        {
            DurationSinceLastExecute = default(TimeSpan);
        }

        public IEnumerable<Keys> PressedKeys()
        {
            return KeyboardState.GetPressedKeys().Except(PreviousKeyBoardState.GetPressedKeys());
        }

        public IEnumerable<Keys> DownKeys()
        {
            return KeyboardState.GetPressedKeys();
        }

        public IEnumerable<Keys> HeldKeys()
        {
            return KeyboardState.GetPressedKeys().Intersect(PreviousKeyBoardState.GetPressedKeys());
        }

        public IEnumerable<Keys> ReleasedKeys()
        {
            return PreviousKeyBoardState.GetPressedKeys().Except(KeyboardState.GetPressedKeys());
        }
    }
}
