using System.Collections.Generic;
using Entity;
using UnityEngine;

namespace Ui
{
    public class CheckNumberPoints : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private List<EntityBuying> _entityBuyings;

        private void OnEnable()
        {
            _scoreCounter.TransferadPoints += OnTransfer;
        }

        private void OnDisable()
        {
            _scoreCounter.TransferadPoints -= OnTransfer;
        }

        private void OnTransfer(int score)
        {
            foreach (EntityBuying entity in _entityBuyings)
            {
                entity.AdView(entity.Cost > score);
            }
        }
    }
}