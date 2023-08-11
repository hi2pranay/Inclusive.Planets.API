using Inclusive.Planets.Core.Interfaces;
using Inclusive.Planets.Core.Models;
using Inclusive.Planets.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Inclusive.Planets.Infrastructure.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        private readonly List<Planet> _planets = new List<Planet>
        {
            new Planet { PlanetName = "Mercury", Mass = 0.0553, Diameter = 0.383, Distance = 0.39 },
            new Planet { PlanetName = "Venus", Mass = 0.815, Diameter = 0.949, Distance = 0.72 },
            new Planet { PlanetName = "Earth", Mass = 1, Diameter = 1, Distance = 1.00  },
            new Planet { PlanetName = "Mars", Mass = 0.107, Diameter = 0.532, Distance = 1.52 },
            new Planet { PlanetName = "Jupiter", Mass = 317.8, Diameter = 11.21 , Distance = 5.20},
            new Planet { PlanetName = "Saturn", Mass = 95.2, Diameter = 9.45 , Distance = 9.54 },
            new Planet { PlanetName = "Uranus", Mass = 14.5, Diameter = 4.01 , Distance = 19.22 },
            new Planet { PlanetName = "Neptune", Mass = 17.1, Diameter = 3.88, Distance = 30.06 },
        };

        private readonly PlanetsDBContext _planetDbContext;

        public PlanetRepository(PlanetsDBContext planetDbContext)
        {
            this._planetDbContext = planetDbContext;
        }

        public async Task<Planet> GetPlanet(string planetName)
        {
            return await this._planetDbContext.Planets.FirstOrDefaultAsync(a => a.PlanetName.ToLower().Equals(planetName.ToLower()));
        }

        public async Task<List<Planet>> GetPlanets()
        {
            return await this._planetDbContext.Planets.ToListAsync();
        }

        public bool UploadPlanetInformation()
        {
            try
            {
                string path = Directory.GetCurrentDirectory();

                // Only get files that are text files only as you want only .png 
                string[] dirs = Directory.GetFiles(path + "\\Images", "*.png");

                foreach (string file in dirs)
                {
                    string imageName = Path.GetFileName(file);
                    string imageNameWithoutExt = Path.GetFileNameWithoutExtension(file);

                    var isRecordExists = this._planetDbContext.Planets.Count(a => a.PlanetName.ToLower().Equals(imageNameWithoutExt.ToLower()));
                    if (isRecordExists == 0)
                    {
                        Planet currentPlanet = _planets.FirstOrDefault(a => a.PlanetName.ToLower().Equals(imageNameWithoutExt.ToLower()));
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (FileStream fileStream = new FileStream(path + "\\Images\\" + imageName, FileMode.Open, FileAccess.Read))
                            {
                                byte[] bytes = new byte[fileStream.Length];
                                fileStream.Read(bytes, 0, (int)fileStream.Length);
                                ms.Write(bytes, 0, (int)fileStream.Length);

                                this._planetDbContext.Planets.Add(new Planet
                                {
                                    PlanetName = Path.GetFileNameWithoutExtension(file),
                                    PlanetImageTitle = Path.GetFileName(file),
                                    PlanetImage = ms.ToArray(),
                                    Mass = currentPlanet.Mass,
                                    Diameter = currentPlanet.Diameter,
                                    Distance = currentPlanet.Distance
                                });
                                this._planetDbContext.SaveChanges();
                            }
                        }
                    }
                }

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
