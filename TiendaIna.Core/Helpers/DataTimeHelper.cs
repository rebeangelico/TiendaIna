

namespace TiendaIna.Core;
public static class DateTimeHelper
{
    
        private const string ArgentinaFormat = "dd-MM-yyyy HH:mm:ss";
        public static string ToArgentinaFormat(DateTimeOffset dateTime)
        {
            var argentinaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Argentina Standard Time");
            var argentinaTime = TimeZoneInfo.ConvertTime(dateTime, argentinaTimeZone);

            return argentinaTime.ToString(ArgentinaFormat);
        }
}
