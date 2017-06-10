using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TTMSWebAPI.Models;

namespace TTMSWebAPI.Servers
{
    /// <summary>
    /// 订单Server
    /// </summary>
    public class OrderServer
    {
        /// <summary>
        /// 获得所有订单
        /// </summary>
        /// <returns>订单列表</returns>
        public static object GetAllOrder()
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_GetAllOrder", con)
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
                    data.Add( new
                    {
                        orderId = (int) reader[0],
                        ticketId = (int) reader[1],
                        userId = (int) reader[2],
                        type = (int) reader[3],
                        dateTime = (DateTime) reader[4],
                        theaterId = (int) reader[5]
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
        /// 筛选订单
        /// </summary>
        /// <param name="sm">筛选模型</param>
        /// <returns>筛选结果</returns>
        public static object SelectOrder(SelectOrderModel sm)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_SelectOrder", con)
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
                        Value = sm.TheaterId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@userId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = sm.UserId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@tradeDate",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date,
                        Value = sm.TradeDate
                    },
                    new SqlParameter
                    {
                        ParameterName = "@type",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = sm.Type
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

                var data = new List<object>();

                var reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    data.Add( new
                    {
                        orderId = (int) reader[0],
                        ticketId = (int) reader[1],
                        userId = (int) reader[2],
                        type = (int) reader[3],
                        dateTime = (DateTime) reader[4],
                        theaterId = (int) reader[5]
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
        /// 分析销售情况
        /// </summary>
        /// <param name="am">分析模型</param>
        /// <returns></returns>
        public static object AnalyseOrder(AnalyseOrderModel am)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_AnalyseOrder", con)
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
                        Value = am.TheaterId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@userId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = am.UserId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@tradeDate",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date,
                        Value = am.TradeDate
                    },
                    new SqlParameter
                    {
                        ParameterName = "@dateLength",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = am.DateLength
                    },
                    new SqlParameter
                    {
                        ParameterName = "@programmeId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = am.ProgrammeId
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

                while (reader.Read())
                {
                    data = new
                    {
                        tradeTimes = reader[0] == DBNull.Value ? 0 : (int) reader[0],
                        sumPrice = reader[1] == DBNull.Value ? 0 : (decimal) reader[1],
                        sumProfit = reader[2] == DBNull.Value ? 0 : (decimal) reader[1],
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
    }
}