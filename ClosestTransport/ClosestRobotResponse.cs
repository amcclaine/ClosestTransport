using System.Text.Json.Serialization;

namespace ClosestTransport
{
    public class ClosestRobotResponse
    {
        [JsonPropertyName("robotId")]
        public string RobotId { get; set; }

        [JsonPropertyName("distanceToGoal")]
        public decimal DistanceToGoal { get; set; }

        [JsonPropertyName("batteryLevel")]
        public int BatteryLevel { get; set; }
    }
}
