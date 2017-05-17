using System;
using System.Collections;
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
		/// <param name="account">账号</param>
		/// <param name="password">密码</param>
		public static object Login(string account, string password)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_Login", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@account",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15,
					Value = account
				});
				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@password",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15,
					Value = password
				});
				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@return",
					Direction = ParameterDirection.ReturnValue,
					SqlDbType = SqlDbType.Int
				});

				sqlCom.ExecuteNonQuery();

				return sqlCom.Parameters["@return"].Value;
			}
		}

		/// <summary>
		/// 增加一个新用户
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>增加结果</returns>
		public static object CreateUser(UserModel user)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_CreateUser", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@name",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 30,
					Value = user.Name
				});

				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@account",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15,
					Value = user.Account
				});

				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@password",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15,
					Value = user.Password
				});
				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@level",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15,
					Value = user.Level
				});
				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@sex",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 10,
					Value = user.Sex
				});
				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@tel",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 12,
					Value = user.Tel
				});
				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@return",
					Direction = ParameterDirection.ReturnValue,
					SqlDbType = SqlDbType.Int
				});

				sqlCom.ExecuteNonQuery();

				return sqlCom.Parameters["@return"].Value;
			}
		}

		/// <summary>
		/// 删除一个用户
		/// </summary>
		/// <param name="account">需要删除的用户账号</param>
		/// <returns>删除结果</returns>
		public static object DeleteUser(string account)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_DeleteUser", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@account",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15,
					Value = account
				});

				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@return",
					Direction = ParameterDirection.ReturnValue,
					SqlDbType = SqlDbType.Int
				});

				sqlCom.ExecuteNonQuery();

				return sqlCom.Parameters["@return"].Value;
			}
		}

		/// <summary>
		/// 用户修改密码
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>修改密码结果</returns>
		public static object UpdateUserPassword(UserModel user)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_UpdateUserPassword", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@account",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15,
					Value = user.Account
				});
				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@newPassword",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15,
					Value = user.Password
				});
				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@return",
					Direction = ParameterDirection.ReturnValue,
					SqlDbType = SqlDbType.Int
				});

				sqlCom.ExecuteNonQuery();

				return sqlCom.Parameters["@return"].Value;
			}
		}

		/// <summary>
		/// 获得用户信息
		/// </summary>
		/// <param name="account"></param>
		/// <returns></returns>
		public static object GetUser(string account)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_GetUser", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@account",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 18,
					Value = account
				});

				sqlCom.ExecuteNonQuery();

				var reader = sqlCom.ExecuteReader();
				if (reader.Read())
				{
					return new
					{
						userName = reader[0] != DBNull.Value ? (string)reader[0] : null ,
						userAccount = reader[1] != DBNull.Value ? (string)reader[1] : null,
						userPassword = reader[2] != DBNull.Value ? (string)reader[2] : null,
						userCreateTime = (DateTime)reader[3],
						userLastSignInTime = (DateTime)reader[4],
						userLevel = (string)reader[5],
						userSex = reader[6] != DBNull.Value ? (string)reader[6] : null,
						userAvatar = reader[7] != DBNull.Value ? (BitArray)reader[7] : null,
						userTel = reader[8] != DBNull.Value ? (string)reader[8] : null
					};
				}
				return null;
			}
		}

		/// <summary>
		/// 用户修改等级
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>修改等级结果</returns>
		public static object UpdateUserLevel(UserModel user)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_UpdateUserLevel", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@account",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15,
					Value = user.Account
				});
				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@newLevel",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15,
					Value = user.Level
				});
				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@return",
					Direction = ParameterDirection.ReturnValue,
					SqlDbType = SqlDbType.Int
				});

				sqlCom.ExecuteNonQuery();

				return sqlCom.Parameters["@return"].Value;
			}
		}

		/// <summary>
		/// 用户修改电话
		/// </summary>
		/// <param name="user">用户</param>
		/// <returns>修改电话结果</returns>
		public static object UpdateUserTel(UserModel user)
		{
			using (var con = new SqlConnection(Server.SqlConString))
			{
				con.Open();

				var sqlCom = new SqlCommand("sp_UpdateUserTel", con)
				{
					CommandType = CommandType.StoredProcedure
				};

				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@account",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15,
					Value = user.Account
				});
				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@newTel",
					Direction = ParameterDirection.Input,
					SqlDbType = SqlDbType.NVarChar,
					Size = 15,
					Value = user.Tel
				});
				sqlCom.Parameters.Add(new SqlParameter
				{
					ParameterName = "@return",
					Direction = ParameterDirection.ReturnValue,
					SqlDbType = SqlDbType.Int
				});

				sqlCom.ExecuteNonQuery();

				return sqlCom.Parameters["@return"].Value;
			}
		}
	}
}
