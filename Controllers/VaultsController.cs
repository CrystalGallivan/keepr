using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;
using System;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _repo;
    public VaultsController(VaultRepository repo)
    {
      _repo = repo;
    }
    //GET ALL api/vaults
    [Authorize]
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      try
      {
        string userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.GetById(userId));
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }
    //GET BY ID api/vaults/1
    // [Authorize]
    // [HttpGet("{id}")]
    // public ActionResult<Vault> Get(int id)
    // {
    //   try
    //   {
    //     return Ok(_repo.GetById(id));
    //   }
    //   catch (Exception e)
    //   {

    //     return BadRequest(e);
    //   }
    // }
    //GET BY OTHER MEANS api/vaults/something
    //TODO Id has been placed in the params temporarily so the server can spin up
    // [Authorize]
    // [HttpGet("{id}")]
    // public ActionResult<Vault> Get(Vault value)
    // {
    //   try
    //   {
    //     // value.something = something;
    //     return Ok(_repo.GetBy(value));
    //   }
    //   catch (Exception e)
    //   {

    //     return BadRequest(e);
    //   }
    // }
    //CREATE api/vaults
    [Authorize]
    [HttpPost]
    public ActionResult<Vault> Post([FromBody] Vault value)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        value.UserId = userId;
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }
    //UPDATE api/vaults/1
    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<Vault> Put(int id, [FromBody] Vault value)
    {
      try
      {
        value.Id = id;
        return Ok(_repo.Update(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
    //DELETE api/vaults/1
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        return Ok(_repo.Delete(id, userId));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}