using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.CrossCutting.Extension
{
    public static class ConverterExtension
    {
        public static DateTime ConvertToUserTime(this DateTime dateTime)
        {            
            dateTime = DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            if (DateTimeKind.Utc == DateTimeKind.Local && TimeZoneInfo.Local.IsInvalidTime(dateTime))
                return dateTime;

            return TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.Local);
        }
    }
}
