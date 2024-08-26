using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Model {
    public class CalculatorStateRepository : ICalculatorStateSaver, ICalculatorStateLoader {
        private const string STATE_SAVE_KEY = "ssk";
    
        public void Save(CalculatorState state) {
            PlayerPrefs.SetString(STATE_SAVE_KEY, JsonConvert.SerializeObject(state));
        }

        public CalculatorState Load() {
            var savedState = PlayerPrefs.GetString(STATE_SAVE_KEY, string.Empty);
        
            if (string.IsNullOrEmpty(savedState)) {
                return new CalculatorState(new Queue<string>(), string.Empty);
            }

            try {
                return JsonConvert.DeserializeObject<CalculatorState>(savedState);
            }
            catch {
                return new CalculatorState(new Queue<string>(), string.Empty);
            }
        }
    }
}