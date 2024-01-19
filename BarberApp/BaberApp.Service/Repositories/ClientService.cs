using BarberApp.Domain.Entities;
using BarberApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarberApp.Service
{
    public class ClientService
    {
        private readonly BarberAppContext _context;

        public ClientService(BarberAppContext context)
        {
            _context = context;
        }

        // Create
        public async Task<Client> CreateClientAsync(Client client)
        {
            _context.Client.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        // Read
        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _context.Client.ToListAsync();
        }

        public async Task<Client> GetClientByIdAsync(int clientId)
        {
            return await _context.Client.FindAsync(clientId);
        }

        // Update
        public async Task<Client> UpdateClientAsync(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return client;
        }

        // Delete
        public async Task<bool> DeleteClientAsync(int clientId)
        {
            var client = await _context.Client.FindAsync(clientId);
            if (client == null)
                return false;

            _context.Client.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
