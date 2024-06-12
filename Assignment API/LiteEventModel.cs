using AspNetCore.Identity.LiteDB.Data;
using Assignment.Models;
using LiteDB;

namespace Assignment
{
    public class LiteEventModel:ILiteEventModelService
    {
        public LiteDatabase _db;
        public LiteEventModel(ILiteDbContext Idb) 
        {
            _db=Idb.LiteDatabase;
        }

       public bool delete(int id)
        {
          return _db.GetCollection<Event_Model>("Event").Delete(new BsonValue(id));
        } 

       public IEnumerable<Event_Model> FindAll()
        {
            return _db.GetCollection<Event_Model>("Event").FindAll();
        }

        public Event_Model GetOne(int id)
        {
            return _db.GetCollection<Event_Model>("Event").Find(s => s.id == id).FirstOrDefault();   
        }

        public int insert(Event_Model model)
        {
            return _db.GetCollection<Event_Model>("Event").Insert(model);
        }

       public  bool update(Event_Model model)
        {
           return _db.GetCollection<Event_Model>("Event").Update(model);
        }
    }

    public interface ILiteEventModelService
    {
        IEnumerable<Event_Model> FindAll();
        Event_Model GetOne(int id);
        int insert(Event_Model model);  
        bool update(Event_Model model);  
        bool delete(int id); 
    }
}
