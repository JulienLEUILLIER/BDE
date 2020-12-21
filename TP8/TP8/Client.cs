using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public abstract class Client
    {
        public readonly string _lastname;

        public readonly string _firstname;

        public readonly short _age;
        private void FormatName(ref string name)
        {
            name = name.ToUpper();
        }

        private void FormatSurname(ref string surname)
        {
            surname = char.ToUpper(surname[0]) + surname[1..].ToLower();
        }

        public Client(string name, string surname, short age)
        {
            FormatName(ref name);
            FormatSurname(ref surname);
            _lastname = name;
            _firstname = surname;
            _age = age;
        }

        public string GetName()
        {
            return _lastname + " " + _firstname;
        }

        public decimal GetAppropriatePrice(Product product)
        {
            decimal appropriatePrice;
            appropriatePrice = this is Student ?
                product._memberPrice : product._notMemberPrice;
            return appropriatePrice;
        }

        public bool CanBuy(Product product)
        {
            if (this._age <= 18 && product is AlcoholicBeverage)
                return false;
            return true;
        }

        public static bool operator ==(Client client1, Client client2)
        {
            return client1.GetName() == client2.GetName();
        }

        public static bool operator !=(Client client1, Client client2)
        {

            return !(client1 == client2);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
