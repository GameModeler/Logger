﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMLogger.DataBase.Entities
{
    public class Car
    {
        public int CarId { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public string Manufacturer { get; set; }
    }
}