using System;
using UnityEngine;

namespace Ui
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private int _currentScore = 100;
        [SerializeField] private Timer _timer;
        [SerializeField] private int _costSeconds = 1;

        private int _bestScore;

        public event Action<int> PointsTransfered;
        public event Action<float, float, int> TimeFinalized;
        public event Action GameOvered;

        private void OnEnable()
        {
            _timer.SecondElapsed += OnSecondElapsed;
        }

        private void OnDisable()
        {
            _timer.SecondElapsed -= OnSecondElapsed;
        }

        private void Start()
        {
            PointsTransfered?.Invoke(_currentScore);
        }

        public void AddPoints(int point)
        {
            _currentScore += point;

            if (_currentScore > _bestScore)
            {
                _bestScore = _currentScore;
            }

            PointsTransfered?.Invoke(_currentScore);
        }

        public bool TryRemovePoint(int point)
        {
            if (_currentScore - point >= 0)
            {
                _currentScore -= point;
                PointsTransfered?.Invoke(_currentScore);

                return true;
            }

            return false;
        }

        public void FinalCalculateScore()
        {
            int scoreInSeconds = (int)_timer.SecondTime;
            scoreInSeconds = scoreInSeconds * _costSeconds + _currentScore;

            float resultMinutes = Mathf.FloorToInt(scoreInSeconds / 60);
            float resultSeconds = Mathf.FloorToInt(scoreInSeconds % 60);

            TimeFinalized?.Invoke(resultMinutes, resultSeconds, _bestScore);
        }

        private void OnSecondElapsed()
        {
            _currentScore -= _costSeconds;
            PointsTransfered?.Invoke(_currentScore);

            if (_currentScore <= 0)
            {
                FinalCalculateScore();
                GameOvered?.Invoke();
            }
        }
    }
}