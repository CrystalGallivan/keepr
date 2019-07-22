using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using Microsoft.AspNetCore.Http;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    private readonly IDbConnection _db;
    public KeepRepository(IDbConnection db) => _db = db;
    public IEnumerable<Keep> GetAll()
    {
      try
      {
        return _db.Query<Keep>("SELECT * FROM keeps");
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Keep GetById(int id)
    {
      try
      {
        string query = "SELECT * FROM keeps WHERE id = @id";
        Keep data = _db.QueryFirstOrDefault<Keep>(query, new { id });
        if (data is null) throw new Exception("Invalid Id");
        return data;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public IEnumerable<Keep> GetKeepsByUser(string id)
    {
      //TODO This mehtod may not be necessary
      try
      {
        string query = @"SELECT * FROM keeps WHERE userId = @id";
        return _db.Query<Keep>(query, new { id });

      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Keep Create(Keep value)
    {
      try
      {
        string query = @"INSERT INTO keeps (name, description, userId, img, isPrivate)
                VALUES (@Name, @Description, @UserId, @Img, @IsPrivate);
                SELECT LAST_INSERT_ID();
                ";
        int id = _db.ExecuteScalar<int>(query, value);
        value.Id = id;
        return value;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Keep Update(Keep value)
    {
      try
      {
        string query = @"
        UPDATE keeps
        SET
        name = @Name,
        description = @Description,
        img = @Img,
        isPrivate = @IsPrivate
        WHERE id = @Id;
        SELECT * FROM keeps WHERE id = @Id;
        ";
        return _db.QueryFirstOrDefault<Keep>(query, value);
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    internal object GetUserById(object id)
    {
      throw new NotImplementedException();
    }

    public string Delete(int id)
    {
      try
      {
        string query = "DELETE FROM keeps WHERE id = @id;";
        int changedRows = _db.Execute(query, new { id });
        if (changedRows < 1) throw new Exception("Invalid Id");
        return "Successfully Deleted";
      }
      catch (Exception e)
      {
        throw e;
      }
    }
  }
}