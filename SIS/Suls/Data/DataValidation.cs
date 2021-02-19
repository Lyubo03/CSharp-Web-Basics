namespace Suls.Data
{
    public static class DataValidation
    {
        //User attributes values 
        public static class UserValues
        {
            public const int UsernameMaxLength = 20;
            public const int UsernameMinLength = 5;

        }

        //Repository attributes values
        public static class RepositoryValues
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 10;
        }

        //Commit attributes values
        public static class CommitValues
        {
            public const int DescriptionMinLength = 3;
        }
    }
}