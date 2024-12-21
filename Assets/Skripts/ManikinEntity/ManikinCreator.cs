using Entity;
using UnityEngine;

namespace ManikinEntity
{
    public class ManikinCreator : EntityBuying
    {
        [Space(10)]
        [SerializeField] private Manikin _manikinPrefab;
        [SerializeField] private float _leftLimit;
        [SerializeField] private float _rightLimit;

        private Transform _transform;

        public int ManikinCost => Cost;

        private void OnEnable()
        {
            ButtonClicker.DropedManikin += OnCreate;
            AdReward.ManikinDroped += OnRewarded;
        }

        private void OnDisable()
        {
            ButtonClicker.DropedManikin -= OnCreate;
            AdReward.ManikinDroped -= OnRewarded;
        }

        private void Awake()
        {
            CostView.SetText(ManikinCost);
            _transform = transform;
        }

        protected override void CreateEntity()
        {
            float xPosition = Random.Range(_leftLimit, _rightLimit);
            Vector3 position = new Vector3(xPosition, _transform.position.y, _transform.position.z);

            Instantiate(_manikinPrefab.gameObject, position, Quaternion.identity);
        }
    }
}