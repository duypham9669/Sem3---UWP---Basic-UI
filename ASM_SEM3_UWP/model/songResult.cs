using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_SEM3_UWP.model
{
    class songResult
    {
        public long id { get; set; }
        public String name { get; set; }
        public String description { get; set; }
        public String singer { get; set; }
        public String author { get; set; }
        public String thumbnail { get; set; }
        public String message { get; set; }
        public String link { get; set; }
        public long memberId { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int status { get; set; }
    }
}
