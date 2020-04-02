using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using legodemo.Models;
using legodemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace legodemo.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KitsController : ControllerBase
  {
    private readonly KitsService _ks;
    private readonly KitBricksService _kbs;
    public KitsController(KitsService ks, KitBricksService kbs)
    {
      _ks = ks;
      _kbs = kbs;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Kit>> Get()
    {
      try
      {
        return Ok(_ks.Get());
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Kit> Get(int id)
    {
      try
      {
        return Ok(_ks.Get(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // POST api/values
    [HttpPost]
    public ActionResult<Kit> Post([FromBody] Kit newKit)
    {
      try
      {
        return Ok(_ks.Create(newKit));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_ks.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    //api/kits/kitId/kitbricks
    [HttpGet("{kitId}/kitbricks")]
    public ActionResult<KitBrick> GetKitBricks(int kitId)
    {
      try
      {
        return Ok(_kbs.GetBricks(kitId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}

