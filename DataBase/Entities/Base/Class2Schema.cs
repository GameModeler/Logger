using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK3.Entities.Base
{
    public class Class2Schema : ISchema
    {
        public const String TABLE = "address";
        public const String ID = "Id";
        public const String WAY = "Way";
        public const String NUMBER = "Number";
        public const String CLIENT_ID = "ClientId";
        public const String CLASS1_ID = "Class1_Id";

        public const String PREFIX_ID = TABLE + "." + ID;
        public const String PREFIX_WAY = TABLE + "." + WAY;
        public const String PREFIX_NUMBERE = TABLE + "." + NUMBER;
        public const String PREFIX_CLIENT_ID = TABLE + "." + CLIENT_ID;
        public const String PREFIX_CLASS1_ID = TABLE + "." + CLASS1_ID;

        public const String ALL_TABLE_ELEMENT = TABLE + ".*";

        public List<String> GetColumns()
        {
            List<String> result = new List<String>();
            result.Add(ID);
            result.Add(WAY);
            result.Add(NUMBER);
            result.Add(CLIENT_ID);
            result.Add(CLASS1_ID);
            return result;
        }
    }
}
