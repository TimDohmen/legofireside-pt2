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
  public class KitBricksController : ControllerBase
  {
    private readonly KitBricksService _kbs;

    public KitBricksController(KitBricksService kbs)
    {
      _kbs = kbs;
    }

    // [HttpGet("{kitId}")]
    // public ActionResult<KitBrick> Get(int kitId)
    // {
    //   try
    //   {
    //     return Ok(_kbs.GetBricks(kitId));
    //   }
    //   catch (Exception e)
    //   {
    //     return BadRequest(e.Message);
    //   }
    // }


    [HttpPost]
    public ActionResult<Brick> Post([FromBody] KitBrick newKb)
    {
      try
      {
        return Ok(_kbs.Create(newKb));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}

