using Ui;
using UnityEngine;

namespace BarriersEntity
{
    [RequireComponent(typeof(Barriers))]

    public class BarriersCollision : MonoBehaviour
    {
        [SerializeField] private DragHandler _clickHandlerNew;

        private Barriers _barriersObject;

        private void OnEnable()
        {
            _clickHandlerNew.Dragging += OnDragging;
        }

        private void OnDisable()
        {
            _clickHandlerNew.Dragging -= OnDragging;
        }

        private void Awake()
        {
            _barriersObject = GetComponent<Barriers>();
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.TryGetComponent(out BarriersPlace component) && component.IsFilled == false)
            {
                _barriersObject.SetPlace(component);
            }
        }

        private void OnDragging(bool drag)
        {
            _barriersObject.ControlCollider(!drag);

            if (drag == false)
            {
                _barriersObject.ResetPlace();
            }
        }
    }
}
