using System;
using Utils;

namespace Game.CharacterSystem.Events
{
    public enum CharacterEventType
    {
        ON_DEATH,
        ON_RESTARTED,
        ON_FINISHED,
    }
    
    public class CharacterEvent
    {
        private CharacterEventType _characterEventType;

        private event Action _onCharacterEvent;

        public CharacterEvent(CharacterEventType characterEventType)
        {
            _characterEventType = characterEventType;
        }

        public void SubscribeToEvent(Action action)
        {
            _onCharacterEvent += action;
        }

        public void InvokeEvent()
        {
            _onCharacterEvent.SafeInvoke();
        }

        public CharacterEventType GetEventType()
        {
            return _characterEventType;
        }
    }
}
