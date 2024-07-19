using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TIC.DomainAPI.Impl;
using TIC.DomainModel;
using TIC.DomainModel.Request;
using TIC.ServiceAdapter;
using TIC.ServiceAdapter.Services;
#pragma warning disable CS8618

namespace TIC.DomainAPI.UnitTests
{
    [TestClass]
    public class InsuranceDomainTests
    {
        private IInsuranceDomain _domain;
        private Mock<IInsuranceProvider> _providerMock;
        private Mock<IGetDutchTravelInsurances> _getDutchTravelInsurancesMock;

        [TestInitialize]
        public void Initialize()
        {
            _providerMock = new Mock<IInsuranceProvider>(MockBehavior.Strict);
            _getDutchTravelInsurancesMock = new Mock<IGetDutchTravelInsurances>(MockBehavior.Strict);
            _domain = new InsuranceDomain(_providerMock.Object, _getDutchTravelInsurancesMock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _providerMock.VerifyAll();
            _getDutchTravelInsurancesMock.VerifyAll();
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
            //Arrange
            var request = new GetDutchTravelInsurance();
            var getDutchTravelInsuranceResponse = new List<TravelInsurance>
            {
                new TravelInsurance
                {
                    Name = "Dutch Travel Insurance",
                    Description = "DT Insurance",
                    InsurancePremium = 20,
                    InsuredAmount = 6000,
                    Coverage = new List<Country>
                    {
                        new Country {Code="NL", Name="Netherlands"}
                    }                    
                }
            };

            _getDutchTravelInsurancesMock.Setup(i => i.GetDutchTravelInsurancesList()).Returns(getDutchTravelInsuranceResponse);

            var expectedResponse = new List<TravelInsurance>
            {

                new TravelInsurance
                {
                    Name = "Dutch Travel Insurance",
                    Description = "DT Insurance",
                    InsurancePremium = 20,
                    InsuredAmount = 6000,
                    Coverage = new List<Country>
                    {
                        new Country {Code="NL", Name="Netherlands"}
                    }
                }
            };

            //Act
            var actual = _domain.GetDutchTravelInsurances(request);

            //Assert
            actual.Should().BeEquivalentTo(expectedResponse);
        }


        [TestMethod]
        public void GetDutchTravelInsurances_ReturnEmpty_WhenNoDutchTravelInsurances()
        {
            //Arrange
            var request = new GetDutchTravelInsurance();
            var getDutchTravelInsuranceResponse = new List<TravelInsurance>
            {
                new TravelInsurance
                {
                    Name = "Dutch Travel Insurance",
                    Description = "DT Insurance",
                    InsurancePremium = 20,
                    InsuredAmount = 6000,
                    Coverage = new List<Country>
                    {
                        new Country {Code="LV", Name="Latvia"}
                    }
                }
            };

            _getDutchTravelInsurancesMock.Setup(i => i.GetDutchTravelInsurancesList()).Returns(getDutchTravelInsuranceResponse);

            var expectedResponse = new List<TravelInsurance>
            {

                new TravelInsurance
                {
                    Name = "Dutch Travel Insurance",
                    Description = "DT Insurance",
                    InsurancePremium = 20,
                    InsuredAmount = 6000,
                    Coverage = new List<Country>
                    {
                        new Country {Code="LV", Name="Latvia"}
                    }
                }
            };

            //Act
            var actual = _domain.GetDutchTravelInsurances(request);

            //Assert
            actual.Should().BeEquivalentTo(expectedResponse);
        }
    }
}