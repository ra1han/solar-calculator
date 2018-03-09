# Solar Calculator
Calculate the sunset and sunrise time based on the date and the latitude/longitude.

The implementation is based on the algorithm found in these two links -
1. https://en.wikipedia.org/wiki/Sunrise_equation/
2. http://aa.quae.nl/en/reken/zonpositie.html/

The project is available in nuget - https://www.nuget.org/packages/solar-calculator/

### Usage
            //Dhaka's location
            var latitude = 23.8103; 
            var longitude = 90.4125;
            var date = new DateTime(2018, 3, 9);
            var utcOffset = 18;
            var dayLightSaving = false;

            var solarCalculator = new SolarCalculator(latitude, longitude, date);
            var sunrise = solarCalculator.GetSunRise(utcOffset, dayLightSaving);
            var sunset = solarCalculator.GetSunSet(utcOffset, dayLightSaving);
