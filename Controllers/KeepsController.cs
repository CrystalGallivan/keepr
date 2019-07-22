using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;
using System;
using keepr.Repositories;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;

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
    [Authorize]
    [HttpGet("user")]
    public ActionResult<IEnumerable<Keep>> Get(string user)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        // value.UserId = userId;
        if (userId == null)
        {
          throw new Exception("Login In To Get Your Keeps");
        }
        // value.something = something;
        return Ok(_repo.GetKeepsByUser(userId));
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }
    //CREATE api/keeps
    [Authorize]
    [HttpPost]
    public ActionResult<Keep> Post([FromBody] Keep value)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        value.UserId = userId;
        if (userId == null)
        {
          throw new Exception("Login In To Create A Keep");
        }
        return Ok(_repo.Create(value));
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }
    //UPDATE api/keeps/1
    [Authorize]
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
    [Authorize]
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