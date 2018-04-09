[![NuGet](https://img.shields.io/nuget/v/FeatureToggle.svg)](https://www.nuget.org/packages/solar-calculator/)
[![Build status](https://ci.appveyor.com/api/projects/status/15ksq277kalcdou5?svg=true)](https://ci.appveyor.com/project/ra1han/solar-calculator)

### Solar Calculator
Calculate the sunset and sunrise time based on the date and the latitude/longitude.

The implementation is based on the algorithm found in these two links -
1. [Sunrise Equation](https://en.wikipedia.org/wiki/Sunrise_equation)
2. [Sun position](http://aa.quae.nl/en/reken/zonpositie.html)

The project is available in nuget - https://www.nuget.org/packages/solar-calculator/

#### Usage
```csharp

// Dhaka
var location = new
{
	latitude = 23.777176,
	longitude = 90.399452,
};
var theDate = new DateTime(2018, 1, 1);  // Jan 1 2018          
var results = theDate.Times(location.latitude, location.longitude, TimeSpan.FromHours(18)); // UTC offset for locale on Jan 1, not using daylight savings
```
