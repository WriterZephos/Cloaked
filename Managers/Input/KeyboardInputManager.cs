using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Clkd.Assets;
using Clkd.Assets.Interfaces;

namespace Clkd.Managers
{
    public class KeyboardInputManager : AbstractInputManager<AbstractInputTrigger<KeyStatus>, KeyStatus>
    {
        public Dictionary<KeyMapping, KeyStatus> InputStatuses { get; private set; } = new Dictionary<KeyMapping, KeyStatus>();
        public List<KeyMapping> InputMappings { get; set; } = new List<KeyMapping>();
        public Dictionary<KeyMapping, AbstractInputTrigger<KeyStatus>> InputTriggers { get; set; } = new Dictionary<KeyMapping, AbstractInputTrigger<KeyStatus>>();

        // TODO: Refactor this so that identical mappings are handled more efficiently and multiple triggers can be
        // associated with the same mapping, and all of them get evaluated with the same keystatus, etc.
        // Also refactor triggers to use c# events.
        public KeyboardInputManager RegisterKeyMapping(KeyMapping mapping, AbstractInputTrigger<KeyStatus> trigger)
        {
            InputMappings.Add(mapping);
            InputStatuses.Add(mapping, new KeyStatus());
            InputTriggers.Add(mapping, trigger);
            return this;
        }

        public KeyboardInputManager UnRegisterKeyMapping(KeyMapping mapping)
        {
            InputMappings.Remove(mapping);
            InputStatuses.Remove(mapping);
            InputTriggers.Remove(mapping);
            return this;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            foreach (KeyMapping km in InputMappings)
            {
                // Check if all keys are pressed.
                bool pressed = true;
                if (km.AnyKey)
                {
                    if (state.GetPressedKeys().Length < 1)
                    {
                        pressed = false;
                    }
                }
                else
                {
                    foreach (Keys k in km.Keys)
                    {
                        if (!state.IsKeyDown(k))
                        {
                            pressed = false;
                            break;
                        }
                    }
                }

                // Set updated status.
                InputStatuses[km].Update(pressed, gameTime);

                InputStatuses[km].KeyMapping = km;
                // Evaluate Input Trigger in all cases - this executes any conditions
                // and returns true or false indicating whether the condition was met
                // and the resulting action executed.
                if (InputTriggers[km].Evaluate(InputStatuses[km]))
                {
                    InputStatuses[km].ResetDurationSinceLastExectute();
                }
            }
        }
    }
}
