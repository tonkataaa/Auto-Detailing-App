namespace AutoDetailingApp.Common
{
	public static class EntityValidationConstants
	{
		public static class User
		{
			public const int FullNameMaxLength = 200;
			public const int EmailMaxLength = 200;
			public const int PhoneNumberMaxLength = 20;
			public const int PasswordHashMaxLength = 128;
			public const int RoleMaxLength = 50;


		}

		public static class Service
		{
			public const int NameMinLength = 3;
			public const int NameMaxLength = 50;

			public const int QuestionMinLength = 5;
			public const int QuestionMaxLength = 300;

			//public const int NameMaxLength = 250;
			public const int DescriptionMaxLength = 500;

		}

		public static class ContactRequest
		{
			public const int NameMinLength = 3;
			public const int NameMaxLength = 50;

			public const int QuestionMinLength = 5;
			public const int QuestionMaxLength = 300;


			public const int EmailMinLength = 3;
			public const int EmailMaxLength = 320;

			public const int PhonenumberMinLength = 10;
			public const int PhoneNumberMaxLength = 15;
		}

		public static class Appointment
		{
			public const int FullNameMaxLength = 200;
			public const int EmailMaxLength = 200;
			public const int PhoneNumberMaxLength = 20;
			public const int StatusMaxLength = 30;
		}

	}
}

