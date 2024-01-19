using BarberApp.Domain.Entities;
using BarberApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberApp.Service
{
    public class ServiceService
    {
        private readonly BarberAppContext _context;

        public ServiceService(BarberAppContext context)
        {
            _context = context;
        }

        // Create
        public async Task<Service> CreateServiceAsync(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            return service;
        }

        // Read
        public async Task<List<Service>> GetAllServicesAsync()
        {
            return await _context.Services.Include(s => s.Request).Include(s => s.Employee).ToListAsync();
        }

        public async Task<Service> GetServiceByIdAsync(int serviceId)
        {
            return await _context.Services.Include(s => s.Request).Include(s => s.Employee).FirstOrDefaultAsync(s => s.ServiceId == serviceId);
        }

        // Update
        public async Task<Service> UpdateServiceAsync(Service service)
        {
            _context.Entry(service).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return service;
        }

        // Delete
        public async Task<bool> DeleteServiceAsync(int serviceId)
        {
            var service = await _context.Services.FindAsync(serviceId);
            if (service == null)
                return false;

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
