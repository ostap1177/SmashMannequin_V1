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

        public event Action<int> TransferadPoints;
        public event Action<float, float, int> FinalizeTime;
        public event Action OveredGame;

        private void OnEnable()
        {
            _timer.ElapsedSecond += OnElapsedSecond;
        }

        private void OnDisable()
        {
            _timer.ElapsedSecond -= OnElapsedSecond;
        }

        private void Start()
        {
            TransferadPoints?.Invoke(_currentScore);
        }

        public void AddPoints(int point)
        {
            _currentScore += point;

            if (_currentScore > _bestScore)
            {
                _bestScore = _currentScore;
            }

            TransferadPoints?.Invoke(_currentScore);
        }

        public bool TryRemovePoint(int point)
        {
            if (_currentScore - point >= 0)
            {
                _currentScore -= point;
                TransferadPoints?.Invoke(_currentScore);
            }

            return _currentScore - point >= 0;
        }

        public void FinalCalculateScore()
        {
            int scoreInSeconds = (int)_timer.SecondTime;
            scoreInSeconds = scoreInSeconds * _costSeconds + _currentScore;

            float resultMinutes = Mathf.FloorToInt(scoreInSeconds / 60);
            float resultSeconds = Mathf.FloorToInt(scoreInSeconds % 60);

            FinalizeTime?.Invoke(resultMinutes, resultSeconds, _bestScore);
        }

        private void OnElapsedSecond()
        {
            _currentScore -= _costSeconds;
            TransferadPoints?.Invoke(_currentScore);

            if (_currentScore <= 0)
            {
                FinalCalculateScore();
                OveredGame?.Invoke();
            }
        }
    }
}