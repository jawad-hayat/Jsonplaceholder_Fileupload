
using Business.Interfaces;
using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Models.Requests.Album;
using Models.Requests.Comments;
using Models.Response;

namespace Business.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IDapperRepository<Album> _albumRepository;

        public AlbumService(IHttpContextAccessor httpContextAccessor,IDapperRepository<Album> dapperRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _albumRepository = dapperRepository;
        }

        public async Task<ApiResponse> CreateAlbum(AlbumRequest request)
        {
            var newAlbum = new Album()
            {
                UserId = request.UserId,
                Title = request.Title
            };
            var isCreated = _albumRepository.Insert(newAlbum);
            if (isCreated)
            {
                return new ApiResponse
                {
                    Success = true,
                    Message = "Album Created Successfully!"
                };
            }
            return new ApiResponse
            {
                Success = false,
                Message = "unable to create Album!"
            };
        }

        public bool DeleteAlbumById(int id)
        {
            return _albumRepository.Delete(id);
        }

        public Album GetAlbumById(int id)
        {
            return _albumRepository.GetById(id);
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return _albumRepository.GetAll();
        }

        public string GetLoggedInUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirst("Id").Value;
        }

        public async Task<ApiResponse> UpdateAlbum(AlbumRequest request, int id)
        {
            var album = _albumRepository.GetById(id);
            if (album == null)
            {
                return new ApiResponse
                {
                    Success = false,
                    Message = "provided album id doesnot exist!"
                };
            }

            album.Title = request.Title;
            album.UserId = request.UserId;

            var isUpdated = _albumRepository.Update(album);
            if (isUpdated)
            {
                return new ApiResponse
                {
                    Success = true,
                    Message = "Album Updated Successfully!"
                };
            }
            return new ApiResponse
            {
                Success = false,
                Message = "unable to Update Album!"
            };
        }
    }
}
