using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TTMSWebAPI.Models;

namespace TTMSWebAPI.Servers
{
    /// <summary>
    /// 剧目管理Server
    /// </summary>
    public class ProgrammeServer
    {
        /// <summary>
        /// 获得所有剧目
        /// </summary>
        /// <returns>剧目列表</returns>
        public static object GetAllProgramme()
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_GetAllProgramme", con)
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
                        programmeId = (int) reader[0],
                        programmeName = (string) reader[1],
                        programmeDruation = (int) reader[2],
                        programmeTags = (string) reader[3],
                        programmeProfile = (string) reader[4]
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
        /// 查询剧目信息
        /// </summary>
        /// <param name="programmeName">剧目名称</param>
        /// <returns>剧目信息</returns>
        public static object QueryProgramme(string programmeName)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_QueryProgramme", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@programmeName",
                        Direction = ParameterDirection.Input,
                        Size = 50,
                        SqlDbType = SqlDbType.NVarChar,
                        Value = programmeName
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
                        programmeId = (int) reader[0],
                        programmeName = (string) reader[1],
                        programmeDruation = (int) reader[2],
                        programmeTags = (string) reader[3],
                        programmeProfile = (string) reader[4]
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
        /// 查询剧目信息
        /// </summary>
        /// <param name="programmeId">剧目ID</param>
        /// <returns>剧目信息</returns>
        public static object QueryProgramme(int programmeId)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_QueryProgramme", con)
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

                object data = null;

                var reader = sqlCom.ExecuteReader();

                if (reader.Read())
                {
                    data = new
                    {
                        programmeId = (int) reader[0],
                        programmeName = (string) reader[1],
                        programmeDruation = (int) reader[2],
                        programmeTags = (string) reader[3],
                        programmeProfile = (string) reader[4]
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
        /// 新建一个剧目
        /// </summary>
        /// <param name="cm">新建剧目模型</param>
        /// <returns>新建结果</returns>
        public static object CreateProgramme(CreateProgrammeModel cm)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var sqlCom = new SqlCommand("sp_CreateProgramme", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@proName",
                        Direction = ParameterDirection.Input,
                        Size = 50,
                        SqlDbType = SqlDbType.NVarChar,
                        Value = cm.ProgrammeName
                    },
                    new SqlParameter
                    {
                        ParameterName = "@duration",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Int,
                        Value = cm.Duration
                    },
                    new SqlParameter
                    {
                        ParameterName = "@tags",
                        Direction = ParameterDirection.Input,
                        Size = 20,
                        SqlDbType = SqlDbType.NVarChar,
                        Value = cm.Tags
                    },
                    new SqlParameter
                    {
                        ParameterName = "@profile",
                        Direction = ParameterDirection.Input,
                        SqlDbType = SqlDbType.Text,
                        Value = cm.Profile
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
        /// 删除一个剧目
        /// </summary>
        /// <param name="dm">删除剧目模型</param>
        /// <returns>删除结果</returns>
        public static object DeleteProgramme(DeleteProgrammeModel dm)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var sqlCom = new SqlCommand("sp_DeleteProgramme", con)
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
                        Value = dm.Id
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
        /// 根据标签筛选剧目
        /// </summary>
        /// <param name="tags">标签</param>
        /// <returns>剧目</returns>
        public static object SelectProgramme(string tags)
        {
            using (var con = new SqlConnection(Server.SqlConString))
            {
                con.Open();

                var message = "";

                var sqlCom = new SqlCommand("sp_SelectProgramme", con)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCom.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@tags",
                        Direction = ParameterDirection.Input,
                        Size = 20,
                        SqlDbType = SqlDbType.NVarChar,
                        Value = tags
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
                    data.Add(new
                    {
                        programmeId = (int) reader[0],
                        programmeName = (string) reader[1],
                        programmeDruation = (int) reader[2],
                        programmeTags = (string) reader[3],
                        programmeProfile = (string) reader[4]
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