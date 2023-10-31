
using Domain.Models;
using Models.Requests.Album;
using Models.Requests.Post;
using Models.Response;

namespace Business.Interfaces
{
    public interface IAlbumService
    {
        public string GetLoggedInUserId();

        public Task<ApiResponse> CreateAlbum(AlbumRequest request);
        public Task<ApiResponse> UpdateAlbum(AlbumRequest request, int id);
        public IEnumerable<Album> GetAllAlbums();
        public Album GetAlbumById(int id);
        public bool DeleteAlbumById(int id);
    }
}
