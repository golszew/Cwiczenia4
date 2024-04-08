using System;

namespace LegacyApp
{
    public class UserService
    {

        private static bool CheckIfNameIsInvalid(string firstName, string lastName) =>
            string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName);

        private static bool CheckIfEmailAddressIsInvalid(string email) => !email.Contains("@") && !email.Contains(".");
        
        private static bool CheckIfUserIsUnderAgeOf21(DateTime dateOfBirth){
            var now = DateTime.Now;
            var age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age < 21;
        }
        public static bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (CheckIfNameIsInvalid(firstName, lastName))
                return false;

            if (CheckIfEmailAddressIsInvalid(email))
            {
                return false;
            }
            

            if (CheckIfUserIsUnderAgeOf21(dateOfBirth))
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            return user.RefactoredFunction(client);
        }
    }
}
