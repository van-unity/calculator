using System;
using Model;
using View;

namespace Presenter {
    public class CalculatorPresenter : IDisposable {
        private readonly ICalculatorView _view;
        private readonly CalculatorState _state;
        private readonly Calculator _calculator;
        private readonly ICalculatorStateSaver _stateSaver;

        private bool _isDisposed;

        public CalculatorPresenter(ICalculatorView view, CalculatorState state, Calculator calculator,
            ICalculatorStateSaver stateSaver) {
            _view = view;
            _state = state;
            _calculator = calculator;
            _stateSaver = stateSaver;

            InitializeView();

            _view.ResultClicked += OnResultClicked;
            _view.InputChanged += OnInputChanged;
            _view.ErrorPopupCloseClicked += OnErrorPopupCloseClicked;
            _view.Destroyed += ViewOnDestroyed;
        }

        private void InitializeView() {
            var lastInput = _state.LastInput;
            if (!string.IsNullOrEmpty(lastInput)) {
                _view.SetInput(lastInput);
            }

            foreach (var result in _state.ResultHistory) {
                _view.AddResult(result);
            }
        }

        private void OnInputChanged(string input) {
            _state.SetLastInput(input);

            _stateSaver.Save(_state);
        }

        private void OnResultClicked(ResultClickedEventArgs clickArgs) {
            var isCorrect = _calculator.TryCalculate(clickArgs.Input, out var result);
            _state.AddToHistory(result);
            _view.AddResult(result);


            if (isCorrect) {
                _state.SetLastInput(string.Empty);
                _view.ClearInput();
            } else {
                _view.ShowErrorPopup();
            }

            _stateSaver.Save(_state);
        }

        private void OnErrorPopupCloseClicked() {
            _view.HideErrorPopup();
        }

        private void ViewOnDestroyed() {
            Dispose();
        }

        public void Dispose() {
            if (_isDisposed) {
                return;
            }

            _view.ResultClicked -= OnResultClicked;
            _view.InputChanged -= OnInputChanged;
            _view.ErrorPopupCloseClicked -= OnErrorPopupCloseClicked;
            _view.Destroyed -= ViewOnDestroyed;

            _isDisposed = true;
        }
    }
}