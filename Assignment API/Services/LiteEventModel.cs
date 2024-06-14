using AspNetCore.Identity.LiteDB.Data;
using Assignment.Models;
using LiteDB;

namespace Assignment.Services
{
    public class LiteEventModel : ILiteEventModelService
    {
        public LiteDatabase _db;
        private string Event_Model = "Event_Model";
        public LiteEventModel(ILiteDbContext Idb)
        {
            _db = Idb.LiteDatabase;
        }

        public bool delete(int id)
        {
            return _db.GetCollection<Event_Model>(Event_Model).Delete(new BsonValue(id));
        }

        public IEnumerable<Event_Model> FindAll()
        {
            return _db.GetCollection<Event_Model>(Event_Model).FindAll();
        }

        public Event_Model GetOne(int id)
        {
            return _db.GetCollection<Event_Model>(Event_Model).Find(s => s.id == id).FirstOrDefault();
        }

        public int insert(Event_Model model)
        {
            return _db.GetCollection<Event_Model>(Event_Model).Insert(model);
        }

        public bool update(Event_Model model)
        {
            return _db.GetCollection<Event_Model>(Event_Model).Update(model);
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
