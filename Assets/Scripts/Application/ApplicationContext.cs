using System;
using Model;
using View;
using Presenter;
using UnityEngine;

namespace Application {
    public class ApplicationContext : MonoBehaviour {
        [SerializeField] private CalculatorView _calculatorViewPrefab;
    
        private void Start() {
            var calculatorRepository = new CalculatorStateRepository();
            var calculatorState = calculatorRepository.Load();
            var calculator = new Calculator();
            var calculatorView = Instantiate(_calculatorViewPrefab);
            var calculatorPresenter =
                new CalculatorPresenter(calculatorView, calculatorState, calculator, calculatorRepository);
        }
    }
}