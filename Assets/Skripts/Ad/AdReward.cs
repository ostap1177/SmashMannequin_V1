using Entity;
using System;
using UnityEngine;
using YG;

namespace Ad
{
    public class AdReward : MonoBehaviour
    {
        [SerializeField] private PauseObject _pauseObject;

        public event Action ManikinDroped;
        public event Action BarrierBuilded;
        public event Action BarrierBoosted;
        public event Action ErrorVideo;

        public void Reward(int idEntity)
        {
            Closed();

            YandexGame.RewVideoShow(idEntity);
            _pauseObject.PauseGame();

            Open();
        }

        private void OnErrorVideoEvent()
        {
            Closed();

            _pauseObject.PlayGame();
            ErrorVideo?.Invoke();
        }

        private void OnRewardVideoEvent(int id)
        {
            Closed();

            switch (id)
            {
                case 1:
                    ManikinDroped?.Invoke();
                    break;
                case 2:
                    BarrierBuilded?.Invoke();
                    break;
                case 3:
                    BarrierBoosted?.Invoke();
                    break;
            }
        }

        private void Open()
        {
            YandexGame.ErrorVideoEvent += OnErrorVideoEvent;
            YandexGame.RewardVideoEvent += OnRewardVideoEvent;
        }

        private void Closed()
        {
            YandexGame.ErrorVideoEvent -= OnErrorVideoEvent;
            YandexGame.RewardVideoEvent -= OnRewardVideoEvent;

            ErrorVideo?.Invoke();
        }
    }
}