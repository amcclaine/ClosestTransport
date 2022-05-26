namespace ClosestTransport
{
    public class RobotFleetService : IRobotFleetService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RobotFleetService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<List<Robot>> GetRobotFleet()
        {
            try
            {
                var request = new HttpRequestMessage(
                HttpMethod.Get,
                "https://60c8ed887dafc90017ffbd56.mockapi.io/robots"
                );

                var client = _httpClientFactory.CreateClient();
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<Robot>>() ?? new List<Robot>();
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred while requesting robot fleet - {e.Message}");
            }

            return new List<Robot>();
        }
    }
}
