using UnityEngine;
using YG;

namespace Shop
{
    public class PurchaseItem : MonoBehaviour
    {
        [SerializeField] private ShopItem[] _shopItems = new ShopItem[3];

        private void OnEnable()
        {
            YandexGame.PurchaseSuccessEvent += OnSuccessPurchased;

            YandexGame.ConsumePurchases();
        }

        private void OnDisable()
        {
            YandexGame.PurchaseSuccessEvent -= OnSuccessPurchased;
        }

        private void Awake()
        {
            StartCoroutine(YandexPurchaseSpriteHolder.Get(null));
        }

        private void Start()
        {
            if (YandexGame.SDKEnabled == true)
            {
                YandexGame.LoadProgress();
                CheckPurchase(YandexGame.savesData.LoadItems());
            }
        }

        public void OpenWindowPayments(string id)
        {
            YandexGame.BuyPayments(id);
        }

        private void CheckPurchase(string[] itemsBuyId)
        {
            foreach (var item in _shopItems)
            {
                foreach (var id in itemsBuyId)
                {
                    if (item.Id == id)
                    {
                        item.Purchase();
                    }
                }
            }
        }

        private void OnSuccessPurchased(string id)
        {
            foreach (var item in _shopItems)
            {
                if (item.Id == id)
                {
                    if (item.TryGetComponent(out ShopItem itemBuy))
                    {
                        itemBuy.Purchase();
                        YandexGame.savesData.SaveItem(item.Id);
                        YandexGame.SaveProgress();
                    }
                }
            }

            YandexGame.ConsumePurchaseByID(id);
        }
    }
}