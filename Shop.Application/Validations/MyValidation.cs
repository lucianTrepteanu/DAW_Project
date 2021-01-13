using Shop.Application.Cart;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shop.Domain.Models
{
    public class MyValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var cities = new List<string>();
            cities.Add("Alba Iulia");
            cities.Add("Arad");
            cities.Add("Pitesti");
            cities.Add("Bacau");
            cities.Add("Oradea");
            cities.Add("Bistrita");
            cities.Add("Botosani");
            cities.Add("Braila");
            cities.Add("Brasov");
            cities.Add("Buzau");
            cities.Add("Calarasi");
            cities.Add("Resita");
            cities.Add("Cluj-Napoca");
            cities.Add("Constanta");
            cities.Add("Sfantu Gheorghe");

            cities.Add("Targoviste");
            cities.Add("Craiova");
            cities.Add("Galati");
            cities.Add("Giurgiu");
            cities.Add("Targu Jiu");
            cities.Add("Miercurea Ciuc");
            cities.Add("Deva");
            cities.Add("Slobozia");
            cities.Add("Iasi");
            cities.Add("Bucuresti");
            cities.Add("Baia-Mare");
            cities.Add("Drobeta Turnu-Severin");
            cities.Add("Targu Mures");
            cities.Add("Piatra Neamt");
            cities.Add("Slatina");
            cities.Add("Ploiesti");
            cities.Add("Zalau");

            cities.Add("Satu-Mare");
            cities.Add("Sibiu");
            cities.Add("Suceava");
            cities.Add("Alexandria");
            cities.Add("Timisoara");
            cities.Add("Tulcea");
            cities.Add("Ramnicu Valcea");
            cities.Add("Vaslui");

            AddCustomerInformation.Request contact = (AddCustomerInformation.Request)validationContext.ObjectInstance;
            string city = contact.City;

            if (!cities.Contains(city))
            {
                return new ValidationResult("Please insert nearest County Residence");
            }

            return ValidationResult.Success;
        }
    }
}
