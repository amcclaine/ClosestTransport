namespace ClosestTransport
{
    public interface IRobotFleetService
    {
        Task<List<Robot>> GetRobotFleet();
    }
}
