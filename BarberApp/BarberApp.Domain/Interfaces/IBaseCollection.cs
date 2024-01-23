﻿namespace BarberApp.Domain.Interfaces;

public interface IBaseCollection<T>
{
    void Create(T obj);
    ICollection<T> GetAll();
    T? GetById(int id);
    void Update(int id, T obj);
    void Delete(int id);
}
