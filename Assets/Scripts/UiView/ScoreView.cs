using TMPro;
using Ui;
using UnityEngine;

namespace UiView
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private TMP_Text _scoreText;

        private void OnEnable()
        {
            _scoreCounter.PointsTransfered += OnPointsTransfered;
        }

        private void OnDisable()
        {
            _scoreCounter.PointsTransfered -= OnPointsTransfered;
        }

        private void OnPointsTransfered(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}