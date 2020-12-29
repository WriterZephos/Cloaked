using System;
using System.Collections.Generic;
using Clkd.Assets;
using Clkd.Assets.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Clkd.Managers
{
    public class MouseInputManager : AbstractInputManager<AbstractInputTrigger<MouseStatus>, MouseStatus>
    {
        public Dictionary<MouseMapping, MouseStatus> InputStatuses { get; private set; } = new Dictionary<MouseMapping, MouseStatus>();
        public List<MouseMapping> InputMappings { get; set; } = new List<MouseMapping>();
        public Dictionary<MouseMapping, AbstractInputTrigger<MouseStatus>> InputTriggers { get; set; } = new Dictionary<MouseMapping, AbstractInputTrigger<MouseStatus>>();

        public MouseInputManager RegisterMouseMapping(MouseMapping mapping, AbstractInputTrigger<MouseStatus> trigger)
        {
            InputMappings.Add(mapping);
            InputMappings.Sort();
            InputStatuses.Add(mapping, new MouseStatus());
            InputTriggers.Add(mapping, trigger);
            return this;
        }

        public MouseInputManager UnRegisterMouseMapping(MouseMapping mapping)
        {
            InputMappings.Remove(mapping);
            InputStatuses.Remove(mapping);
            InputTriggers.Remove(mapping);
            return this;
        }
        public override void Update(GameTime gameTime)
        {
            MouseStateWrapper state = new MouseStateWrapper(Mouse.GetState());

            bool anyPressed = state.ButtonStates.ContainsValue(ButtonState.Pressed);
            foreach (MouseMapping mm in InputMappings)
            {
                // Check if all keys are pressed.
                bool pressed = true;
                // If both AnyButton and NoButton are true, then
                // pressed will always be true.
                if (mm.AnyButton || mm.NoButton)
                {
                    if (!anyPressed && !mm.NoButton)
                    {
                        pressed = false;
                    }

                    if (anyPressed && !mm.AnyButton)
                    {
                        pressed = false;
                    }
                }
                else
                {
                    foreach (MouseButton mb in Enum.GetValues(typeof(MouseButton)))
                    {
                        if (state.ButtonStates[mb] != ButtonState.Pressed)
                        {
                            pressed = false;
                            break;
                        }
                    }
                }
                // Set updated status.
                InputStatuses[mm].Update(pressed, gameTime, state);

                InputStatuses[mm].MouseMapping = mm;
                // Evaluate Input Trigger in all cases - this executes any conditions
                // and returns true or false indicating whether the condition was met
                // and the resulting action executed.
                if (InputTriggers[mm].Evaluate(InputStatuses[mm]))
                {
                    InputStatuses[mm].ResetDurationSinceLastExectute();
                }
            }
        }
    }
}