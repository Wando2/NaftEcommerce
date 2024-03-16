using Flunt.Validations;
using Naft.Domain.Entities;

namespace Naft.Domain.ValueObjects;

public class Address : ValueObject
{
    
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
    {
        Street = street;
        Number = number;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;


        AddNotifications(new Contract<Address>()
            .IsNotNullOrEmpty(street, "Address.street", "O nome da rua é obrigatório")
            .IsNotNullOrEmpty(number, "Address.number", "O número é obrigatório")
            .IsNotNullOrEmpty(neighborhood, "Address.neighborhood", "O bairro é obrigatório")
            .IsNotNullOrEmpty(city, "Address.city", "A cidade é obrigatória")
            .IsNotNullOrEmpty(state, "Address.state", "O estado é obrigatório")
            .IsNotNullOrEmpty(country, "Address.country", "O país é obrigatório")
            .IsNotNullOrEmpty(zipCode, "Address.zipCode", "O CEP é obrigatório")
        );
        
        if (!IsValid)
            return;
        
        AddNotifications(new Contract<Category>()
            .Requires()
            .IsLowerThan(2,street.Length, "Address.street", "O nome da rua deve ter pelo menos 3 caracteres")
            .IsLowerThan(2,number.Length, "Address.number", "O número deve ter pelo menos 3 caracteres")
            .IsLowerThan(2,neighborhood.Length, "Address.neighborhood", "O bairro deve ter pelo menos 3 caracteres")
            .IsLowerThan(2,city.Length, "Address.city", "A cidade deve ter pelo menos 3 caracteres")
            .IsLowerThan(2,state.Length, "Address.state", "O estado deve ter pelo menos 3 caracteres")
            .IsLowerThan(2,country.Length, "Address.country", "O país deve ter pelo menos 3 caracteres")
            .IsLowerThan(2,zipCode.Length, "Address.zipCode", "O CEP deve ter pelo menos 3 caracteres")
            .IsGreaterThan(39,street.Length, "Address.street", "O nome da rua deve ter no máximo 40 caracteres")
            .IsGreaterThan(39,number.Length, "Address.number", "O número deve ter no máximo 40 caracteres")
            .IsGreaterThan(39,neighborhood.Length, "Address.neighborhood", "O bairro deve ter no máximo 40 caracteres")
            .IsGreaterThan(39,city.Length, "Address.city", "A cidade deve ter no máximo 40 caracteres")
            .IsGreaterThan(39,state.Length, "Address.state", "O estado deve ter no máximo 40 caracteres")
            .IsGreaterThan(39,country.Length, "Address.country", "O país deve ter no máximo 40 caracteres")
            .IsGreaterThan(39,zipCode.Length, "Address.zipCode", "O CEP deve ter no máximo 40 caracteres")
        );
            
    }
    
    public Address()
    {
    }
}