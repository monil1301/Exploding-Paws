using System.Linq;
using UnityEngine;

namespace Utilities
{
    public static class Logger
    {
        // Method to log errors
        public static void LogError(string message, params (string varName, object varValue)[] variables)
        {
            string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string variableDetails = string.Join(", ", variables.Select(v => $"{v.varName}: {v.varValue}"));
            string logMessage = $"[Error] {timestamp} - {message} | {variableDetails}";
            Debug.LogError(logMessage);
        }
    }
}
