using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TTMSWebAPI.Models;

namespace TTMSWebAPI.Servers
{
    /// <summary>
    /// 商品Server
    /// </summary>
    public class GoodServer
    {
        /// <summary>
        /// 获得所有上架商品
        /// </summary>
        /// <returns></returns>
        public static object GetAllGood()
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_GetAllGood", con)
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

                var msg = (string)sqlCom.Parameters["@message"].Value;

                var data = new List<object>();

                var reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    data.Add(new
                    {
                        goodId = (int)reader[0],
                        programmeId = (int)reader[1],
                        theaterId = (int)reader[2],
                        performance = (string)reader[3],
                        playDate = (DateTime)reader[4],
                        price = (decimal)reader[5]
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
        /// 查询上架商品
        /// </summary>
        /// <param name="goodId">商品ID</param>
        /// <returns></returns>
        public static object QueryGood(int goodId)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_QueryGood", con)
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

                object data = null;

                var reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    data = new
                    {
                        goodId = (int)reader[0],
                        programmeId = (int)reader[1],
                        theaterId = (int)reader[2],
                        performance = (string)reader[3],
                        playDate = (DateTime)reader[4],
                        price = (decimal)reader[5]
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
        /// 筛选上架商品
        /// </summary>
        /// <returns></returns>
        public static object SelectGood(SelectGoodModel sgm)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_SelectGood", con)
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
                        Value = sgm.TheaterId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@programmeId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = sgm.ProgrammeId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@playDate",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date,
                        Value = sgm.PlayDate
                    },
                    new SqlParameter
                    {
                        ParameterName = "@performance",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 10,
                        Value = sgm.Performance
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
                        goodId = (int)reader[0],
                        programmeId = (int)reader[1],
                        theaterId = (int)reader[2],
                        performance = (string)reader[3],
                        playDate = (DateTime)reader[4],
                        price = (decimal)reader[5]
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
        /// 上架商品
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public static object CreateGood(CreateGoodModel cm)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var sqlCom = new SqlCommand("sp_CreateGood", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@programmeId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = cm.ProgrammeId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@theaterId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = cm.TheaterId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@performance",
                        Direction = ParameterDirection.Input,
                        Size = 10,
                        SqlDbType = SqlDbType.NVarChar,
                        Value = cm.Performance
                    },
                    new SqlParameter
                    {
                        ParameterName = "@playDate",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date,
                        Value = cm.PlayDate
                    },
                    new SqlParameter
                    {
                        ParameterName = "@price",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = cm.Price
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
        /// 下架商品
        /// </summary>
        /// <param name="id">商品id</param>
        /// <returns>下架结果</returns>
        public static object DeleteGood(int id)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var sqlCom = new SqlCommand("sp_DeleteGood", con)
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
                    result = (int)sqlCom.Parameters["@return"].Value,
                    msg = (string)sqlCom.Parameters["@message"].Value
                };
            }
        }

    }
}