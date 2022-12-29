﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KTITSTimetableApp
{
    internal static class Utils
    {
        public static List<Lesson[]> TT;
        public static List<TimeSpan> CallsToday => (int)DateTime.Now.DayOfWeek == 6 ? CallsSat : Calls;
        public static List<TimeSpan> Calls;
        public static List<TimeSpan> CallsSat;

        public static TimeSpan CurrentNextTime
        {
            get
            {
                var mbNow = CallsToday.Where(i => i.TotalDays > DateTime.Now.TimeOfDay.TotalDays);
                if (mbNow.Count() == 0)
                    return CallsToday.First();
                else return mbNow.First();
            }
        }
        public static Lesson[] Today;
        public static void UpdateTT()
        {
            var i = (int)DateTime.Today.DayOfWeek;
            Today = TT[i - 1];
        }
        public static TimeSpan LastTime
        {
            get
            {
                int id = CallsToday.IndexOf(CurrentNextTime);
                if (id == -1 || id == 0)
                    return CallsToday.Last();
                else
                    return CallsToday[id - 1];
            }
        }
        public static TimeSpan TrueTimeSub(TimeSpan t1, TimeSpan t2)
        {
            if (t2 < t1)
                return t1.Subtract(t2);
            else return TimeSpan.FromDays(1).Subtract(t2) + t1;
        }
        public static string LoadFile(string fileLink)
        {
            using (HttpClient cl = new HttpClient())
            {
                var loadLink = cl.GetAsync($"https://cloud-api.yandex.net/v1/disk/public/resources/download?public_key=" + fileLink).Result.Content.ReadAsStringAsync().Result;
                var finalLink = JsonDocument.Parse(loadLink).RootElement.GetProperty("href").GetString();
                var fileContent = cl.GetAsync(finalLink).Result.Content.ReadAsStringAsync().Result;
                return fileContent;
            }
        }
    }
}
