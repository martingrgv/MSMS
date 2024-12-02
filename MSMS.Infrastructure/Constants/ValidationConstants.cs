namespace MSMS.Infrastructure.Constants
{
    public static class ValidationConstants
    {
        // General 
        public const int DESCRIPTION_MIN_LENGTH = 0;
        public const int DESCRIPTION_MAX_LENGTH = 120;

        // User
        public const int FIRSTNAME_MIN_LENGTH = 2;
        public const int FIRSTNAME_MAX_LENGTH = 50;
        public const int LASTNAME_MIN_LENGTH = 2;
        public const int LASTNAME_MAX_LENGTH = 50;
        public const int USERNAME_MIN_LENGTH = 2;
        public const int USERNAME_MAX_LENGTH = 16;

        // Server
        public const int SERVER_NAME_MIN_LENGTH = 4;
        public const int SERVER_NAME_MAX_LENGTH = 25;
        public const int SERVER_IP_ADDRESS_MIN_LENGTH = 4;
        public const int SERVER_IP_ADDRESS_MAX_LENGTH = 31;
        public const int SERVER_GAME_VERSION_MIN_LENGTH = 3;
        public const int SERVER_GAME_VERSION_MAX_LENGTH = 6;

        // Location
        public const int LOCATION_NAME_MIN_LENGTH = 2;
        public const int LOCATION_NAME_MAX_LENGTH = 50;
        public const int LOCATION_COORDINATES_MIN_LENGTH = 3;
        public const int LOCATION_COORDINATES_MAX_LENGTH = 24;

        // Todo List
        public const int TODO_LIST_NAME_MIN_LENGTH = 3;
        public const int TODO_LIST_NAME_MAX_LENGTH = 15;
        public const int TODO_NAME_MIN_LENGTH = 3;
        public const int TODO_NAME_MAX_LENGTH = 15;
    }
} 