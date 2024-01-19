using BarberApp.Domain.Entities;
using BarberApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberApp.Service
{
    public class RequestService
    {

        
        private readonly BarberAppContext _context;

        public RequestService(BarberAppContext context)
        {
            _context = context;
        }

        // Create
        public async Task<Request> CreateRequestAsync(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        // Read
        public async Task<List<Request>> GetAllRequestsAsync()
        {
            return await _context.Requests.Include(r => r.Client).ToListAsync();
        }

        public async Task<Request> GetRequestByIdAsync(int requestId)
        {
            return await _context.Requests.Include(r => r.Client).FirstOrDefaultAsync(r => r.RequestId == requestId);
        }

        // Update
        public async Task<Request> UpdateRequestAsync(Request request)
        {
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return request;
        }

        // Delete
        public async Task<bool> DeleteRequestAsync(int requestId)
        {
            var request = await _context.Requests.FindAsync(requestId);
            if (request == null)
                return false;

            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
