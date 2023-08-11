namespace Inclusive.Planets.Core.Interfaces
{
    public interface IPlanetRepository
    {
        Task<List<Core.Models.Planet>> GetPlanets();

        Task<Core.Models.Planet> GetPlanet(string planetName);

        bool UploadPlanetInformation();
    }
}
