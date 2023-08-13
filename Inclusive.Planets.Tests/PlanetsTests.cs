using Inclusive.Planets.Core.Interfaces;
using Inclusive.Planets.Core.Models;
using Inclusive.Planets.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Inclusive.Planets.Tests
{
    public class Tests
    {
        Mock<IPlanetRepository> planetsRepositoryMock = null;
        [SetUp]
        public void Setup()
        {
            // Arrange
            var dbSetMock = new Mock<DbSet<Planet>>();
            var dbContextMock = new Mock<PlanetsDBContext>();
            dbContextMock.Setup(s => s.Set<Planet>()).Returns(dbSetMock.Object);
            planetsRepositoryMock = new Mock<IPlanetRepository>();
        }

        [Test]
        public void Planets_Returns_All()
        {
            // Act
            List<Planet> _planets = new List<Planet>
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

            planetsRepositoryMock.Setup(s => s.GetPlanets()).Returns(Task.FromResult(_planets));

            var allPlanets = planetsRepositoryMock.Object.GetPlanets();

            //Assert  
            Assert.NotNull(allPlanets);
        }

        [Test]
        public void Planet_By_Name()
        {
            // Act
            string planetName = "Earth";

            planetsRepositoryMock.Setup(s => s.GetPlanet(It.IsAny<string>())).Returns(Task.FromResult(new Planet { PlanetName = "Earth", Mass = 1, Diameter = 1, Distance = 1.00 }));

            var planet = planetsRepositoryMock.Object.GetPlanet(planetName);

            //Assert  
            Assert.IsTrue(planet.Result.PlanetName == planetName);
        }
    }
}