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
            _characterEvents = new List<CharacterEvent>();  
            
            // I statically added to events but they could be dynamic as well.
            _characterEvents.Add(new CharacterEvent(CharacterEventType.ON_DEATH));
            _characterEvents.Add(new CharacterEvent(CharacterEventType.ON_FINISHED));
            _characterEvents.Add(new CharacterEvent(CharacterEventType.ON_RESTARTED));
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
