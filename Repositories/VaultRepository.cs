using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    private readonly IDbConnection _db;
    public VaultRepository(IDbConnection db) => _db = db;
    // public IEnumerable<Vault> GetAll()
    // {
    //   try
    //   {
    //     return _db.Query<Vault>("SELECT * FROM vaults");
    //   }
    //   catch (Exception e)
    //   {
    //     throw e;
    //   }
    // }

    public IEnumerable<Vault> GetById(string id)
    {
      try
      {
        string query = "SELECT * FROM vaults WHERE userId = @id";
        IEnumerable<Vault> data = _db.Query<Vault>(query, new { id });
        if (data is null) throw new Exception("Invalid Id");
        return data;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Vault Create(Vault value)
    {
      try
      {
        string query = @"INSERT INTO vaults (name, description, userId)
                VALUES (@Name, @Description, @UserId);
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

    public Vault Update(Vault value)
    {
      try
      {
        string query = @"
        UPDATE vaults
        SET
        name = @Name,
        description = @Description
        WHERE id = @Id;
        SELECT * FROM vaults WHERE id = @Id;
        ";
        return _db.QueryFirstOrDefault<Vault>(query, value);
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public string Delete(int id, string userId)
    {
      try
      {
        string query = "DELETE FROM vaults WHERE id = @id AND userId = @UserId;";
        int changedRows = _db.Execute(query, new { id, userId });
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