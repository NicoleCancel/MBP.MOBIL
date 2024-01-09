using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace MBP.MOBIL.Models
{
    public class ListaFacturi
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(Buget))]
        public int BugetID { get; set; }
        public int FacturaID { get; set; }
    }
}
