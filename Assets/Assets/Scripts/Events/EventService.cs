using UnityEngine.Rendering;

namespace Assets.Scripts.Events
{
    public class EventService
    {
        public EventController OnPlayerDeath;
        public EventController<float> SetInitialHealth;

        public EventService()
        {
            OnPlayerDeath = new EventController();
            SetInitialHealth = new EventController<float>();
        }
    }
}

