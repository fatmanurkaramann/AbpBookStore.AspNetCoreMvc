using AbpBookApp.Debugging;

namespace AbpBookApp
{
    public class AbpBookAppConsts
    {
        public const string LocalizationSourceName = "AbpBookApp";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "7532fece016d49b2a3db27c2d117dfbe";
    }
}
