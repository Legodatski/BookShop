namespace BookShop.Constants
{
    public class GlobalConstants
    {
        //User
        public const int FirstNameMaxLenght = 15;
        public const int FirstNameMinLenght = 2;

        public const int LastNameMaxLenght = 15;
        public const int LastNameMinLenght = 2;

        public const int PasswordMaxLenght = 10;
        public const int PasswordMinLenght = 5;

        public const int PhoneLenght = 10;

        //Town
        public const int TownNameMaxLenght = 50;
        public const int TownNameMinLenght = 3;

        //School
        public const int SchoolNameMaxLenght = 50;
        public const int SchoolNameMinLenght = 5;

        //Publisher
        public const int PublisherNameMaxLenght = 20;
        public const int PublisherNameMinLenght = 5;

        //Book
        public const int BookTitleMaxLenght = 20;
        public const int BookTitleMinLenght = 3;

        public const int BookYearMax = 2023;
        public const int BookYearMin = 1999;

        public const int BookGradeMax = 13;
        public const int BookGradeMin = 1;

        public const double BookPriceMax = double.MaxValue;
        public const double BookPriceMin = 0;
    }
}
