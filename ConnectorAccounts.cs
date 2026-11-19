using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

public class ConnectorAccounts
{
	internal static ConnectorAccounts connectorAccounts_0;
	private static readonly object _dbLock = new object();

	internal static string smethod_GetDbPath()
	{
		string text = Base.DE249839 + "\\database\\db_lushcare.sqlite";
		if (!System.IO.File.Exists(text) && System.IO.File.Exists(Base.DE249839 + "\\database\\db_maxcare.sqlite"))
		{
			return Base.DE249839 + "\\database\\db_maxcare.sqlite";
		}
		return text;
	}

	internal string string_0 = "Data Source=" + smethod_GetDbPath() + ";Version=3;Journal Mode=WAL;BusyTimeout=10000;Pooling=True;";

	internal SQLiteConnection sqliteConnection_0 = null;

	public static ConnectorAccounts ConnectorAccounts_0
	{
		get
		{
			if (connectorAccounts_0 == null)
			{
				connectorAccounts_0 = new ConnectorAccounts();
			}
			return connectorAccounts_0;
		}
		private set
		{
			connectorAccounts_0 = value;
		}
	}

	private ConnectorAccounts()
	{
	}

	private void B3BBFE39()
	{
		try
		{
			string text = "Data Source=" + smethod_GetDbPath() + ";Version=3;Journal Mode=WAL;BusyTimeout=10000;Pooling=True;";
			if (text != string_0)
			{
				string_0 = text;
				if (sqliteConnection_0 != null && sqliteConnection_0.State == ConnectionState.Open)
				{
					sqliteConnection_0.Close();
				}
				sqliteConnection_0 = new SQLiteConnection(string_0);
				sqliteConnection_0.Open();
				using (SQLiteCommand pragmaCmd = new SQLiteCommand("PRAGMA journal_mode=WAL; PRAGMA busy_timeout=10000; PRAGMA synchronous=NORMAL;", sqliteConnection_0))
				{
					pragmaCmd.ExecuteNonQuery();
				}
			}
			else
			{
				if (sqliteConnection_0 == null)
				{
					sqliteConnection_0 = new SQLiteConnection(string_0);
				}
				if (sqliteConnection_0.State == ConnectionState.Closed)
				{
					sqliteConnection_0.Open();
					using (SQLiteCommand pragmaCmd = new SQLiteCommand("PRAGMA journal_mode=WAL; PRAGMA busy_timeout=10000; PRAGMA synchronous=NORMAL;", sqliteConnection_0))
					{
						pragmaCmd.ExecuteNonQuery();
					}
				}
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_58(exception_, "CheckConnectServer");
		}
	}

	public DataTable method_0(string C8B5B227)
	{
		DataTable dataTable = new DataTable();
		lock (_dbLock)
		{
			try
			{
				B3BBFE39();
				using (SQLiteCommand cmd = new SQLiteCommand(C8B5B227, sqliteConnection_0))
				using (SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd))
				{
					sQLiteDataAdapter.Fill(dataTable);
				}
			}
			catch (Exception exception_)
			{
				Commom.smethod_57(null, exception_, "ExecuteQuery");
			}
		}
		return dataTable;
	}

	public DataTable F9019D0A(List<string> list_0)
	{
		DataTable dataTable = new DataTable();
		lock (_dbLock)
		{
			try
			{
				B3BBFE39();
				for (int i = 0; i < list_0.Count; i++)
				{
					string commandText = list_0[i];
					using (SQLiteCommand cmd = new SQLiteCommand(commandText, sqliteConnection_0))
					using (SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd))
					{
						sQLiteDataAdapter.Fill(dataTable);
					}
				}
			}
			catch (Exception exception_)
			{
				Commom.smethod_57(null, exception_, "ExecuteQuery");
			}
		}
		return dataTable;
	}

	public int method_1(List<string> list_0)
	{
		int result = 0;
		lock (_dbLock)
		{
			try
			{
				B3BBFE39();
				using (SQLiteTransaction transaction = sqliteConnection_0.BeginTransaction())
				{
					for (int i = 0; i < list_0.Count; i++)
					{
						string commandText = list_0[i];
						if (string.IsNullOrWhiteSpace(commandText)) continue;
						using (SQLiteCommand sQLiteCommand = new SQLiteCommand(commandText, sqliteConnection_0, transaction))
						{
							result += sQLiteCommand.ExecuteNonQuery();
						}
					}
					transaction.Commit();
				}
			}
			catch (Exception exception_)
			{
				Commom.smethod_57(null, exception_, "ExecuteNonQuery (batch)");
			}
		}
		return result;
	}

	public int method_2(string string_1)
	{
		int result = 0;
		lock (_dbLock)
		{
			try
			{
				B3BBFE39();
				using (SQLiteCommand sQLiteCommand = new SQLiteCommand(string_1, sqliteConnection_0))
				{
					result = sQLiteCommand.ExecuteNonQuery();
				}
			}
			catch (Exception exception_)
			{
				Commom.smethod_57(null, exception_, "ExecuteNonQuery: " + string_1);
			}
		}
		return result;
	}

	public int method_3(string DB36B618)
	{
		int result = 0;
		lock (_dbLock)
		{
			try
			{
				B3BBFE39();
				using (SQLiteCommand sQLiteCommand = new SQLiteCommand(DB36B618, sqliteConnection_0))
				{
					object num = sQLiteCommand.ExecuteScalar();
					if (num != null && num != DBNull.Value)
					{
						result = Convert.ToInt32(num);
					}
				}
			}
			catch (Exception exception_)
			{
				Commom.smethod_57(null, exception_, "ExecuteScalar: " + DB36B618);
			}
		}
		return result;
	}
}
