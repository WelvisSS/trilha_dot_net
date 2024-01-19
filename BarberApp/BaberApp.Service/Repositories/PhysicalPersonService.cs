using BarberApp.Domain.Entities;
using BarberApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberApp.Service
{
    public class PhysicalPersonService
    {
        private readonly BarberAppContext _context;

        public PhysicalPersonService(BarberAppContext context)
        {
            _context = context;
        }

        // Create
        public async Task<PhysicalPerson> CreatePhysicalPersonAsync(PhysicalPerson physicalPerson)
        {
            _context.PhysicalPersons.Add(physicalPerson);
            await _context.SaveChangesAsync();
            return physicalPerson;
        }

        // Read
        public async Task<List<PhysicalPerson>> GetAllPhysicalPersonsAsync()
        {
            return await _context.PhysicalPersons.ToListAsync();
        }

        public async Task<PhysicalPerson> GetPhysicalPersonByIdAsync(int physicalPersonId)
        {
            return await _context.PhysicalPersons.FindAsync(physicalPersonId);
        }

        // Update
        public async Task<PhysicalPerson> UpdatePhysicalPersonAsync(PhysicalPerson physicalPerson)
        {
            _context.Entry(physicalPerson).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return physicalPerson;
        }

        // Delete
        public async Task<bool> DeletePhysicalPersonAsync(int physicalPersonId)
        {
            var physicalPerson = await _context.PhysicalPersons.FindAsync(physicalPersonId);
            if (physicalPerson == null)
                return false;

            _context.PhysicalPersons.Remove(physicalPerson);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
