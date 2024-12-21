using System;
using Assets.Scripts.Events;
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

        //services
        private EventService eventService;
        

        public void SetServices(EventService eventService)
        {
            this.eventService = eventService;
            AddEventListeners();
        }

        private void AddEventListeners()
        {
            eventService.SetInitialHealth.AddListener(SetInitialHealth);
        }

        private void OnDisable()
        {
            eventService.SetInitialHealth.RemoveListener(UpdateHealthUI);
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
    }
}