// using System.Collections.Generic;
// using Microsoft.AspNetCore.Mvc;
// using keepr.Models;
// using System;

// namespace keepr.Controllers
// {
//   [Route("api[controller]")]
//   [ApiController]
//   public class BasesController : ControllerBase
//   {
//     private readonly BaseRepository _repo;
//     public BasesController(BaseRepository repo)
//     {
//       _repo = repo;
//     }
//     //GET ALL api/bases
//     [HttpGet]
//     public ActionResult<IEnumerable<Base>> Get()
//     {
//       try
//       {
//         return Ok(_repo.GetAll());
//       }
//       catch (Exception e)
//       {

//         return BadRequest(e);
//       }
//     }
//     //GET BY ID api/bases/1
//     [HttpGet("{id}")]
//     public ActionResult<Base> Get(int id)
//     {
//       try
//       {
//         return Ok(_repo.GetById(id));
//       }
//       catch (Exception e)
//       {

//         return BadRequest(e);
//       }
//     }
//     //GET BY OTHER MEANS api/bases/something
//     [HttpGet("{}")]
//     public ActionResult<Base> Get(Base value)
//     {
//       try
//       {
//         // value.something = something;
//         return Ok(_repo.GetBy(value));
//       }
//       catch (Exception e)
//       {

//         return BadRequest(e);
//       }
//     }
//     //CREATE api/bases
//     [HttpPost]
//     public ActionResult<Base> Post(Base value)
//     {
//       try
//       {
//         return Ok(_repo.Create(value));
//       }
//       catch (Exception e)
//       {

//         return BadRequest(e);
//       }
//     }
//     //UPDATE api/bases/1
//     [HttpPut("{id}")]
//     public ActionResult<Base> Put(int id, [FromBody] Base value)
//     {
//       try
//       {
//         value.Id = id;
//         return Ok(_repo.Update(value));
//       }
//       catch (Exception e)
//       {
//         return BadRequest(e);
//       }
//     }
//     //DELETE api/bases/1
//     [HttpDelete("{id}")]
//     public ActionResult<string> Delete(int id)
//     {
//       try
//       {
//         return Ok(_repo.Delete(id));
//       }
//       catch (Exception e)
//       {
//         return BadRequest(e);
//       }
//     }
//   }
// }