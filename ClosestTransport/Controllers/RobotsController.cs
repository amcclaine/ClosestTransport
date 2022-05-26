using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClosestTransport.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class RobotsController : ControllerBase
    {
        private readonly IRobotFleetService _robotFleetService;

        public RobotsController(IRobotFleetService robotFleetService)
        {
            _robotFleetService = robotFleetService;
        }
        [Route("closest/")]
        [HttpPost]
        public async Task<ActionResult<ClosestRobotResponse>> PostClosestRobot([FromBody] ClosestRobotRequest closestRobotRequest)
        {
            try
            {
                var robotFleet = await _robotFleetService.GetRobotFleet();

                var closestRobots = FindClosestRobot(closestRobotRequest, robotFleet).ToList();

                if (closestRobots.Any())
                {
                    var closestRobot = closestRobots.MaxBy(x => x.BatteryLevel);
                    return Ok(closestRobot);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "Internal Server Error");
            }
        }

        private IEnumerable<ClosestRobotResponse> FindClosestRobot(ClosestRobotRequest closestRobotRequest, List<Robot> robotFleet)
        {
            var fleetWithDistance = robotFleet.Select(
                robot => new ClosestRobotResponse
                {
                    RobotId = robot.RobotId,
                    BatteryLevel = robot.BatteryLevel,
                    DistanceToGoal = CalculateDistanceToGoal(closestRobotRequest.XCoordinate,
                        closestRobotRequest.YCoordinate, robot.XCoordinate, robot.YCoordinate)
                }).ToList();

            var minimumDistance = fleetWithDistance.Min(x => x.DistanceToGoal);
            var closestRobots = fleetWithDistance.Where(x => x.DistanceToGoal == minimumDistance);
            return closestRobots;
        }

        private decimal CalculateDistanceToGoal(int targetXCoord, int targetYCoord, int xCoord, int yCoord)
        {
            return (decimal)Math.Sqrt((Math.Pow(targetXCoord - xCoord, 2) + Math.Pow(targetYCoord - yCoord, 2)));
        }

    }
}
