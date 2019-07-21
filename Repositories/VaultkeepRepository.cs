using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultkeepRepository
  {
    private readonly IDbConnection _db;
    public VaultkeepRepository(IDbConnection db) => _db = db;
    public IEnumerable<Vaultkeep> GetAll()
    {
      try
      {
        return _db.Query<Vaultkeep>("SELECT * FROM vaultkeeps");
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    public Vaultkeep GetById(int id)
    {
      try
      {
        string query = "SELECT * FROM vaultkeeps WHERE id = @Id";
        Vaultkeep data = _db.QueryFirstOrDefault<Vaultkeep>(query, new { id });
        if (data is null) throw new Exception("Invalid Id");
        return data;
      }
      catch (Exception e)
      {
        throw e;
      }
    }

    // public Vaultkeep GetBy(Vaultkeep value)
    // {
    //   //TODO This mehtod may not be necessary
    //   try
    //   {
    //     string query = @"";
    //     return _db.QueryFirstOrDefault<Vaultkeep>(query, value);
    //   }
    //   catch (Exception e)
    //   {
    //     throw e;
    //   }
    // }

    public Vaultkeep Create(Vaultkeep value)
    {
      try
      {
        string query = @"INSERT INTO vaultkeeps (vaultId, keepId)
                VALUES (@VaultId, @KeepId);
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

    public Vaultkeep Update(Vaultkeep value)
    {
      try
      {
        string query = @"
        UPDATE vaultkeeps
        SET
        vaultId = @VaultId,
        keepId = @KeepId
        WHERE id = @Id;
        SELECT * FROM vaultkeeps WHERE id = @Id;
        ";
        return _db.QueryFirstOrDefault<Vaultkeep>(query, value);
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
        string query = "DELETE FROM vaultkeeps WHERE id = @id;";
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