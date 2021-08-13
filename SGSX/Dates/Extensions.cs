namespace SGSX.Dates
{
    public static class Extensions
    {
        static Extensions()
        {
        }
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
        public static System.DateTime ConvertToDateTimeGregorian(this string persianDateTime)
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
        public static string ConvertToPersianString(this System.DateTime dateTime)
        {
            var persianDate = dateTime.ConvertToPersian();
            string result = persianDate.ToString("yyyy/MM/dd HH:mm:ss");
            return result;
        }
    }
}
