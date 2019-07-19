using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

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
        string query = "SELECT * FROM keeps WHERE id = @Id";
        Keep data = _db.QueryFirstOrDefault<Keep>(query, new { id });
        if (data is null) throw new Exception("Invalid Id");
        return data;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Keep GetBy(Keep value)
    {
      //TODO This mehtod may not be necessary
      try
      {
        string query = @"";
        return _db.QueryFirstOrDefault<Keep>(query, value);
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
        string query = @"INSERT INTO keeps (name, description, userId, img, isPrivate, views, shares, keeps)
                VALUES (@Name, @Description, @UserId, @Img, @IsPrivate, @Views, @Shares, @Keeps);
                SELECT LAST_INSERT_ID;
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
        userId = @UserId,
        img = @Img,
        isPrivate = @IsPrivate,
        views = @Views,
        shares = @Shares,
        keeps = @Keeps
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