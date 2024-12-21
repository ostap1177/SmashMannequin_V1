using Entity;
using Ui;
using UnityEngine;

namespace BarriersEntity
{
    public class BoostBarriers : EntityBuying
    {
        [Space(10)]
        [SerializeField] private float _socondTime = 5f;
        [SerializeField] private int _boostMultiplier = 2;
        [SerializeField] private Switcher _switcher;
        [SerializeField] private Timer _timer;

        private bool _isActive = false;
        private int _normalMultiplaer = 1;

        public int BoostCost => Cost;

        private void OnEnable()
        {
            ButtonClicker.BarriersBoosted += OnBoost;
            AdReward.BarrierBoosted += OnRewarded;
            AdReward.ErrorVideo += OnErrorVideo;
            _timer.EndTime += OnEndTime;
        }

        private void OnDisable()
        {
            ButtonClicker.BarriersBoosted -= OnBoost;
            AdReward.BarrierBoosted -= OnRewarded;
            AdReward.ErrorVideo -= OnErrorVideo;
            _timer.EndTime -= OnEndTime;
        }

        private void Awake()
        {
            CostView.SetText(BoostCost);
        }

        public override void AdView(bool isView)
        {
            if (_isActive == false)
            {
                CostView.EnableText(!isView);
                CostView.EnableImage(isView);
            }
            else
            {
                CostView.EnableText(false);
                CostView.EnableImage(false);
            }
        }

        protected override void CreateEntity()
        {
            _isActive = true;

            CostView.EnableText(false);
            CostView.EnableImage(false);
            _timer.CountingDown(_socondTime);
            _switcher.SetSpeedActiveBarriers(_boostMultiplier);
        }

        private void OnErrorVideo()
        {
            CostView.EnableText(true);
            CostView.EnableImage(false);

            _isActive = false;
        }

        private void OnBoost()
        {
            if (_isActive == false)
            {
                OnCreate();
            }
        }

        private void OnEndTime()
        {
            _isActive = false;
            CostView.EnableText(true);
            _switcher.SetSpeedActiveBarriers(_normalMultiplaer);
        }
    }
}