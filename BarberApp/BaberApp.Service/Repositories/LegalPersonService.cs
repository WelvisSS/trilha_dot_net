using BarberApp.Domain.Entities;
using BarberApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberApp.xService
{
    public class LegalPersonService
    {
        private readonly BarberAppContext _context;

        public LegalPersonService(BarberAppContext context)
        {
            _context = context;
        }

        // Create
        public async Task<LegalPerson> CreateLegalPersonAsync(LegalPerson legalPerson)
        {
            _context.LegalPersons.Add(legalPerson);
            await _context.SaveChangesAsync();
            return legalPerson;
        }

        // Read
        public async Task<List<LegalPerson>> GetAllLegalPersonsAsync()
        {
            return await _context.LegalPersons.ToListAsync();
        }

        public async Task<LegalPerson> GetLegalPersonByIdAsync(int legalPersonId)
        {
            return await _context.LegalPersons.FindAsync(legalPersonId);
        }

        // Update
        public async Task<LegalPerson> UpdateLegalPersonAsync(LegalPerson legalPerson)
        {
            _context.Entry(legalPerson).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return legalPerson;
        }

        // Delete
        public async Task<bool> DeleteLegalPersonAsync(int legalPersonId)
        {
            var legalPerson = await _context.LegalPersons.FindAsync(legalPersonId);
            if (legalPerson == null)
                return false;

            _context.LegalPersons.Remove(legalPerson);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
