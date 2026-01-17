using DAL.DataAccessPoint;
using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;   

namespace DAL
{
    public class DataFactory
    {
        DataContext db;
        public DataFactory(DataContext db)
        {
            this.db = db;
        }

        public IRepository<Product> ProductFeature(){
            return new ProductRepo(db);
        }
        public IEcommarce EcommarceFeature(){
            return new EcommarceRepo(db);
        }

    }
}
