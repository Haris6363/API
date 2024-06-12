using AspNetCore.Identity.LiteDB.Data;
using Assignment.Models;
using LiteDB;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Assignment
{
    public class LiteAlertModel: ILiteDbAlertModelService

    {

        public LiteDatabase _LiteDb;


        public LiteAlertModel(ILiteDbContext dbContext)
        {
            _LiteDb = dbContext.LiteDatabase;

        }

        public IEnumerable<Alert_Model> FindAll()
        {

            return _LiteDb.GetCollection<Alert_Model>("Alert").FindAll();

        }

        public Alert_Model GetOne(int id)
        {

            return _LiteDb.GetCollection<Alert_Model>("Alert").Find(x => x.Id == id).FirstOrDefault();

        }

        public int Insert(Alert_Model model)
        {
            return _LiteDb.GetCollection<Alert_Model>("Alert").Insert(model);
        }

        public bool Update(Alert_Model model)
        {
            return _LiteDb.GetCollection<Alert_Model>("Alert").Update(model);
        }

        public bool Delete(int id)
        {
          return _LiteDb.GetCollection<Alert_Model>("Alert").Delete(new BsonValue(id));


           
            
           

        }


    }

    public interface ILiteDbAlertModelService
    {
        Alert_Model GetOne(int id);
        int Insert(Alert_Model model);
        bool Update(Alert_Model model);
        bool Delete(int id); 
        IEnumerable<Alert_Model> FindAll();
    }
}
