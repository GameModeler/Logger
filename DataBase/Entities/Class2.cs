using SDK3.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK3.Entities
{
    [Table(Class2Schema.TABLE)]
    public class Class2
    {
        private Int32 id;
        private String way;
        private Int32 number;
        private Int32 clientId;
        /*private Class1 client;*/

        [Key]
        [Column(Class2Schema.ID)]
        public Int32 Id
        {
            get { return id; }
            set { id = value; }
        }

        [Column(Class2Schema.WAY)]
        public String Way
        {
            get { return way; }
            set { way = value; }
        }

        [Column(Class2Schema.NUMBER)]
        public Int32 Number
        {
            get { return number; }
            set { number = value; }
        }

        [Column(Class2Schema.CLIENT_ID)]
        public Int32 ClientId
        {
            get { return clientId; }
            set
            {
                clientId = value;
            }
        }

        /*[Column(Class2Scheme.CLIENT)]
        [ForeignKey("ClientId")]
        public Class1 Client
        {
            get { return client; }
            set { client = value; }
        }*/

        public Class2()
        {

        }
    }
}
