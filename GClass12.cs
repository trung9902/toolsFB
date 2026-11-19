using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Threading;

public class GClass12
{
	internal static GClass12 gclass12_0;
	private static readonly object _dbLock = new object();

	internal string string_0 = "Data Source=database/db_post.db;Version=3;Journal Mode=WAL;BusyTimeout=5000;";

	public static GClass12 GClass12_0
	{
		get
		{
			if (gclass12_0 == null)
			{
				gclass12_0 = new GClass12();
			}
			return gclass12_0;
		}
		private set
		{
			gclass12_0 = value;
		}
	}

	private GClass12()
	{
		try
		{
			if (!Directory.Exists("database"))
			{
				Directory.CreateDirectory("database");
			}

			using (SQLiteConnection sQLiteConnection = new SQLiteConnection(string_0))
			{
				sQLiteConnection.Open();
				using (SQLiteCommand cmd = new SQLiteCommand("PRAGMA journal_mode=WAL; PRAGMA busy_timeout=5000; PRAGMA synchronous=NORMAL;", sQLiteConnection))
				{
					cmd.ExecuteNonQuery();
				}
				sQLiteConnection.Close();
			}
		}
		catch
		{
		}
	}

	public DataTable method_0(string string_1)
	{
		DataTable dataTable = new DataTable();
		lock (_dbLock)
		{
			for (int retry = 0; retry < 5; retry++)
			{
				try
				{
					using (SQLiteConnection sQLiteConnection = new SQLiteConnection(string_0))
					{
						sQLiteConnection.Open();
						using (SQLiteCommand cmdPragma = new SQLiteCommand("PRAGMA busy_timeout=5000;", sQLiteConnection))
						{
							cmdPragma.ExecuteNonQuery();
						}
						using (SQLiteCommand cmd = new SQLiteCommand(string_1, sQLiteConnection))
						{
							using (SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd))
							{
								sQLiteDataAdapter.Fill(dataTable);
							}
						}
						sQLiteConnection.Close();
					}
					break;
				}
				catch (Exception ex)
				{
					if (retry < 4 && ex.Message.ToLower().Contains("locked"))
					{
						Thread.Sleep(150);
						continue;
					}
				}
			}
		}
		return dataTable;
	}

	public int method_1(string B61A4529)
	{
		int result = 0;
		lock (_dbLock)
		{
			for (int retry = 0; retry < 5; retry++)
			{
				try
				{
					using (SQLiteConnection sQLiteConnection = new SQLiteConnection(string_0))
					{
						sQLiteConnection.Open();
						using (SQLiteCommand cmdPragma = new SQLiteCommand("PRAGMA busy_timeout=5000;", sQLiteConnection))
						{
							cmdPragma.ExecuteNonQuery();
						}
						using (SQLiteCommand sQLiteCommand = new SQLiteCommand(B61A4529, sQLiteConnection))
						{
							result = sQLiteCommand.ExecuteNonQuery();
						}
						sQLiteConnection.Close();
					}
					break;
				}
				catch (Exception ex)
				{
					if (retry < 4 && ex.Message.ToLower().Contains("locked"))
					{
						Thread.Sleep(150);
						continue;
					}
				}
			}
		}
		return result;
	}

	public object method_2(string string_1)
	{
		object result = 0;
		lock (_dbLock)
		{
			for (int retry = 0; retry < 5; retry++)
			{
				try
				{
					using (SQLiteConnection sQLiteConnection = new SQLiteConnection(string_0))
					{
						sQLiteConnection.Open();
						using (SQLiteCommand cmdPragma = new SQLiteCommand("PRAGMA busy_timeout=5000;", sQLiteConnection))
						{
							cmdPragma.ExecuteNonQuery();
						}
						using (SQLiteCommand sQLiteCommand = new SQLiteCommand(string_1, sQLiteConnection))
						{
							object obj = sQLiteCommand.ExecuteScalar();
							if (obj != null && obj != DBNull.Value)
							{
								result = Convert.ToInt32(obj);
							}
						}
						sQLiteConnection.Close();
					}
					break;
				}
				catch (Exception ex)
				{
					if (retry < 4 && ex.Message.ToLower().Contains("locked"))
					{
						Thread.Sleep(150);
						continue;
					}
				}
			}
		}
		return result;
	}
}
