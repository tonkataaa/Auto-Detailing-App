using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoDetailingApp.Common
{
    public class EntityValidationMessages
    {
       public static class Contact
        {
            public const string NameRequiredMessage = "Моля въведете име!";
            public const string PhoneNumberRequiredMessage = "Моля въведете телефонен номер!";
            public const string EmailRequiredMessage = "Моля въведете имейл!";
            public const string QuestionRequiredMessage = "Моля въведете въпрос!";

            public const string NameMinMessage = "Името трябва да е поне {1} символа.";
            public const string NameMaxMessage = "Името не може да бъде повече от {1} символа.";

			public const string PhoneNumberMinMessage = "Телефонният номер трябва да е поне {1} символа.";
			public const string PhoneNumberMaxMessage = "Телефонният номер не може да бъде повече от {1} символа.";

			public const string EmailMinMessage = "Имейлът трябва да е поне {1} символа.";
			public const string EmailMaxMessage = "Имейлът не може да бъде повече от {1} символа.";

			public const string QuestionMinMessage = "Въпросът трябва да е поне {1} символа.";
			public const string QuestionMaxMessage = "Въпросът не може да бъде повече от {1} символа.";

		}

        public static class User
        {
			public const string NameRequiredMessage = "Моля въведете име!";
			public const string EmailRequiredMessage = "Моля въведете имейл!";
			public const string PhoneNumberRequiredMessage = "Моля въведете телефонен номер!";
			public const string PasswordRequiredMessage = "Моля въведете парола!";

		}
    }
}
