using System.Text.Json;

namespace KTITSLive
{
    public class Homework
    {
        
        public Dictionary<DateTime, string[]> HW { get; set; }
        public Homework()
        {
            HW = new Dictionary<DateTime, string[]>();
        }
        public void Set(DateTime date, int lesson, string homework)
        {
            if(HW.ContainsKey(date) )
            {
                var day = HW[date];
                day[lesson] = homework;
                HW[date] = day;
            }
            else
            {
                HW.Add(date, new string[8]);
                var day = HW[date];
                day[lesson] = homework;
                HW[date] = day;
            }
        }
        public string[] Get(DateTime date)
        {
            if (HW.ContainsKey(date))
            {
                return HW[date];
            }
            else
            {
                return new string[8];
            }
        }
        public void Save(string path)
        {
            string texted = JsonSerializer.Serialize(HW, new JsonSerializerOptions() { WriteIndented = true});
            File.WriteAllText(path, texted);
        }
    }
}
