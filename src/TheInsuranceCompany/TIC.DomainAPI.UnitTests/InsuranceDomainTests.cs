using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TIC.DomainAPI.Impl;
using TIC.DomainModel;
using TIC.DomainModel.Request;
using TIC.ServiceAdapter;
#pragma warning disable CS8618

namespace TIC.DomainAPI.UnitTests
{
    [TestClass]
    public class InsuranceDomainTests
    {
        private IInsuranceDomain _domain;
        private Mock<IInsuranceProvider> _providerMock;

        [TestInitialize]
        public void Initialize()
        {
            _providerMock = new Mock<IInsuranceProvider>(MockBehavior.Strict);
            _domain = new InsuranceDomain(_providerMock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _providerMock.VerifyAll();
        }

        [TestMethod]
        public void GetInsurances()
        {
            // Arrange
            var request = new GetInsurancesRequest();
            var getInsurancesResponse = new List<Insurance>
            {
                new CarInsurance
                {
                    Name = "Best Car Insurance",
                    Description = "Covers anything and everything",
                    DateOfBirth = new DateTime(1993, 10, 13),
                    InsurancePremium = 50m,
                    LicensePlate = "HF-430-V",
                    WeightInKg = 1100
                }
            };

            _providerMock.Setup(x => x.GetInsurances()).Returns(getInsurancesResponse);

            var expectedResponse = new List<Insurance>
            {
                new CarInsurance
                {
                    Name = "Best Car Insurance",
                    Description = "Covers anything and everything",
                    DateOfBirth = new DateTime(1993, 10, 13),
                    InsurancePremium = 50m,
                    LicensePlate = "HF-430-V",
                    WeightInKg = 1100
                }
            };

            // Act
            var actual = _domain.GetInsurances(request);

            // Assert
            actual.Should().BeEquivalentTo(expectedResponse);
        }


        [TestMethod]
        public void GetDutchTravelInsurances()
        {
            // Arrange
            var request = new GetDutchTravelInsurancesRequest();
            var getTravelInsurancesResponse = new List<Insurance>
            {
                 new CarInsurance
                {
                    Name = "Best Car Insurance",
                    Description = "Covers anything and everything",
                    DateOfBirth = new DateTime(1993, 10, 13),
                    InsurancePremium = 50m,
                    LicensePlate = "HF-430-V",
                    WeightInKg = 1100
                },
                new TravelInsurance
                {
                    Name = "Best Travel Insurance",
                    Coverage = new List<Country>
                    {
                        new()
                        {
                            Code = "NL",
                            Name = "Netherlands"
                        }
                    },
                    Description = "Insured whilst on the move",
                    InsurancePremium = 20,
                    InsuredAmount = 7000
                },
                new TravelInsurance
                {
                    Name = "Das Travel Insurance",
                    Coverage = new List<Country>
                    {
                        new()
                        {
                            Code = "DE",
                            Name = "Germany"
                        },
                        new()
                        {
                            Code = "ES",
                            Name = "Spain"
                        }
                    },
                    Description = "Insured whilst on the move but within Europe",
                    InsurancePremium = 20,
                    InsuredAmount = 7000
                },
                new TravelInsurance
                {
                    Name = "Cheap Travel Insurance",
                    Coverage = new List<Country>
                    {
                        new()
                        {
                            Code = "US",
                            Name = "United States of America"
                        }
                    },
                    Description = "Murica is expensive",
                    InsurancePremium = 50,
                    InsuredAmount = 25000
                },
                new LiabilityInsurance
                {
                    Name = "A* LiabilityInsurance",
                    Description = "Covers most incidents < 2.5m",
                    Excess = true,
                    ExcessAmount = 500,
                    InsurancePremium = 8,
                    InsuredAmount = 2500000
                }

        };

            _providerMock.Setup(x => x.GetInsurances()).Returns(getTravelInsurancesResponse);

            var expectedResponse = new List<TravelInsurance>
            {
                new TravelInsurance
                {
                    Name = "Best Travel Insurance",
                    Coverage = new List<Country>
                    {
                        new()
                        {
                            Code = "NL",
                            Name = "Netherlands"
                        }
                    },
                    Description = "Insured whilst on the move",
                    InsurancePremium = 20,
                    InsuredAmount = 7000
                }
            };

            // Act
            var actual = _domain.GetDutchTravelInsurances(request);

            // Assert
            actual.Should().BeEquivalentTo(expectedResponse);
        }
    }
}