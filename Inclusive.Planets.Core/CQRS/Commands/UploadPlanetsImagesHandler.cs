using Inclusive.Planets.Core.Interfaces;
using MediatR;

namespace Inclusive.Planets.Core.CQRS.Commands
{
    public class UploadPlanetsImages : IRequest<bool>
    {
    }

    public class UploadPlanetsImagesHandler : IRequestHandler<UploadPlanetsImages, bool>
    {
        private readonly IPlanetRepository _planetRepository;

        public UploadPlanetsImagesHandler(IPlanetRepository exceptionRepository)
        {
            _planetRepository = exceptionRepository;
        }

        public async Task<bool> Handle(UploadPlanetsImages request, CancellationToken cancellationToken)
        {
            var result = this._planetRepository.UploadPlanetInformation();
            return result;
        }
    }
}
