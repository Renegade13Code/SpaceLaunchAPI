using SpaceLaunchAPI.Buidler;
using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Builder
{
    public class LaunchBuilder : IBuilderLaunches
    {
        Launch launch = new Launch();
        public Launch getLaunch()
        {
            return launch;
        }

        public void setFailure(string failure)
        {
            launch.Failures = failure;
        }

        public void setLaunchDate(DateTime launchDate)
        {
            launch.Date = launchDate;
        }

        public void setLaunchId(string launchId)
        {
            launch.LaunchId = launchId;
        }

        public void setLaunchName(string launchName)
        {
            launch.Name = launchName;
        }

        public void setLaunchPadId(string launchPadId)
        {
            launch.LaunchpadId = launchPadId;
        }

        public void setRocketId(string rocketId)
        {
            launch.RocketId = rocketId;
        }

        public void setSuccess(bool success)
        {
            launch.Success = success;
        }
    }
}
