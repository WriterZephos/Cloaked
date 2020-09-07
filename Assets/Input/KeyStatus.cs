using System;

using Clkd.Assets.Interfaces;

namespace Clkd.Assets
{
    public class KeyStatus : IInputStatus
    {
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
    }
}
