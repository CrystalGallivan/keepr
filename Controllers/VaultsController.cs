using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;
using System;
using keepr.Repositories;

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
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
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
    //GET BY ID api/vaults/1
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
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
    //GET BY OTHER MEANS api/vaults/something
    //TODO Id has been placed in the params temporarily so the server can spin up
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(Vault value)
    {
      try
      {
        // value.something = something;
        return Ok(_repo.GetBy(value));
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }
    //CREATE api/vaults
    [HttpPost]
    public ActionResult<Vault> Post(Vault value)
    {
      try
      {
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }
    //UPDATE api/vaults/1
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