using System;

namespace View {
    public class ResultClickedEventArgs : EventArgs {
        public string Input { get; }

        public ResultClickedEventArgs(string input) {
            Input = input;
        }
    }
}