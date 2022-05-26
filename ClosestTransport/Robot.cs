using System.Text.Json.Serialization;

namespace ClosestTransport
{
    public class Robot
    {
        [JsonPropertyName("robotId")]
        public string RobotId { get; set; }

        [JsonPropertyName("batteryLevel")]
        public int BatteryLevel { get; set; }

        [JsonPropertyName("y")]
        public int YCoordinate { get; set; }

        [JsonPropertyName("x")]
        public int XCoordinate { get; set; }
    }
}
