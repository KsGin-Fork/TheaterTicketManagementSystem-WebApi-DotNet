using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TTMSWebAPI.Models;

namespace TTMSWebAPI.Servers
{
    /// <summary>
    /// 用户操作Server
    /// </summary>
	public static class UserServer
	{
		/// <summary>
		/// 登陆
		/// </summary>
		/// <returns>登陆结果</returns>
		/// <param name="lm">用户</param>
		public static object Login(LoginModel lm)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_Login", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.AddRange(new[]
				{
					new SqlParameter
					{
						ParameterName = "@account",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.NVarChar,
						Size = 15,
						Value = lm.Account
					},
					new SqlParameter
					{
						ParameterName = "@password",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.NVarChar,
						Size = 15,
						Value = lm.Password
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
		/// 增加一个新用户
		/// </summary>
		/// <param name="cm">用户</param>
		/// <returns>增加结果</returns>
		public static object CreateUser(CreateUserModel cm)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_CreateUser", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.AddRange(new []
				{
					new SqlParameter
					{
						ParameterName = "@name",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.NVarChar,
						Size = 30,
						Value = cm.Name
					},
					new SqlParameter
					{
						ParameterName = "@account",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.NVarChar,
						Size = 15,
						Value = cm.Account
					},
					new SqlParameter
					{
						ParameterName = "@password",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.NVarChar,
						Size = 15,
						Value = cm.Password
					},
					new SqlParameter
					{
						ParameterName = "@level",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.NVarChar,
						Size = 15,
						Value = cm.Level
					},
					new SqlParameter
					{
						ParameterName = "@sex",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.NVarChar,
						Size = 10,
						Value = cm.Sex
					},
					new SqlParameter
					{
						ParameterName = "@tel",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.NVarChar,
						Size = 12,
						Value = cm.Tel
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
		/// 删除一个用户
		/// </summary>
		/// <param name="id">Id</param>
		/// <returns>删除结果</returns>
		public static object DeleteUser(int id)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_DeleteUser", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.AddRange(new []
				{
					new SqlParameter
					{
						ParameterName = "@userId",
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
		
		/// <summary>
		/// 用户修改密码
		/// </summary>
		/// <param name="um">用户</param>
		/// <returns>修改密码结果</returns>
		public static object UpdateUserPassword(UpdateUserPasswordModel um)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_UpdateUser", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.AddRange(new []
				{
					new SqlParameter
					{
						ParameterName = "@userId",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.Int,
						Value = um.Id
					},
					new SqlParameter
					{
						ParameterName = "@newPassword",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.NVarChar,
						Size = 15,
						Value = um.Password
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
		/// 用户修改等级
		/// </summary>
		/// <param name="um">用户</param>
		/// <returns>修改等级结果</returns>
		public static object UpdateUserLevel(UpdateUserLevelModel um)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_UpdateUser", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.AddRange(new []
				{
					new SqlParameter
					{
						ParameterName = "@userId",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.Int,
						Value = um.Id
					},
					new SqlParameter
					{
						ParameterName = "@newLevel",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.NVarChar,
						Size = 15,
						Value = um.Level
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
		/// 用户修改电话
		/// </summary>
		/// <param name="um">用户</param>
		/// <returns>修改电话结果</returns>
		public static object UpdateUserTel(UpdateUserTelModel um)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_UpdateUser", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.AddRange(new []
				{
					new SqlParameter
					{
						ParameterName = "@userId",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.Int,
						Value = um.Id
					},
					new SqlParameter
					{
						ParameterName = "@newTel",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.NVarChar,
						Size = 15,
						Value = um.Tel
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
		/// 获得用户信息
		/// </summary>
		/// <param name="account">用户账号</param>
		/// <returns></returns>
		public static object QueryUserByAccount(string account)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_QueryUser", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.AddRange(new []
				{
					new SqlParameter
					{
						ParameterName = "@account",
						Direction = ParameterDirection.Input,
						SqlDbType = SqlDbType.NVarChar,
						Size = 18,
						Value = account
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
				
				var msg = (string) sqlCom.Parameters["@message"].Value;

				object data = null;

				var reader = sqlCom.ExecuteReader();
				if (reader.Read())
				{
					data = new
					{
						userId = (int)reader[0],
						userName = reader[1] != DBNull.Value ? (string)reader[1] : null ,
						userAccount = reader[2] != DBNull.Value ? (string)reader[2] : null,
						userPassword = reader[3] != DBNull.Value ? (string)reader[3] : null,
						userCreateTime = (DateTime)reader[4],
						userLastSignInTime = (DateTime)reader[5],
						userLevel = (string)reader[6],
						userSex = reader[7] != DBNull.Value ? (string)reader[7] : null,
						userAvatar = reader[8] != DBNull.Value ? (BitArray)reader[8] : null,
						userTel = reader[9] != DBNull.Value ? (string)reader[9] : null
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
		/// 获得用户信息
		/// </summary>
		/// <param name="id">用户Id</param>
		/// <returns></returns>
		public static object QueryUserById(int id)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_QueryUser", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.AddRange(new []
				{
					new SqlParameter
					{
						ParameterName = "@userId",
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
				
				var msg = (string) sqlCom.Parameters["@message"].Value;

				object data = null;

				var reader = sqlCom.ExecuteReader();
				if (reader.Read())
				{
					data = new
					{
						userId = (int)reader[0],
						userName = reader[1] != DBNull.Value ? (string)reader[1] : null ,
						userAccount = reader[2] != DBNull.Value ? (string)reader[2] : null,
						userPassword = reader[3] != DBNull.Value ? (string)reader[3] : null,
						userCreateTime = (DateTime)reader[4],
						userLastSignInTime = (DateTime)reader[5],
						userLevel = (string)reader[6],
						userSex = reader[7] != DBNull.Value ? (string)reader[7] : null,
						userAvatar = reader[8] != DBNull.Value ? (BitArray)reader[8] : null,
						userTel = reader[9] != DBNull.Value ? (string)reader[9] : null
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
		/// 获得所有用户
		/// </summary>
		/// <returns></returns>
		public static object GetAllUser()
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var message = "";
				
				var sqlCom = new SqlCommand("sp_GetAllUser", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.AddRange(new []
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
						userId = (int)reader[0],
						userName = reader[1] != DBNull.Value ? (string)reader[1] : null ,
						userAccount = reader[2] != DBNull.Value ? (string)reader[2] : null,
						userPassword = reader[3] != DBNull.Value ? (string)reader[3] : null,
						userCreateTime = (DateTime)reader[4],
						userLastSignInTime = (DateTime)reader[5],
						userLevel = (string)reader[6],
						userSex = reader[7] != DBNull.Value ? (string)reader[7] : null,
						userAvatar = reader[8] != DBNull.Value ? (BitArray)reader[8] : null,
						userTel = reader[9] != DBNull.Value ? (string)reader[9] : null
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
