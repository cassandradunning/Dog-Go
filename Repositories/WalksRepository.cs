﻿using DogGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public class WalksRepository :IWalksRepository

    {
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public WalksRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public List<Walks> GetWalksByWalkerId(int @walkerId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT Id, Date, Duration, WalkerId, DogId
                        FROM Walks
                        where WalkerId =@walkerId
                    ";
                    cmd.Parameters.AddWithValue("@walkerId", walkerId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Walks> walks = new List<Walks>();
                        while (reader.Read())
                        {
                            Walks walk = new Walks
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Date = reader.GetDateTime(reader.GetOrdinal("Date")),
                                Duration = reader.GetInt32(reader.GetOrdinal("Duration")),
                                WalkerId = reader.GetInt32(reader.GetOrdinal("WalkerId"))
                            };

                            walks.Add(walk);
                        }

                        return walks;
                    }
                }
            }
        }

    }
}
