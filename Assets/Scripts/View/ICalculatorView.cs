using System;

namespace View {
    public interface ICalculatorView {
        event Action<ResultClickedEventArgs> ResultClicked;
        event Action ErrorPopupCloseClicked;
        event Action<string> InputChanged;
        event Action Destroyed;
        
        void ClearInput();
        void AddResult(string result);
        void ShowErrorPopup();
        void HideErrorPopup();
        void SetInput(string input);
    }
}