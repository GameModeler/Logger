using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK3.Entities.Base
{
    public class Class1Schema : ISchema
    {
        public const String TABLE = "client";
        public const String ID = "Id";
        public const String NAME = "Name";
        public const String SURNAME = "Surname";
        public const String ADDRESS_ID = "AddressId";

        public const String PREFIX_ID = TABLE + "." + ID;
        public const String PREFIX_NAME = TABLE + "." + NAME;
        public const String PREFIX_SURNAME = TABLE + "." + SURNAME;
        public const String PREFIX_ADDRESS_ID = TABLE + "." + ADDRESS_ID;

        public const String ALL_TABLE_ELEMENT = TABLE + ".*";

        public List<String> GetColumns()
        {
            List<String> result = new List<String>();
            result.Add(ID);
            result.Add(NAME);
            result.Add(SURNAME);
            result.Add(ADDRESS_ID);
            return result;
        }
    }
}
