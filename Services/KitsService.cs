using System;
using System.Collections.Generic;
using legodemo.Models;
using legodemo.Repositories;

namespace legodemo.Services
{
  public class KitsService
  {
    private readonly KitsRepository _repo;
    public KitsService(KitsRepository repo)
    {
      _repo = repo;
    }

    public Kit Get(int id)
    {
      Kit exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id Homie"); }
      return exists;
    }

    public IEnumerable<Kit> Get()
    {
      return _repo.Get();
    }

    public Kit Create(Kit newKit)
    {
      int id = _repo.Create(newKit);
      newKit.Id = id;
      return newKit;
    }

    public object Delete(int id)
    {
      _repo.Delete(id);
      return "Successfully Booted";
    }
  }
}