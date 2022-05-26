using System.Text.Json.Serialization;

namespace ClosestTransport
{
    public class ClosestRobotRequest
    {
        [JsonPropertyName("loadId")]
        public int LoadId { get; set; }

        [JsonPropertyName("x")]
        public int XCoordinate { get; set; }

        [JsonPropertyName("y")]
        public int YCoordinate { get; set; }
    }
}
