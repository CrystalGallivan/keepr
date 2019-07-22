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

    // public IEnumerable<Vaultkeep> GetById(int vaultId, string userId)
    // {
    //   try
    //   {
    //     string query = @"
    //     SELECT * FROM vaultkeeps vk
    //     INNER JOIN keeps k ON k.id = vk.keepId
    //     WHERE(vaultId = @vaultId AND vk.userId = @userId)";
    //     IEnumerable<Vaultkeep> data = _db.Query<Vaultkeep>(query, new { vaultId, userId });
    //     if (data is null) throw new Exception("Invalid Id");
    //     return data;
    //   }
    //   catch (Exception e)
    //   {
    //     throw e;
    //   }
    // }
    public IEnumerable<Keep> GetById(int vaultId, string userId)
    {
      try
      {
        string query = @"
        SELECT * FROM vaultkeeps vk
        INNER JOIN keeps k ON k.id = vk.keepId
        WHERE(vaultId = @vaultId AND vk.userId = @userId)";
        IEnumerable<Keep> data = _db.Query<Keep>(query, new { vaultId, userId });
        if (data is null) throw new Exception("Invalid Id");
        return data;
      }
      catch (Exception e)
      {
        throw e;
      }
    }
    public Vaultkeep Create(Vaultkeep value)
    {
      try
      {

        string query = @"INSERT INTO vaultkeeps (vaultId, keepId, userId)
                VALUES (@VaultId, @KeepId, @userId);
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

    public string Delete(Vaultkeep value)
    {
      try
      {
        string query = @"
        DELETE FROM vaultkeeps
        WHERE (
        vaultId = @VaultId AND
        keepId = @KeepId AND
        userId = @UserId);
        ";
        // SELECT * FROM vaultkeeps WHERE userId = @UserId;
        Vaultkeep data = _db.QueryFirstOrDefault<Vaultkeep>(query, value);
        if (data != null) throw new Exception("VaultKeep did not delete.");
        return "Successfuly Deleted";
      }
      catch (Exception e)
      {
        throw e;
      }
    }

  }
}