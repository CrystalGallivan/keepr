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
  public class VaultkeepsController : ControllerBase
  {
    private readonly VaultkeepRepository _repo;
    public VaultkeepsController(VaultkeepRepository repo)
    {
      _repo = repo;
    }
    // GET ALL api/vaultkeeps
    [Authorize]
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
    //GET BY ID api/vaultkeeps/vaultId
    [Authorize]
    [HttpGet("{vaultId}")]
    // (DataVaultkeep)
    // public ActionResult<IEnumerable<Vaultkeep>> Get(int vaultId)
    // {
    //   try
    //   {
    //     var userId = HttpContext.User.FindFirstValue("Id");

    //     return Ok(_repo.GetById(vaultId, userId));
    //   }
    //   catch (Exception e)
    //   {

    //     return BadRequest(e);
    //   }
    // }
    public ActionResult<IEnumerable<Keep>> Get(int vaultId)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");

        return Ok(_repo.GetById(vaultId, userId));
      }
      catch (Exception e)
      {

        return BadRequest(e);
      }
    }

    [Authorize]
    [HttpPost]
    public ActionResult<Vaultkeep> Post([FromBody] Vaultkeep value)
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
    //DELETE api/vaultkeeps
    [Authorize]
    [HttpPut]
    public ActionResult<Vaultkeep> Put([FromBody] Vaultkeep value)
    {
      try
      {
        var userId = HttpContext.User.FindFirstValue("Id");
        value.UserId = userId;
        return Ok(_repo.Delete(value));
      }
      catch (Exception e)
      {
        return BadRequest(e);
      }
    }
  }
}