using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View {
    [RequireComponent(typeof(TMP_InputField))]
    public class EquationInputField : MonoBehaviour {
        [SerializeField] private Image _selectionImage;
        [SerializeField] private Color _selectedColor;
        [SerializeField] private Color _deSelectedColor;
        private TMP_InputField _inputField;

        private void Awake() {
            _inputField = GetComponent<TMP_InputField>();
        }

        private void Start() {
            _inputField.onSelect.AddListener(OnSelected);
            _inputField.onDeselect.AddListener(OnDeselected);
        }

        private void OnSelected(string arg0) {
            _selectionImage.color = _selectedColor;
        }
    
        private void OnDeselected(string arg0) {
            _selectionImage.color = _deSelectedColor;
        }

        private void OnDestroy() {
            _inputField.onSelect.RemoveListener(OnSelected);
            _inputField.onDeselect.RemoveListener(OnDeselected);
        }
    }
}