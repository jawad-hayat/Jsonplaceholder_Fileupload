
using Business.Interfaces;
using Business.Services;
using Data.Repositories;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IRepository<Todo>, Repository<Todo>>();
            services.AddScoped<IDapperRepository<Album>, DapperRepository<Album>>();
        }
    }
}
