using Entity;
using UnityEngine;

namespace Ui
{
    public class GameOver : MonoBehaviour
    {
        [SerializeField] protected PauseObject _pauseObject;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private UiBoard _boardFinal;

        private void OnEnable()
        {
            _scoreCounter.GameOvered += OnGameOvered;
        }

        private void OnDisable()
        {
            _scoreCounter.GameOvered -= OnGameOvered;
        }

        private void OnGameOvered()
        {
            _boardFinal.gameObject.SetActive(true);
            _pauseObject.PauseGame();
        }
    }
}