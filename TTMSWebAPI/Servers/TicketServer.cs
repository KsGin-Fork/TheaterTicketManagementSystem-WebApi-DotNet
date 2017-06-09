using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TTMSWebAPI.Servers
{
    /// <summary>
    /// 票操作Server
    /// </summary>
    public class TicketServer
    {
        /// <summary>
        /// 售票
        /// </summary>
        /// <param name="ticketId">票ID</param>
        /// <returns>售票结果</returns>
        public static object SellTicket(int ticketId)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var sqlCom = new SqlCommand("sp_SellTicket", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@ticketId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = ticketId
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
                    result = (int)sqlCom.Parameters["@return"].Value,
                    msg = (string)sqlCom.Parameters["@message"].Value
                };
            }
        }

        /// <summary>
        /// 退票
        /// </summary>
        /// <param name="ticketId">票ID</param>
        /// <param name="userId">用户ID</param>
        /// <returns>退票结果</returns>
        public static object ReturnedTicket(int ticketId, int userId)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var sqlCom = new SqlCommand("sp_ReturnedTicket", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@ticketId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = ticketId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@userId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = userId
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
                    result = (int)sqlCom.Parameters["@return"].Value,
                    msg = (string)sqlCom.Parameters["@message"].Value
                };
            }
        }

        /// <summary>
        /// 查询节目的票
        /// </summary>
        /// <returns>票列表</returns>
        public static object SelectTicket(int goodId)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_SelectTicket", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@goodId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = goodId
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

                var msg = (string)sqlCom.Parameters["@message"].Value;

                var data = new List<object>();

                var reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new
                    {
                        Name = (string)reader[0],
                        Duration = (int)reader[1],
                        Tage = (string)reader[2],
                        Profile = (string)reader[3],
                        Performance = (string)reader[4],
                        Date = (DateTime)reader[5],
                        Price = (decimal)reader[6],
                        TheaterName = (string)reader[7],
                        SeatRowNumber = (int)reader[8],
                        SeatColNumber = (int)reader[9],
                        Status = (int)reader[10],
                        Id = (int)reader[11]
                    });
                }

                return new
                {
                    result = (int)sqlCom.Parameters["@return"].Value,
                    msg,
                    data
                };
            }
        }

        /// <summary>
        /// 查询票信息
        /// </summary>
        /// <param name="id">票Id</param>
        /// <returns>票信息</returns>
        public static object QueryTicket(int id)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_QueryTicket", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@ticketId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = id
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

                var msg = (string)sqlCom.Parameters["@message"].Value;

                object data = null;

                var reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    data = new
                    {
                        Name = (string)reader[0],
                        Duration = (int)reader[1],
                        Tage = (string)reader[2],
                        Profile = (string)reader[3],
                        Performance = (string)reader[4],
                        Date = (DateTime)reader[5],
                        Price = (decimal)reader[6],
                        TheaterName = (string)reader[7],
                        SeatRowNumber = (int)reader[8],
                        SeatColNumber = (int)reader[9],
                        Status = (int)reader[10]
                    };
                }

                return new
                {
                    result = (int)sqlCom.Parameters["@return"].Value,
                    msg,
                    data
                };
            }
        }

        /// <summary>
        /// 用户支付
        /// </summary>
        /// <param name="ticketId">票Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public static object PayTicket(int ticketId, int userId)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var sqlCom = new SqlCommand("sp_PayTicket", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@ticketId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = ticketId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@userId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = userId
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
                    result = (int)sqlCom.Parameters["@return"].Value,
                    msg = (string)sqlCom.Parameters["@message"].Value
                };
            }
        }
    }
}