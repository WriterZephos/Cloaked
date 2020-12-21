using System;

using Clkd.Assets.Interfaces;
using Microsoft.Xna.Framework;

namespace Clkd.Assets
{
    public class KeyStatus : IInputStatus
    {
        public KeyMapping KeyMapping { get; set; }
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

        public KeyStatus()
        {
            Pressed = false;
            Duration = default(TimeSpan);
        }

        public bool KeyTyped()
        {
            return ((PreviouslyPressed != Pressed) && Pressed);
        }

        public bool KeyHeld()
        {
            return ((PreviouslyPressed == Pressed) && Pressed);
        }

        public bool KeyReleased()
        {
            return ((PreviouslyPressed != Pressed) && !Pressed);
        }

        public void Update(bool pressed, GameTime gameTime)
        {
            Pressed = pressed;

            Duration = PreviouslyPressed && Pressed ? Duration += gameTime.ElapsedGameTime : default(TimeSpan);
            DurationSinceLastPress = !PreviouslyPressed && !Pressed ? Duration += gameTime.ElapsedGameTime : default(TimeSpan);
            DurationSinceLastExecute = PreviouslyPressed && Pressed ? Duration += gameTime.ElapsedGameTime : default(TimeSpan);
        }

        public void ResetDurationSinceLastExectute()
        {
            DurationSinceLastExecute = default(TimeSpan);
        }
    }
}
