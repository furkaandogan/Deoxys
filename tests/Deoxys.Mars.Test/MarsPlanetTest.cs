using System;
using System.Collections.Generic;
using Xunit;
using Deoxys.Planets;
using Deoxys.Mars;

namespace Deoxys.Mars.Test
{
    public class MarsPlanetTest
    {

        [Theory]
        [InlineData(5, 5)]
        [InlineData(3, 3)]
        [InlineData(31, 69)]
        public void PlanetSize_True(int width, int heigth)
        {
            IPlanet planet = new MarsPlanet(width, heigth);
            Assert.Equal(width, planet.Size.Width);
            Assert.Equal(heigth, planet.Size.Height);
        }

    }
}
