using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class ButtonClicker : MonoBehaviour
    {
        [SerializeField] private Button _barriersBuilded;
        [SerializeField] private Button _manikinDroped;
        [SerializeField] private Button _barriersBoosted;

        public event Action BarriersBuilded;
        public event Action ManikinDroped;
        public event Action BarriersBoosted;

        private void OnEnable()
        {
            _barriersBuilded.onClick.AddListener(BuildBarriers);
            _manikinDroped.onClick.AddListener(DropManikin);
            _barriersBoosted.onClick.AddListener(BoostBarriers);
        }

        private void OnDisable()
        {
            _barriersBuilded.onClick.RemoveListener(BuildBarriers);
            _manikinDroped.onClick.RemoveListener(DropManikin);
            _barriersBoosted.onClick.RemoveListener(BoostBarriers);
        }

        public void DropManikin()
        {
            ManikinDroped?.Invoke();
        }

        public void BuildBarriers()
        {
            BarriersBuilded?.Invoke();
        }

        public void BoostBarriers()
        {
            BarriersBoosted?.Invoke();
        }
    }
}