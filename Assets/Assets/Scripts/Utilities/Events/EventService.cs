namespace Assets.Scripts.Utilities.Events
{
    public class EventService : GenericSingleton<EventService>
    {
        public EventController OnPlayerDeath;
        public EventController<float> OnPlayerAttacked;
        public EventController<float> SetInitialHealth;
        public EventController<float> UpdateHealth;
        public EventController OnCoinCollected;

        //loadScene
        public EventController OnPlayButtonClicked;
        public EventController OnMainMenuButtonClicked;
        public EventController OnPlayerWin;

        public EventService()
        {
            OnPlayerDeath = new EventController();
            OnPlayerAttacked = new EventController<float>();
            SetInitialHealth = new EventController<float>();
            UpdateHealth = new EventController<float>();
            OnCoinCollected = new EventController();

            OnPlayButtonClicked =  new EventController();
            OnMainMenuButtonClicked = new EventController();
            OnPlayerWin = new EventController();
        }
    }
}

