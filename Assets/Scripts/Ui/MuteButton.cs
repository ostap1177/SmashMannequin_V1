using System;
using Sound;
using UnityEngine;

namespace Ui
{
    public class MuteButton : ParentButtons
    {
        [SerializeField] private MusicObject _musicObject;

        private bool _isClicked;

        public event Action<bool> MutedChanged;

        protected override void Click()
        {
            if (GetClicked() == true)
            {
                _musicObject.MuteOnGame();
                MutedChanged?.Invoke(true);
            }
            else
            {
                _musicObject.PlayOnGame();
                MutedChanged?.Invoke(false);
            }
        }

        private bool GetClicked()
        {
            return _isClicked = !_isClicked;
        }
    }
}