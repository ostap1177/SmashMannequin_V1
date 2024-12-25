using System.Collections.Generic;
using Localization;
using UnityEngine;

namespace Ui
{
    public class LanguageButton : MonoBehaviour
    {
        [SerializeField] private LocalizationSelect _localization;
        [SerializeField] private LanguageDefinition _languageDefinition;
        [SerializeField] private LocalizationView _localizationView;
        [SerializeField] private List<string> _languageNames = new ();

        private int _index = 0;

        private void Awake()
        {
            _index = _languageNames.IndexOf(_languageDefinition.LoadLanguage());
            SetLangeage();
        }

        public void SetLangeage()
        {
            if (_index >= _languageNames.Count || _index < 0)
                _index = 0;

            _localization.ChangeLanguage(_languageNames[_index]);
            _localizationView.Show(_languageNames[_index]);
            _index++;
        }
    }
}