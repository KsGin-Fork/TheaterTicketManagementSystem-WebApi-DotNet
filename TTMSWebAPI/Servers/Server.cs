using System;
using System.Data.SqlClient;
using System.DrawingCore;
using System.DrawingCore.Imaging;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using TTMSWebAPI.Models;

namespace TTMSWebAPI.Servers
{
    /// <summary>
    /// Server类
    /// </summary>
    public static class Server
	{
		/// <summary>
		/// 连接字符串
		/// </summary>
		public static string SqlConString = "";

		/// <summary>
		/// 日志
		/// </summary>
		/// <param name="msg"></param>
		public static void Log(string msg)
		{
			File.AppendAllText("log.txt", DateTime.Now + " : " + msg + "\n");
		}

		/// <summary>
		/// 获得用户ID
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public static string GetUserIp(HttpContext context)
		{
			var ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();
			if (string.IsNullOrEmpty(ip))
			{
				ip = context.Connection.RemoteIpAddress.MapToIPv4().ToString();
			}

			return ip;
		}


		/// <summary>
		/// 对用户IP进行处理
		/// </summary>
		/// <param name="ip"></param>
		/// <returns></returns>
		public static int IpHandle(string ip)
		{
			using (var con = new SqlConnection(SqlConString))
			{
				con.Open();

				var str = "SELECT limitTimes FROM UserIPs WHERE ip = '" + ip + "'";

				var result = new SqlCommand(str, con).ExecuteReader();

				if (result.Read())
				{
					var times = (int) result[0];

					if (times == 0)
						return 0;
					if (times == -1)
						return -1;

					var limitTimes = times - 1;

					str = "UPDATE UserIPs SET limitTimes = " + limitTimes +
					      " WHERE ip = '" + ip + "'";

					new SqlCommand(str, con).ExecuteNonQuery();

					return times;
				}
				str = "INSERT INTO UserIPs (ip) values ( ( '" + ip + "' ) );";

				new SqlCommand(str, con).ExecuteNonQuery();

				return 500;
			}
		}

		/// <summary>
		/// 验证码Base64
		/// </summary>
		/// <returns></returns>
		public static VerCodeModel VerCode()
		{
			const int codeW = 80;
			const int codeH = 30;
			const int fontSize = 16;
		    var chkCode = new int[4];
		    var verCode = string.Empty;

            //生成随机数
		    var tick = DateTime.Now.Ticks;
		    var r = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            for (var i = 0; i < 4; i++)
            { 
		        chkCode[i] = r.Next() % 10;
		        verCode += chkCode[i];
		    }

			var rnd = new Random();
			//颜色列表，用于验证码、噪线、噪点 
			Color[] color =
				{Color.Black, Color.Red, Color.Blue, Color.Green, Color.Orange, Color.Brown, Color.Brown, Color.DarkBlue};
			//字体列表，用于验证码 
			string[] font = {"Times New Roman"};
			//验证码的字符集，去掉了一些容易混淆的字符 
			//写入Session、验证码加密
			//WebHelper.WriteSession("session_verifycode", Md5Helper.MD5(chkCode.ToLower(), 16));
			//创建画布
			var bmp = new Bitmap(codeW, codeH);
			var g = Graphics.FromImage(bmp);
			g.Clear(Color.White);
			//画噪线 
			for (var i = 0; i < 1; i++)
			{
				var x1 = rnd.Next(codeW);
				var y1 = rnd.Next(codeH);
				var x2 = rnd.Next(codeW);
				var y2 = rnd.Next(codeH);
				var clr = color[rnd.Next(color.Length)];
				g.DrawLine(new Pen(clr), x1, y1, x2, y2);
			}
			//画验证码字符串 
			for (var i = 0; i < chkCode.Length; i++)
			{
				var fnt = font[rnd.Next(font.Length)];
				var ft = new Font(fnt, fontSize);
				var clr = color[rnd.Next(color.Length)];
				g.DrawString(chkCode[i].ToString(), ft, new SolidBrush(clr), (float) i * 18, (float) 0);
			}
			//将验证码图片写入内存流，并将其以 "image/Png" 格式输出 
			var ms = new MemoryStream();
			try
			{
				bmp.Save(ms, ImageFormat.Png);
			    return new VerCodeModel
			    {
			        code = verCode , 
			        base64 = ms.ToArray()
			    };
			}
			catch (Exception)
			{
				return null;
			}
			finally
			{
				g.Dispose();
				bmp.Dispose();
			}
		}
	}
}
