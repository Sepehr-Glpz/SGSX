namespace SGSX.Dates
{
    public static class Extensions
    {
        static Extensions()
        {
        }

        /// <summary>
        /// converts this instance of DateTime in to an instance of Persian calender datetime.
        /// </summary>
        /// <param name="dateTime">the non-persian DateTime to convert.</param>
        /// <returns>A new instance of System.DateTime representing the converted persian date equivalent.</returns>
        public static System.DateTime ConvertToPersian(this System.DateTime dateTime)
        {
            var persianCalender = new System.Globalization.PersianCalendar();
            int year = persianCalender.GetYear(dateTime);
            int month = persianCalender.GetMonth(dateTime);
            int day = persianCalender.GetDayOfMonth(dateTime);
            int hour = persianCalender.GetHour(dateTime);
            int minute = persianCalender.GetMinute(dateTime);
            int second = persianCalender.GetSecond(dateTime);
            System.DateTime persianDateTime =
                new System.DateTime(year: year, month: month, day: day, hour: hour, minute: minute, second: second);
            return persianDateTime;
        }
        /// <summary>
        /// Converts a string representation of a persian date with a "yyyy:MM:dd HH:mm:ss" format into
        /// its gregorian datetime equivalent.
        /// </summary>
        /// <param name="persianDateTime">the string containing the persian datetime representation.</param>
        /// <returns>A new instance of System.DateTime.</returns>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static System.DateTime ConvertToDateTimeGregorian(this string persianDateTime)
        {
            if (string.IsNullOrWhiteSpace(persianDateTime) == true)
            {
                throw new System.ArgumentNullException(nameof(persianDateTime), "String cannot be null or empty!");
            }
            try
            {
                var text = persianDateTime.Trim();
                var splitter = text.Split(' ');
                var dates = splitter[0].Split('/');
                var times = splitter[1].Split(':');
                var gregDate = new System.DateTime(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2]),
                                                      int.Parse(times[0]), int.Parse(times[1]), int.Parse(times[2])
                                                      , new System.Globalization.PersianCalendar());
                return gregDate;
            }
            catch
            {
                return System.DateTime.MinValue;
            }
        }
        /// <summary>
        /// Converts an instance of DateTime into A string containing the representation of
        /// a persian DateTime instance with a format of "yyyy/MM/dd HH:mm:ss".
        /// </summary>
        /// <param name="dateTime">The datetime instance to convert.</param>
        /// <returns>A string containing the datetime representation.</returns>
        public static string ConvertToPersianString(this System.DateTime dateTime)
        {
            var persianDate = dateTime.ConvertToPersian();
            string result = persianDate.ToString("yyyy/MM/dd HH:mm:ss");
            return result;
        }
        /// <summary>
        /// Converts an instance of DateTime into A string containing the representation of
        /// a persian DateTime instance with a custom format.
        /// </summary>
        /// <param name="dateTime">The datetime instance to convert.</param>
        /// <param name="dateFormat">The format to be used to convert the datetime to a string</param>
        /// <returns>A string containing the datetime representation.</returns>
        /// <exception cref="System.FormatException"></exception>
        public static string ConvertToPersianString(this System.DateTime dateTime,string dateFormat)
        {
            var persianDate = dateTime.ConvertToPersian();
            string result = persianDate.ToString(dateFormat);
            return result;
        }

    }
}
