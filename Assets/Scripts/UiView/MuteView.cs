using Ui;
using UnityEngine;
using UnityEngine.UI;

namespace UiView
{
    public class MuteView : MonoBehaviour
    {
        [SerializeField] private MuteButton _muteSound;
        [SerializeField] private Image _soundOff;
        [SerializeField] private Image _soundOn;

        private void OnEnable()
        {
            _muteSound.MutedChanged += OnMutedChanged;
        }

        private void OnDisable()
        {
            _muteSound.MutedChanged -= OnMutedChanged;
        }

        private void Awake()
        {
            _soundOff.enabled = false;
            _soundOn.enabled = true;
        }

        private void OnMutedChanged(bool isMute)
        {
            if (isMute)
            {
                _soundOff.enabled = true;
                _soundOn.enabled = false;
            }
            else
            {
                _soundOff.enabled = false;
                _soundOn.enabled = true;
            }
        }
    }
}