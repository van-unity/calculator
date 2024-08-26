using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View {
    public class CalculatorView : MonoBehaviour, ICalculatorView {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private TextMeshProUGUI _historyText;
        [SerializeField] private Button _resultButton;
        [SerializeField] private ErrorPopup _errorPopup;

        public event Action<ResultClickedEventArgs> ResultClicked;
        public event Action ErrorPopupCloseClicked;
        public event Action<string> InputChanged;
        public event Action Destroyed;

        public void ClearInput() {
            _inputField.SetTextWithoutNotify(string.Empty);
        }

        public void AddResult(string result) {
            if (string.IsNullOrEmpty(_historyText.text)) {
                _historyText.text = result;
            } else {
                _historyText.text = _historyText.text.Insert(0, $"{result}\n");
            }
        
            LayoutRebuilder.ForceRebuildLayoutImmediate(_historyText.rectTransform);
        }
    
        public void ShowErrorPopup() {
            _errorPopup.Show();
        }

        public void HideErrorPopup() {
            _errorPopup.Hide();
        }

        public void SetInput(string input) {
            _inputField.text = input;
        }

        private void OnEnable() {
            _errorPopup.CloseButtonClicked += ErrorPopupOnCloseButtonClicked;
            _resultButton.onClick.AddListener(OnResultButtonClicked);
            _inputField.onValueChanged.AddListener(OnInputChanged);
        }

        private void ErrorPopupOnCloseButtonClicked() {
            ErrorPopupCloseClicked?.Invoke();
        }

        private void OnResultButtonClicked() {
            ResultClicked?.Invoke(new ResultClickedEventArgs(_inputField.text));
        }

        private void OnInputChanged(string input) {
            InputChanged?.Invoke(input);
        }

        private void OnDisable() {
            _resultButton.onClick.RemoveListener(OnResultButtonClicked);
            _errorPopup.CloseButtonClicked -= ErrorPopupOnCloseButtonClicked;
            _inputField.onValueChanged.RemoveListener(OnInputChanged);
        }

        private void OnDestroy() {
            Destroyed?.Invoke();
        }
    }
}