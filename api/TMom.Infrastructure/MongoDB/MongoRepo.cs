using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace TMom.Infrastructure.MongoDB
{
    public class MongoRepo : IMongoRepo
    {
        private IMongoClient _client;
        private IMongoDatabase _db;
        private readonly IGridFSBucket bucket;
        private readonly ILogger<MongoRepo> _logger;
        private readonly string ConnectionString = Appsettings.app(new string[] { "Mongo", "ConnectionString" });
        private readonly string Database = Appsettings.app(new string[] { "Mongo", "Database" });

        public MongoRepo(ILogger<MongoRepo> logger)
        {
            _client = new MongoClient(ConnectionString);
            _db = _client.GetDatabase(Database);
            bucket = new GridFSBucket(_db);
            _logger = logger;
        }

        public ObjectId GetInternalId(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task<GridFSFileInfo> GetFileById(string id)
        {
            var filter = Builders<GridFSFileInfo>.Filter.Eq("_id", GetInternalId(id));
            return await bucket.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<GridFSFileInfo> GetFileById(ObjectId id)
        {
            var filter = Builders<GridFSFileInfo>.Filter.Eq("_id", id);
            return await bucket.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<ObjectId> UploadFile(string fileName, Stream source)
        {
            var id = await bucket.UploadFromStreamAsync(fileName, source);
            return id;
        }

        public async Task<GridFSDownloadStream<ObjectId>> DownloadFileStreamSeekable(string id)
        {
            var options = new GridFSDownloadOptions
            {
                Seekable = true
            };
            return await bucket.OpenDownloadStreamAsync(GetInternalId(id), options);
        }

        public async Task<GridFSDownloadStream<ObjectId>> DownloadFileStreamSeekable(ObjectId id)
        {
            var options = new GridFSDownloadOptions
            {
                Seekable = true
            };
            return await bucket.OpenDownloadStreamAsync(id, options);
        }

        public async Task<GridFSDownloadStream<ObjectId>> DownloadFileStream(string id)
        {
            return await bucket.OpenDownloadStreamAsync(GetInternalId(id));
        }

        public async Task<GridFSDownloadStream<ObjectId>> DownloadFileStream(ObjectId id)
        {
            return await bucket.OpenDownloadStreamAsync(id);
        }

        public async Task DeleteFile(string id)
        {
            await bucket.DeleteAsync(GetInternalId(id));
        }

        public async Task DeleteFile(ObjectId id)
        {
            await bucket.DeleteAsync(id);
        }

        public async Task RenameFile(string id, string newFilename)
        {
            await bucket.RenameAsync(GetInternalId(id), newFilename);
        }

        public async Task RenameFile(ObjectId id, string newFilename)
        {
            await bucket.RenameAsync(id, newFilename);
        }
    }
}