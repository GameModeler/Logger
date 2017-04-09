using DataBase.Database.Utils;
using System.Collections.Generic;

namespace Loggers.Entities
{
    [Persistent]
    public class Cake
    {
        public int CakeId { get; set; }

        public string Name { get; set; }

        public List<string> Ingredients { get; set; }

        public int time { get; set; }
    }
}
