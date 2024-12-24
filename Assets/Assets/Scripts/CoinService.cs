using Assets.Scripts.Events;
using Unity.VisualScripting;

namespace Assets.Scripts
{
	public class CoinService
	{
		private int coinCount = 0;
		private EventService eventService;

		public CoinService(EventService eventService)
		{
			this.eventService = eventService;
			eventService.OnCoinCollected.AddListener(OnCoinCollected);
		}
		public void OnDestroy()
		{
			eventService.OnCoinCollected.RemoveListener(OnCoinCollected);
		}

		private void OnCoinCollected()
		{
			coinCount += 10;
		}
	}
}