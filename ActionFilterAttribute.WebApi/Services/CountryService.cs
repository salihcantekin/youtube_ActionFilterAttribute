using ActionFilterAttribute.WebApi.Models;

namespace ActionFilterAttribute.WebApi.Services;

public class CountryService
{
    public IEnumerable<Country> GetAllCountries()
    {
        return new List<Country>()
        { 
            new Country(){ Name = "Türkiye" },
            new Country(){ Name = "Ukrayna" },
            new Country(){ Name = "Hindistan" },
            new Country(){ Name = "Kanada" },
            new Country(){ Name = "Hollanda" },
            new Country(){ Name = "Belçika" },
            new Country(){ Name = "Fransa" },
            new Country(){ Name = "Almanya" },
            new Country(){ Name = "Birleşik Krallık" }
        };
    }
}
