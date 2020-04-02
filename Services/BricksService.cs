using System;
using System.Collections.Generic;
using legodemo.Models;
using legodemo.Repositories;

namespace legodemo.Services
{
  public class BricksService
  {
    private readonly BricksRepository _repo;
    public BricksService(BricksRepository repo)
    {
      _repo = repo;
    }

    public Brick Get(int id)
    {
      Brick exists = _repo.Get(id);
      if (exists == null) { throw new Exception("Invalid Id Homie"); }
      return exists;
    }

    public IEnumerable<Brick> Get()
    {
      return _repo.Get();
    }

    public Brick Create(Brick newBrick)
    {
      int id = _repo.Create(newBrick);
      newBrick.Id = id;
      return newBrick;
    }

    public object Delete(int id)
    {
      _repo.Delete(id);
      return "Successfully Deleted";
    }
  }
}