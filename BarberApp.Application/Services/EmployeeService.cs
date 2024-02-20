using BarberApp.Application.Services.Interfaces;
using BarberApp.Application.InputModels;
using BarberApp.Application.ViewModels;
using BarberApp.Domain.Entities;
using static BarberApp.Domain.Exceptions.EmployeeException;
using BarberApp.Infrastructure.Persistence.Context;
using System.Data.Common;

namespace BarberApp.Application.Services;

public class EmployeeService : IEmployeeService
{
    public readonly BarberAppDbContext _context;

    public EmployeeService(BarberAppDbContext context)
    {
        _context = context;
    }
    public Employee GetByDbId(int id)
    {
        var _employee = _context.Employees.Find(id);
        if (_employee == null) throw new EmployeeNotFoundException();
        return _employee;
    }
    public int Create(NewEmployeeInputModel employee)
    {
        int id = 1;
        var _employee = new Employee
        {
            PersonId = employee.PersonId,
            EmployeeId = id++,
            Name = employee.Name,
            PhoneNumber = employee.PhoneNumber
        };

        _context.Employees.Add(_employee);
        _context.SaveChanges();
        return _employee.EmployeeId;
    }

    public void Delete(int id)
    {
        _context.Employees.Remove(GetByDbId(id));
        _context.SaveChanges();
    }

    public List<EmployeeViewModel> GetAll()
    {
        var _employees = _context.Employees.Select(m => new EmployeeViewModel
        {
            EmployeeId = m.EmployeeId,
            Name = m.Name,
            PhoneNumber = m.PhoneNumber
        }).ToList();

        return _employees;
    }

    public EmployeeViewModel? GetById(int id)
    {
        var _employee = GetByDbId(id);

        var EmployeeViewModel = new EmployeeViewModel
        {
            EmployeeId = _employee.EmployeeId,
            Name = _employee.Name,
            PhoneNumber = _employee.PhoneNumber,
        };
        return EmployeeViewModel;
    }

// Implementar após criação do service;
    // public List<ServiceViewModel> GetByEmployeeId(int id)
    // {
    //     var _employees = _context.Employees.Where(m => m.ClientId == id).Select(m => new EmployeeViewModel
    //     {
    //         EmployeeId = m.EmployeeId,
    //         ClientId = m.ClientId,
    //         Date = m.Date,
    //         RequiredAmount = m.RequiredAmount
    //     }).ToList();

    //     return _employees;
    // }

    public void Update(int id, NewEmployeeInputModel employee)
    {
        var _employee = GetByDbId(id);

        _employee.Name = employee.Name;
        _employee.PhoneNumber = employee.PhoneNumber;

        _context.Employees.Update(_employee);

        _context.SaveChanges();
    }
}
