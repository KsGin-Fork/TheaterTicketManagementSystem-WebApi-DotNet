using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TTMSWebAPI.Models;

namespace TTMSWebAPI.Servers
{
    /// <summary>
    /// 影厅Server
    /// </summary>
    public static class TheaterServer
    {
        /// <summary>
        /// 获得所有影厅
        /// </summary>
        /// <returns></returns>
        public static object GetAllTheater()
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_GetAllTheater", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@message",
                        Direction = ParameterDirection.Output,
                        Size = 30,
                        SqlDbType = SqlDbType.VarChar,
                        Value = message
                    },
                    new SqlParameter
                    {
                        ParameterName = "@return",
                        Direction = ParameterDirection.ReturnValue,
                        SqlDbType = SqlDbType.Int
                    }
                });

                sqlCom.ExecuteNonQuery();

                var msg = (string) sqlCom.Parameters["@message"].Value;

                var data = new List<object>();

                var reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new
                    {
                        theaterId = (int) reader[0],
                        theaterName = reader[1] != DBNull.Value ? (string) reader[1] : null,
                        theaterLocation = reader[2] != DBNull.Value ? (string) reader[2] : null,
                        theaterMapSite = reader[3] != DBNull.Value ? (string) reader[3] : null,
                        theaterAdmitId = (int) reader[4],
                        theaterSeatRowsCount = (int) reader[5],
                        theaterSeatColsCount = (int) reader[6]
                    });
                }

                return new
                {
                    result = (int) sqlCom.Parameters["@return"].Value,
                    msg,
                    data
                };
            }
        }

        /// <summary>
        /// 查询影厅
        /// </summary>
        /// <param name="theaterId">影厅Id</param>
        /// <returns></returns>
        public static object QueryTheater(int theaterId)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_QueryTheater", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@theaterId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = theaterId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@message",
                        Direction = ParameterDirection.Output,
                        Size = 30,
                        SqlDbType = SqlDbType.VarChar,
                        Value = message
                    },
                    new SqlParameter
                    {
                        ParameterName = "@return",
                        Direction = ParameterDirection.ReturnValue,
                        SqlDbType = SqlDbType.Int
                    }
                });

                sqlCom.ExecuteNonQuery();

                var msg = (string) sqlCom.Parameters["@message"].Value;

                object data = null;

                var reader = sqlCom.ExecuteReader();

                if (reader.Read())
                {
                    data = new
                    {
                        theaterId = (int) reader[0],
                        theaterName = reader[1] != DBNull.Value ? (string) reader[1] : null,
                        theaterLocation = reader[2] != DBNull.Value ? (string) reader[2] : null,
                        theaterMapSite = reader[3] != DBNull.Value ? (string) reader[3] : null,
                        theaterAdmitId = (int) reader[4],
                        theaterSeatRowsCount = (int) reader[5],
                        theaterSeatColsCount = (int) reader[6]
                    };
                }

                return new
                {
                    result = (int) sqlCom.Parameters["@return"].Value,
                    msg,
                    data
                };
            }
        }
        
        /// <summary>
        /// 修改影厅管理者
        /// </summary>
        /// <param name="um">修改影厅管理者模型</param>
        /// <returns>修改结果</returns>
        public static object UpdateTheaterAdminId(UpdateTheaterAdminIDModel um)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var sqlCom = new SqlCommand("sp_UpdateTheater", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@theaterId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = um.Id
                    },
                    new SqlParameter
                    {
                        ParameterName = "@newAdminId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 15,
                        Value = um.NewAdminId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@message",
                        Direction = ParameterDirection.Output,
                        Size = 30,
                        SqlDbType = SqlDbType.VarChar
                    },
                    new SqlParameter
                    {
                        ParameterName = "@return",
                        Direction = ParameterDirection.ReturnValue,
                        SqlDbType = SqlDbType.Int
                    }
                });

                sqlCom.ExecuteNonQuery();

                return new
                {
                    result = (int) sqlCom.Parameters["@return"].Value,
                    msg = (string) sqlCom.Parameters["@message"].Value
                };
            }
        }

        /// <summary>
        /// 创建一个新演出厅
        /// </summary>
        /// <param name="cm">演出厅信息</param>
        /// <returns>创建结果</returns>
        public static object CreateTheater(CreateTheaterModel cm)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var sqlCom = new SqlCommand("sp_CreateTheater", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@theaterName",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 30,
                        Value = cm.TheaterName
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Location",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 30,
                        Value = cm.Location
                    },
                    new SqlParameter
                    {
                        ParameterName = "@MapSite",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 30,
                        Value = cm.MapSite
                    },
                    new SqlParameter
                    {
                        ParameterName = "@AdminId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = cm.AdminID
                    },
                    new SqlParameter
                    {
                        ParameterName = "@seatRowsCount",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = cm.SeatRowCount
                    },
                    new SqlParameter
                    {
                        ParameterName = "@seatColsCount",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = cm.SeatColCount
                    },
                    new SqlParameter
                    {
                        ParameterName = "@message",
                        Direction = ParameterDirection.Output,
                        Size = 30,
                        SqlDbType = SqlDbType.VarChar
                    },
                    new SqlParameter
                    {
                        ParameterName = "@return",
                        Direction = ParameterDirection.ReturnValue,
                        SqlDbType = SqlDbType.Int
                    }
                });

                sqlCom.ExecuteNonQuery();

                return new
                {
                    result = (int) sqlCom.Parameters["@return"].Value,
                    msg = (string) sqlCom.Parameters["@message"].Value
                };
            }
        }

        /// <summary>
        /// 删除一个演出厅
        /// </summary>
        /// <param name="id">演出厅Id</param>
        /// <returns>删除结果</returns>
        public static object DeleteTheater(int id)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var sqlCom = new SqlCommand("sp_DeleteTheater", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@theaterId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = id
                    },
                    new SqlParameter
                    {
                        ParameterName = "@message",
                        Direction = ParameterDirection.Output,
                        Size = 30,
                        SqlDbType = SqlDbType.VarChar
                    },
                    new SqlParameter
                    {
                        ParameterName = "@return",
                        Direction = ParameterDirection.ReturnValue,
                        SqlDbType = SqlDbType.Int
                    }
                });

                sqlCom.ExecuteNonQuery();

                return new
                {
                    result = (int) sqlCom.Parameters["@return"].Value,
                    msg = (string) sqlCom.Parameters["@message"].Value
                };
            }
        }
    }
}