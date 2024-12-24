using Unity.VisualScripting;
using UnityEngine.Rendering;

namespace Assets.Scripts.Events
{
    public class EventService
    {
        public EventController OnPlayerDeath;
        public EventController<float> OnPlayerAttacked;
        public EventController<float> SetInitialHealth;
        public EventController<float> UpdateHealth;
        public EventController OnCoinCollected;

        public EventService()
        {
            OnPlayerDeath = new EventController();
            OnPlayerAttacked = new EventController<float>();
            SetInitialHealth = new EventController<float>();
            UpdateHealth = new EventController<float>();
            OnCoinCollected = new EventController();
        }
    }
}

