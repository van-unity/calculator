using System;
using UnityEngine;
using UnityEngine.UI;

namespace View {
    public class ErrorPopup : MonoBehaviour {
        [SerializeField] private Button _closeButton;

        public event Action CloseButtonClicked;
    
        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    
        private void OnEnable() {
            _closeButton.onClick.AddListener(OnCloseButtonClicked);
        }

        private void OnCloseButtonClicked() {
            CloseButtonClicked?.Invoke();
        }

        private void OnDisable() {
            _closeButton.onClick.RemoveListener(OnCloseButtonClicked);
        }
    }
}