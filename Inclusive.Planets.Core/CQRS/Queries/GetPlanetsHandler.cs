using Inclusive.Planets.Core.Interfaces;
using MediatR;

namespace Inclusive.Planets.Core.CQRS.Queries
{
    public class GetPlanets : IRequest<List<Inclusive.Planets.Core.Models.Planet>>
    {
    }

    public class GetPlanetsHandler : IRequestHandler<GetPlanets, List<Inclusive.Planets.Core.Models.Planet>>
    {
        private readonly IPlanetRepository _planetRepository;

        public GetPlanetsHandler(IPlanetRepository exceptionRepository)
        {
            _planetRepository = exceptionRepository;
        }

        public async Task<List<Inclusive.Planets.Core.Models.Planet>> Handle(GetPlanets request, CancellationToken cancellationToken)
        {
            var result = await this._planetRepository.GetPlanets();
            return result;
        }
    }
}
