using Assets.Scripts.Utilities.Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class UIService : MonoBehaviour
    {
        //playerHealthUI
        [SerializeField] private Image maxHealth;
        [SerializeField] private Image currentHealth;
        [SerializeField] private TextMeshProUGUI coinText;
        private int coinCount = 0;

        //services
        private EventService eventService;
        
        public void Start()
        {
            eventService = EventService.Instance;
            AddEventListeners();
            coinText.text = "Coins : 0";
        }

        private void AddEventListeners()
        {
            eventService.SetInitialHealth.AddListener(SetInitialHealth);
            eventService.UpdateHealth.AddListener(UpdateHealthUI);
            eventService.OnCoinCollected.AddListener(UpdateCoinText);
        }

        private void OnDisable()
        {
            eventService.SetInitialHealth.RemoveListener(SetInitialHealth);
            eventService.UpdateHealth.RemoveListener(UpdateHealthUI);
            eventService.OnCoinCollected.RemoveListener(UpdateCoinText);
        }

        private void SetInitialHealth(float initHealth)
        {
            maxHealth.fillAmount = initHealth / 10;
            currentHealth.fillAmount = initHealth / 10;
        }
        private void UpdateHealthUI(float newHealth)
        {
            currentHealth.fillAmount = newHealth / 10;
        }

        private void UpdateCoinText()
        {
            coinCount += 10;
            coinText.text = "Coins : "+coinCount;
        }
    }
}