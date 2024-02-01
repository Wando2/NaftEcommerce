using Flunt.Validations;

namespace Naft.Domain.ValueObjects;

public class Address : ValueObject
{
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
            .Requires()
            .IsNotNullOrEmpty(Street, nameof(Street), "A Rua é obrigatória")
            .IsLowerThan(2,Street.Length, nameof(Street), "A Rua deve ter no mínimo 3 caracteres")
            .IsGreaterThan(80,Street.Length, nameof(Street), "A Rua deve ter no máximo 80 caracteres")
            .IsNotNullOrEmpty(Number, nameof(Number), "O Número é obrigatório")
            .IsLowerThan(2,Number.Length, nameof(Number), "O Número deve ter no mínimo 3 caracteres")
            .IsGreaterThan(10,Number.Length, nameof(Number), "O Número deve ter no máximo 10 caracteres")
            .IsNotNullOrEmpty(Neighborhood, nameof(Neighborhood), "O Bairro é obrigatório")
            .IsLowerThan(2,Neighborhood.Length, nameof(Neighborhood), "O Bairro deve ter no mínimo 3 caracteres")
            .IsGreaterThan(80,Neighborhood.Length, nameof(Neighborhood), "O Bairro deve ter no máximo 80 caracteres")
            .IsNotNullOrEmpty(City, nameof(City), "A Cidade é obrigatória")
            .IsLowerThan(2,City.Length, nameof(City), "A Cidade deve ter no mínimo 3 caracteres")
            .IsGreaterThan(80,City.Length, nameof(City), "A Cidade deve ter no máximo 80 caracteres")
            .IsNotNullOrEmpty(State, nameof(State), "O Estado é obrigatório")
            .IsLowerThan(2,State.Length, nameof(State), "O Estado deve ter no mínimo 3 caracteres")
            .IsGreaterThan(80,State.Length, nameof(State), "O Estado deve ter no máximo 80 caracteres")
            .IsNotNullOrEmpty(Country, nameof(Country), "O País é obrigatório")
            .IsLowerThan(2,Country.Length, nameof(Country), "O País deve ter no mínimo 3 caracteres")
            .IsGreaterThan(80,Country.Length, nameof(Country), "O País deve ter no máximo 80 caracteres")
            .IsNotNullOrEmpty(ZipCode, nameof(ZipCode), "O CEP é obrigatório")
            .IsLowerThan(2,ZipCode.Length, nameof(ZipCode), "O CEP deve ter no mínimo 3 caracteres")
            .IsGreaterThan(10,ZipCode.Length, nameof(ZipCode), "O CEP deve ter no máximo 10 caracteres")
            
            
        );
        
    }
    
   
    
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    
}