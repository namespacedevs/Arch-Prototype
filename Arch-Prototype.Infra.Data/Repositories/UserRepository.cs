using System.Collections.Generic;
using System.Linq;
using Arch_Prototype.Domain.Auth;
using Arch_Prototype.Infra.Data.Contexts;

namespace Arch_Prototype.Infra.Data.Repositories
{
    public class UserRepository : IBaseRepository<User>
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User Get(long id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        public void Update(User dbEntity, User entity)
        {
            dbEntity = Assign(entity, dbEntity);
            _context.Update(dbEntity);
            _context.SaveChanges();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
            _context.SaveChanges();
        }

        public User Assign<TSource>(TSource source, User destination)
        {
            var entry = _context.Entry(destination);
            entry.CurrentValues.SetValues(source);
            return destination;
        }
    }
}