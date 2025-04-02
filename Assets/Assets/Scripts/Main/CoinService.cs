using Assets.Scripts.Utilities.Events;

namespace Assets.Scripts.Main
{
    public class CoinService
    {
        private int coinCount = 0;

        public CoinService()
        {
            EventService.Instance.OnCoinCollected.AddListener(OnCoinCollected);
        }

        public void OnDestroy()
        {
            EventService.Instance.OnCoinCollected.RemoveListener(OnCoinCollected);
        }

        private void OnCoinCollected()
        {
            coinCount += 10;
        }
    }
}