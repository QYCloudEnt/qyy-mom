using MongoDB.Bson;
using MongoDB.Driver.GridFS;

namespace TMom.Infrastructure.MongoDB
{
    public interface IMongoRepo
    {
        ObjectId GetInternalId(string id);

        Task<GridFSFileInfo> GetFileById(string id);

        Task<GridFSFileInfo> GetFileById(ObjectId id);

        Task<ObjectId> UploadFile(string fileName, Stream source);

        Task<GridFSDownloadStream<ObjectId>> DownloadFileStreamSeekable(string id);

        Task<GridFSDownloadStream<ObjectId>> DownloadFileStreamSeekable(ObjectId id);

        Task<GridFSDownloadStream<ObjectId>> DownloadFileStream(string id);

        Task<GridFSDownloadStream<ObjectId>> DownloadFileStream(ObjectId id);

        Task DeleteFile(string id);

        Task DeleteFile(ObjectId id);

        Task RenameFile(string id, string newFilename);

        Task RenameFile(ObjectId id, string newFilename);
    }
}