using System;
using System.Collections.Generic;
using legodemo.Models;
using legodemo.Repositories;

namespace legodemo.Services
{
  public class KitBricksService
  {
    private readonly KitBricksRepository _repo;
    private readonly KitsRepository _krepo;
    public KitBricksService(KitBricksRepository repo, KitsRepository krepo)
    {
      _repo = repo;
      _krepo = krepo;
    }

    public IEnumerable<KitBrick> GetBricks(int kitId)
    {
      Kit exists = _krepo.Get(kitId);
      if (exists == null) { throw new Exception("Invalid Id"); }
      return _repo.getBricksByKitId(kitId);
    }

    public KitBrick Create(KitBrick newKb)
    {
      int id = _repo.Create(newKb);
      newKb.Id = id;
      return newKb;

    }
  }
}