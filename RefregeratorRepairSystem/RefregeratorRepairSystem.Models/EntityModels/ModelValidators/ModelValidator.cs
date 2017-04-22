namespace RefregeratorRepairSystem.Models.EntityModels.ModelValidators
{
    public static class ModelValidator
    {
        public static bool ChekIfNameIsValid(string name)
        {
            return name.Length >= 3 && name.Length <= 50;
        }

        public static bool CheckIfAcctionsIsValid(string actions)
        {
            return actions.Length >= 3;
        }

        public static bool CheckIfAddressIsValid(string address)
        {
            return address.Length >= 5;
        }

        public static bool ChekIfPriceIsValid(decimal price)
        {
            return price >= 0.0m;
        }

        public static bool ChekIfQuantityIsValid(int quantity)
        {
            return quantity >= 0;
        }
    }
}
