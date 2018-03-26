[![NuGet](https://img.shields.io/nuget/v/FeatureToggle.svg)](https://www.nuget.org/packages/solarday-calculator)
[![Build status](https://ci.appveyor.com/api/projects/status/5di2f2f5qb6ccd6v?svg=true)](https://ci.appveyor.com/project/Siliconrob/solar-calculator)
[![Build Status](https://travis-ci.org/Siliconrob/solar-calculator.svg?branch=master)](https://travis-ci.org/Siliconrob/solar-calculator)

### Solar Calculator
Calculate the sunset and sunrise time based on the date and the latitude/longitude.

The implementation is based on the algorithm found in these two links -
1. https://en.wikipedia.org/wiki/Sunrise_equation/
2. http://aa.quae.nl/en/reken/zonpositie.html/

The project is available in nuget - https://www.nuget.org/packages/solarday-calculator/

### Usage
// Fort Worth
var location = new
{
	latitude = 32.768799,
	longitude = -97.309341,
};
var theDate = new DateTime(2018, 1, 1);  // Jan 1 2018          
var results = theDate.Times(location.latitude, location.longitude, TimeSpan.FromHours(-6)); // UTC offset for locale on Jan 1, not using daylight savings
