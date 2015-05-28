using Microsoft.Framework.OptionsModel;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace General.Model
{
    public class PresentationRepository : IPresentationRepository
    {
        private readonly Settings _settings;
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Presentations> _collection;

        public PresentationRepository(IOptions<Settings> settings)
        {
            _settings = settings.Options;
            _client = new MongoClient(_settings.MongoConnection);
            _database = _client.GetDatabase(_settings.Database);
            _collection = _database.GetCollection<Presentations>("presentations");
        }

        public async void Add(Presentations presentations)
        {
            await _collection.InsertOneAsync(presentations);
        }

        public async Task<List<Presentations>> AllPresentations()
        {
            var presentationList = await _collection.Find(new BsonDocument()).ToListAsync();
            return presentationList;
        }

        public async Task<Presentations> Get(ObjectId id)
        {
            var presentation = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return presentation;
        }

        public async Task<bool> Remove(ObjectId id)
        {
            var filter = Builders<Presentations>.Filter.Where(x => x.Id == id);
            var result = await _collection.DeleteOneAsync(filter);
            return result.DeletedCount == 1;
        }

        public async void Update(Presentations presentations)
        {
            var filter = Builders<Presentations>.Filter.Where(x => x.Id == presentations.Id);
            await _collection.ReplaceOneAsync(filter, presentations);
        }
 
    }
}