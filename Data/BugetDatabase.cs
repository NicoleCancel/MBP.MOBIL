using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBP.MOBIL.Models;

namespace MBP.MOBIL.Data
{
    public class BugetDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public BugetDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Buget>().Wait();
            _database.CreateTableAsync<Factura>().Wait();
            _database.CreateTableAsync<ListaFacturi>().Wait();
        }
        public Task<List<Buget>> GetBugetsAsync()
        {
            return _database.Table<Buget>().ToListAsync();
        }
        public Task<Buget> GetBugetAsync(int id)
        {
            return _database.Table<Buget>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveBugetAsync(Buget slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteBugetAsync(Buget slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveFacturaAsync(Factura factura)
        {
            if (factura.ID != 0)
            {
                return _database.UpdateAsync(factura);
            }
            else
            {
                return _database.InsertAsync(factura);
            }
        }
        public Task<int> DeleteFacturaAsync(Factura product)
        {
            return _database.DeleteAsync(product);
        }
        public Task<List<Factura>> GetFacturasAsync()
        {
            return _database.Table<Factura>().ToListAsync();
        }
        public Task<int> SaveListaFacturiAsync(ListaFacturi listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Factura>> GetListaFacturisAsync(int bugetid)
        {
            return _database.QueryAsync<Factura>(
            "select P.ID, P.Description from Factura P"
            + " inner join ListaFacturi LP"
            + " on P.ID = LP.FacturaID where LP.BugetID = ?",
            bugetid);
        }
        
    }

}


