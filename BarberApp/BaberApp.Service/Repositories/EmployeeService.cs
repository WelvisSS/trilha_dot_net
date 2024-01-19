using BarberApp.Domain.Entities;
using BarberApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BarberApp.Service
{
    public class EmployeeService
    {
        private readonly BarberAppContext _context;

        public EmployeeService(BarberAppContext context)
        {
            _context = context;
        }

        // Create
        public async Task<Employee> CreateEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        // Read
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await _context.Employees.FindAsync(employeeId);
        }

        // Update
        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return employee;
        }

        // Delete
        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if (employee == null)
                return false;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
