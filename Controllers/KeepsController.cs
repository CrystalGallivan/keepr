using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;
using System;
using keepr.Repositories;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _repo;
    public KeepsController(KeepRepository repo)
    {
      _repo = repo;
    }
    //GET ALL api/keeps
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
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
    //GET BY ID api/keeps/1
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
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
    //GET BY OTHER MEANS api/keeps/something
    //TODO Id has been placed in the params temporarily so the server can spin up
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(Keep value)
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
    //CREATE api/keeps
    [HttpPost]
    public ActionResult<Keep> Post(Keep value)
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
    //UPDATE api/keeps/1
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep value)
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
    //DELETE api/keeps/1
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