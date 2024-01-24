using BarberApp.Domain.Entities;
using BarberApp.Domain.Interfaces;

namespace BaberApp.Persistence.Data;

public class EmployeesDB : IEmployeeCollection
{
    private readonly List<Employee> _employees = new List<Employee>();
    private int _id = 0;
    public void Create(Employee employee)
    {
        if (_employees.Count > 0)
            _id = _employees.Max(m => m.EmployeeId);
        employee.EmployeeId = ++_id;
        _employees.Add(employee);
    }
    public void Delete(int id)
    {
        _employees.RemoveAll(m => m.EmployeeId == id);
    }
    public ICollection<Employee> GetAll()
    {
        return _employees.ToArray();
    }
    public Employee? GetById(int id)
    {
        return _employees.FirstOrDefault(m => m.EmployeeId == id);
    }
    public void Update(int id, Employee employee)
    {
        var employeeDB = _employees.FirstOrDefault(m => m.EmployeeId == id);
        if (employeeDB is not null)
        {
            employeeDB.Name = employee.Name;
            employeeDB.PhoneNumber = employee.PhoneNumber;
        }
    }
}

