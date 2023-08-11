using Inclusive.Planets.Core.Interfaces;
using MediatR;

namespace Inclusive.Planets.Core.CQRS.Queries
{
    public class GetPlanet : IRequest<Inclusive.Planets.Core.Models.Planet>
    {
        public string planetName { get; set; }
        public GetPlanet(string planetName)
        {
            this.planetName = planetName;
        }
    }

    public class GetPlanetHandler : IRequestHandler<GetPlanet, Inclusive.Planets.Core.Models.Planet>
    {
        private readonly IPlanetRepository _planetRepository;

        public GetPlanetHandler(IPlanetRepository exceptionRepository)
        {
            _planetRepository = exceptionRepository;
        }

        public async Task<Inclusive.Planets.Core.Models.Planet> Handle(GetPlanet request, CancellationToken cancellationToken)
        {
            var result = await this._planetRepository.GetPlanet(request.planetName);
            return result;
        }
    }
}
