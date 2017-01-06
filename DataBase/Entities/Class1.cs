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
    [Table(Class1Schema.TABLE)]
    public class Class1 : EntityBase
    { 
        private Int32 id;
        private String name;
        private String surname;
        private Int32 addressId;
        private Class2 address;
        private List<Class2> addresses;

        [Key]
        [Column(Class1Schema.ID)]
        public Int32 Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        [Column(Class1Schema.NAME)]
        public String Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        [Column(Class1Schema.SURNAME)]
        public String Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

        [Column(Class1Schema.ADDRESS_ID)]
        public Int32 AddressId
        {
            get { return addressId; }
            set { addressId = value; }
        }

        [ForeignKey(Class1Schema.ADDRESS_ID)]
        public Class2 Address
        {
            get { return address; }
            set { address = value; }
        }

        public List<Class2> Addresses
        {
            get { return addresses; }
            set { addresses = value; }
        }

        public Class1()
        {
            Addresses = new List<Class2>();
        }
    }
}
