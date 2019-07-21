using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;
using System;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace keepr.Controllers
{
  [Route("api[controller]")]
  [ApiController]
  public class VaultkeepsController : ControllerBase
  {
    private readonly VaultkeepRepository _repo;
    public VaultkeepsController(VaultkeepRepository repo)
    {
      _repo = repo;
    }
    //GET ALL api/vaultkeeps
    [HttpGet]
    public ActionResult<IEnumerable<Vaultkeep>> Get()
    {
      try
      {
        return Ok(_repo.GetAll());
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }
    //GET BY ID api/vaultkeeps/1
    [HttpGet("{id}")]
    public ActionResult<Vaultkeep> Get(int id)
    {
      try
      {
        return Ok(_repo.GetById(id));
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }
    // //GET BY OTHER MEANS api/vaultkeeps/something
    // [HttpGet("{}")]
    // public ActionResult<Vaultkeep> Get(Vaultkeep value)
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
    //CREATE api/vaultkeeps
    [Authorize]
    [HttpPost]
    public ActionResult<Vaultkeep> Post(Vaultkeep value)
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
    //UPDATE api/vaultkeeps/1
    [HttpPut("{id}")]
    public ActionResult<Vaultkeep> Put(int id, [FromBody] Vaultkeep value)
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
    //DELETE api/vaultkeeps/1
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_repo.Delete(id));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}