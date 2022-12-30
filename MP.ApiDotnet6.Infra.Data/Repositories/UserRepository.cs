using Microsoft.EntityFrameworkCore;
using MP.ApiDotnet6.Infra.Data.Context;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotnet6.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContextDb _db;

        public UserRepository(ApplicationContextDb db)
        {
            _db = db;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
