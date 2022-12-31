using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTITSTimetableApp
{
    internal class Lesson
    {
        public string LessonName { get; set; }
        public string ClassNo { get; set; }
        public override string ToString()
        {
            return $"{ClassNo} {LessonName}";
        }
    }
}
