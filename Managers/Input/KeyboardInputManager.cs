using Clkd.Managers.Interfaces;
using Clkd.Assets;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Clkd.Assets.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace Clkd.Managers
{
    public class KeyboardInputManager : AbstractInputManager<IInputTrigger<KeyStatus>, KeyStatus>
    {
        public Dictionary<KeyMapping, KeyStatus> InputStatus { get; private set; } = new Dictionary<KeyMapping, KeyStatus>();
        public List<KeyMapping> InputMappings { get; set; } = new List<KeyMapping>();
        public Dictionary<KeyMapping, IInputTrigger<KeyStatus>> InputTriggers { get; set; } = new Dictionary<KeyMapping, IInputTrigger<KeyStatus>>();

        public KeyboardInputManager RegisterKeyMapping(KeyMapping mapping, IInputTrigger<KeyStatus> trigger)
        {
            InputMappings.Add(mapping);
            InputStatus.Add(mapping, new KeyStatus());
            InputTriggers.Add(mapping, trigger);
            return this;
        }

        public KeyboardInputManager RegisterKeyMappings(List<Tuple<KeyMapping, IInputTrigger<KeyStatus>>> mappingTriggerTupleList)
        {
            foreach(Tuple<KeyMapping, IInputTrigger<KeyStatus>> tuple in mappingTriggerTupleList)
            {
                RegisterKeyMapping(tuple.Item1, tuple.Item2);
            }
            return this;
        }

        public KeyboardInputManager UnRegisterKeyMapping(KeyMapping mapping)
        {
            InputMappings.Remove(mapping);
            InputStatus.Remove(mapping);
            InputTriggers.Remove(mapping);
            return this;
        }

        public KeyboardInputManager UnRegisterKeyMappings(List<Tuple<KeyMapping, IInputTrigger<KeyStatus>>> mappingTriggerTupleList)
        {
            foreach (Tuple<KeyMapping, IInputTrigger<KeyStatus>> tuple in mappingTriggerTupleList)
            {
                UnRegisterKeyMapping(tuple.Item1);
            }
            return this;
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();

            foreach(KeyMapping km in InputMappings)
            {
                // Check if all keys are pressed.
                bool pressed = true;
                if (km.AnyKey)
                {
                    if(state.GetPressedKeys().Length < 1)
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
                InputStatus[km].Pressed = pressed;

                InputStatus[km].Duration = InputStatus[km].PreviouslyPressed && InputStatus[km].Pressed ? 
                    InputStatus[km].Duration += gameTime.ElapsedGameTime :
                    default(TimeSpan);

                InputStatus[km].DurationSinceLastExecute = InputStatus[km].PreviouslyPressed && InputStatus[km].Pressed ?
                    InputStatus[km].DurationSinceLastExecute += gameTime.ElapsedGameTime :
                    default(TimeSpan);

                // Evaluate Input Trigger in all cases
                if (InputTriggers[km].Evaluate(InputStatus[km]))
                {
                    InputStatus[km].DurationSinceLastExecute = default(TimeSpan);
                }
            }
        }
    }
}
