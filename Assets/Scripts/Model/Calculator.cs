namespace Model {
    public class Calculator {
        public bool TryCalculate(string input, out string result) {
            if (input.Contains("+")) {
                var parts = input.Split('+');
                if (int.TryParse(parts[0], out var a) && int.TryParse(parts[1], out var b)) {
                    result = $"{input}={a + b}";
                    return true;
                }
            }

            result =  $"{input}=ERROR";

            return false;
        }
    }
}