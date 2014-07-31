using Merp.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merp.Accountancy.CommandStack.Model
{
    public class Invoice : Aggregate
    {
        public Guid Id { get; protected set; }
        public PartyInfo Customer { get; protected set; }
        
        public class PartyInfo
        {
            public Guid Id { get; private set; }
            public string Name { get; private set; }
            public string StreetName { get; private set; }
            public string City { get; private set; }
            public string PostalCode { get; private set; }
            public string Country { get; private set; }
            public string VatIndex { get; private set; }
            public string NationalIdentificationNumber { get; private set; }

            public PartyInfo(Guid customerId, string customerName, string streetName, string city, string postalCode, string country, string vatIndex, string nationalIdentificationNumber)
            {
                City = city;
                Name=customerName;
                Country = country;
                Id = customerId;
                NationalIdentificationNumber = nationalIdentificationNumber;
                PostalCode = postalCode;
                StreetName=streetName;
                VatIndex = vatIndex;
            }
        }
    }
}
