using MongoDB.Bson;
using MongoDB.Driver;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public class NoteRepository : INoteRepository
    {
        private static IMongoConnection _mongoConnection;
        private static IMongoCollection<Note> _noteCollection;
        public NoteRepository(IMongoConnection mongoConnection)
        {
            _mongoConnection = mongoConnection;
            _noteCollection = _mongoConnection.GetMongoDatabase().GetCollection<Note>("Notes");
        }
        public Note Add(Note entity)
        {
            entity.CreatedOn = DateTime.Now;
            entity.UpdatedOn = DateTime.Now;
            _noteCollection.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            _noteCollection.DeleteOne(x => x.Id == id);
        }

        public IList<Note> GetAll()
        {
            return _noteCollection.Find(new BsonDocument()).ToList();
        }

        public Note GetById(string id)
        {
            return _noteCollection.AsQueryable<Note>().Where<Note>(x => x.Id == id).FirstOrDefault();
        }

        public Note Update(Note entity)
        {
            var update = Builders<Note>.Update
               .Set(x => x.Id, entity.Id)
               .Set(x => x.CreatedOn, entity.CreatedOn)
               .Set(x => x.UpdatedOn, DateTime.Now)
               .Set(x => x.Author, "")
               .Set(x => x.Text, entity.Text);

            var updateOption = new UpdateOptions { IsUpsert = true };
            var result = _noteCollection.UpdateOne(Builders<Note>.Filter.Eq(x => x.Id, entity.Id), update, updateOption);
            return GetById(entity.Id);

        }
    }
}
