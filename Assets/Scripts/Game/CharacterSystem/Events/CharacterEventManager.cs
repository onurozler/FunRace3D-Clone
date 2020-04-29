using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.CharacterSystem.Events
{
    public class CharacterEventManager
    {
        private List<CharacterEvent> _characterEvents;
        
        public CharacterEventManager()
        {
            // I statically added to events but they could be dynamic as well.
            _characterEvents = new List<CharacterEvent>
            {
                new CharacterEvent(CharacterEventType.ON_DEATH),
                new CharacterEvent(CharacterEventType.ON_FINISHED),
                new CharacterEvent(CharacterEventType.ON_RESTARTED),
                new CharacterEvent(CharacterEventType.ON_STARTED)
            };
        }

        public void SubscribeEvent(CharacterEventType characterEventType, Action action)
        {
            var specificEvent = _characterEvents?.FirstOrDefault(x => x.GetEventType() == characterEventType);

            if (specificEvent != null)
            {
                specificEvent.SubscribeToEvent(action);
            }
        }

        public void InvokeEvent(CharacterEventType characterEventType)
        {
            var specificEvent = _characterEvents?.FirstOrDefault(x => x.GetEventType() == characterEventType);
            if (specificEvent != null)
            {
                specificEvent.InvokeEvent();
            } 
        }
        
    }
}
