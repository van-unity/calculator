using UnityEngine;

namespace View {
    public class ResultHistoryContent : MonoBehaviour {
        [SerializeField] private float _maxHeight;
        [SerializeField] private RectTransform _content;

        private RectTransform _rectTransform;

        private void Awake() {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void LateUpdate() {
            if (_content.sizeDelta.y <= _maxHeight) {
                _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, _content.sizeDelta.y);
            } else {
                _rectTransform.sizeDelta = new Vector2(_rectTransform.sizeDelta.x, _maxHeight);
            }
        }
    }
}