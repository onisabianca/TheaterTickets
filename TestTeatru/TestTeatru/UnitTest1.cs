using Moq;
using System;
using System.Collections.Generic;
using Teatru.Bussines;
using Teatru.Data;
using Teatru.Models;
using Xunit;

namespace TestTeatru
{
    public class UnitTest1
    {
        [Fact]
        public void TestNrBilete()
        { 
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            
            List<Spectacol> spectacole = new List<Spectacol>();
            spectacole.Add(new Spectacol("Dama cu camelii", "regizor", "actori", new DateTime(), 1));

            BiletService biletService = new BiletService(mockUnitOfWork.Object);
            mockUnitOfWork.Setup(mockUnitOfWork => mockUnitOfWork.Spectacole.GetAll().Result).Returns(spectacole);

            Assert.True(biletService.isBiletAvailable("Dama cu camelii"));
        }
    }
}
