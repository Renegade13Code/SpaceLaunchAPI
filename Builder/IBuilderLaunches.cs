using SpaceLaunchAPI.Models.Domain;

namespace SpaceLaunchAPI.Buidler
{
    public interface IBuilderLaunches
    {
        public void setLaunchId(string launchId); //generated 
        public void setLaunchName(string launchName);
        public void setLaunchDate(DateTime launchDate);
        public void setRocketId(string rocketId);
        public void setLaunchPadId(string launchPadId);
        public void setSuccess(Boolean success);
        public void setFailure(string failure);

        public Launch getLaunch();
    }
}
