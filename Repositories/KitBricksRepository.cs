using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using legodemo.Models;

namespace legodemo.Repositories
{
  public class KitBricksRepository
  {
    private readonly IDbConnection _db;
    public KitBricksRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<KitBrick> getBricksByKitId(int kitId)
    {
      string sql = @"
            SELECT *, b.name as brickName, k.name as kitName, kb.id as id FROM kitbricks kb
            INNER JOIN bricks b ON b.id = kb.brickId
            INNER JOIN kits k ON k.id = kb.kitId
            WHERE (kb.kitId = @kitId)";

      return _db.Query<KitPart>(sql, new { kitId });
    }

    internal int Create(KitBrick newKb)
    {
      string sql = @"
          INSERT INTO kitbricks
          (brickId, kitId, quantity)
          VALUES
          (@BrickId, @KitId, @Quantity);
          SELECT LAST_INSERT_ID();";
      return _db.ExecuteScalar<int>(sql, newKb);
    }
  }
}