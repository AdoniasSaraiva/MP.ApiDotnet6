using Microsoft.EntityFrameworkCore;
using MP.ApiDotnet6.Infra.Data.Context;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.FiltersDb;
using MP.ApiDotNet6.Domain.Repositories;

namespace MP.ApiDotnet6.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationContextDb _db;
        public PersonRepository(ApplicationContextDb db)
        {
            _db = db;
        }
        public async Task<Person> CreateAsync(Person person)
        {
            _db.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _db.Remove(person);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Person person)
        {
            _db.Update(person);
            await _db.SaveChangesAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetIdByDocumentAsync(string document)
        {
            return (await _db.People.FirstOrDefaultAsync(x => x.Document == document))?.Id ?? 0;
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _db.People.ToListAsync();
        }

        public async Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb personFilterDb)
        {
            var people = _db.People.AsQueryable();
            if (!string.IsNullOrEmpty(personFilterDb.Name))
                people = people.Where(x => x.Name.Contains(personFilterDb.Name));

            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<Person>,Person>(people, personFilterDb);
        }
    }
}