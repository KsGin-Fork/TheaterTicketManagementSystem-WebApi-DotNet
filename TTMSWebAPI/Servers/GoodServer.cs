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

                var msg = (string) sqlCom.Parameters["@message"].Value;

                var data = new List<object>();

                var reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    data.Add( new
                    {
                        goodId = (int) reader[0],
                        programmeId = (int) reader[1],
                        theaterId = (int) reader[2],
                        performance = (string) reader[3],
                        playDate = (DateTime) reader[4],
                        price = (decimal) reader[5]
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

                var msg = (string) sqlCom.Parameters["@message"].Value;

                object data = null;

                var reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    data = new
                    {
                        goodId = (int) reader[0],
                        programmeId = (int) reader[1],
                        theaterId = (int) reader[2],
                        performance = (string) reader[3],
                        playDate = (DateTime) reader[4],
                        price = (decimal) reader[5]
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
        /// 根据放映厅筛选上架商品
        /// </summary>
        /// <param name="theaterId">放映厅ID</param>
        /// <returns></returns>
        public static object SelectGoodByTheater(int theaterId)
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

                var data = new List<object>();

                var reader = sqlCom.ExecuteReader();

                while (reader.Read())
                {
                    data.Add( new
                    {
                        goodId = (int) reader[0],
                        programmeId = (int) reader[1],
                        theaterId = (int) reader[2],
                        performance = (string) reader[3],
                        playDate = (DateTime) reader[4],
                        price = (decimal) reader[5]
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
        /// 根据节目筛选ID
        /// </summary>
        /// <param name="programmeId"></param>
        /// <returns></returns>
        public static object SelectGoodByProgramme(int programmeId)
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
                        ParameterName = "@programmeId",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = programmeId
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
                        goodId = (int) reader[0],
                        programmeId = (int) reader[1],
                        theaterId = (int) reader[2],
                        performance = (string) reader[3],
                        playDate = (DateTime) reader[4],
                        price = (decimal) reader[5]
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
                    result = (int) sqlCom.Parameters["@return"].Value,
                    msg = (string) sqlCom.Parameters["@message"].Value
                };
            }

        }

        /// <summary>
        /// 下架商品
        /// </summary>
        /// <param name="dm">下架模型</param>
        /// <returns>下架结果</returns>
        public static object DeleteGood(DeleteGoodModel dm)
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
                        Value = dm.GoodId
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
        /// 根据日期筛选商品
        /// </summary>
        /// <param name="date">日期(e.g.xxxx-xx-xx)</param>
        /// <returns></returns>
        public static object SelectGoodByDate(string date)
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
                        ParameterName = "@playDate",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Date,
                        Value = date
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
                        goodId = (int) reader[0],
                        programmeId = (int) reader[1],
                        theaterId = (int) reader[2],
                        performance = (string) reader[3],
                        playDate = (DateTime) reader[4],
                        price = (decimal) reader[5]
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
        /// 根据场次筛选商品
        /// </summary>
        /// <param name="performance">场次(e.g.早一)</param>
        /// <returns></returns>
        public static object SelectGoodByPerformance(string performance)
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
                        ParameterName = "@performance",
                        Direction = ParameterDirection.Input,
                        Size = 10 ,
                        SqlDbType = SqlDbType.NVarChar,
                        Value = performance
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
                        goodId = (int) reader[0],
                        programmeId = (int) reader[1],
                        theaterId = (int) reader[2],
                        performance = (string) reader[3],
                        playDate = (DateTime) reader[4],
                        price = (decimal) reader[5]
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
    }
}