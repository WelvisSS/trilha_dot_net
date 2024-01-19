using BarberApp.Domain.Entities;
using BarberApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberApp.Service
{
    public class PersonService
    {
        private readonly BarberAppContext _context;

        public PersonService(BarberAppContext context)
        {
            _context = context;
        }

        // Create
        public async Task<Person> CreatePersonAsync(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();
            return person;
        }

        // Read
        public async Task<List<Person>> GetAllPersonsAsync()
        {
            return await _context.Person.ToListAsync();
        }

        public async Task<Person> GetPersonByIdAsync(int personId)
        {
            return await _context.Person.FindAsync(personId);
        }

        // Update
        public async Task<Person> UpdatePersonAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return person;
        }

        // Delete
        public async Task<bool> DeletePersonAsync(int personId)
        {
            var person = await _context.Person.FindAsync(personId);
            if (person == null)
                return false;

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
