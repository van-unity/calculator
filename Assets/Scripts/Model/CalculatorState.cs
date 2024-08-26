using System.Collections.Generic;

namespace Model {
    public class CalculatorState {
        public Queue<string> ResultHistory { get; private set; }
        public string LastInput { get; private set; }

        public CalculatorState(Queue<string> resultHistory, string lastInput) {
            ResultHistory = new Queue<string>(resultHistory);
            LastInput = lastInput;
        }

        public void AddToHistory(string result) {
            ResultHistory.Enqueue(result);
        }

        public void SetLastInput(string input) {
            LastInput = input;
        }

        public override string ToString() {
            return $"LastInput: {LastInput}\n{string.Join("\n", ResultHistory)}";
        }
    }
}