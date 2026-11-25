using System;
using System.Data;
using System.Data.SQLite;

public class ConnectorKichBan
{
	internal static ConnectorKichBan connectorKichBan_0;
	private static readonly object _dbLock = new object();

	internal string string_0 = "Data Source=interact\\interact.sqlite;Version=3;Journal Mode=WAL;BusyTimeout=10000;Pooling=True;";

	internal SQLiteConnection ABACF9B6 = null;

	public static ConnectorKichBan ConnectorKichBan_0
	{
		get
		{
			if (connectorKichBan_0 == null)
			{
				connectorKichBan_0 = new ConnectorKichBan();
			}
			return connectorKichBan_0;
		}
		private set
		{
			connectorKichBan_0 = value;
		}
	}

	private ConnectorKichBan()
	{
	}

	private void method_0()
	{
		try
		{
			if (ABACF9B6 == null)
			{
				ABACF9B6 = new SQLiteConnection(string_0);
			}
			if (ABACF9B6.State == ConnectionState.Closed)
			{
				ABACF9B6.Open();
				using (SQLiteCommand pragmaCmd = new SQLiteCommand("PRAGMA journal_mode=WAL; PRAGMA busy_timeout=10000; PRAGMA synchronous=NORMAL;", ABACF9B6))
				{
					pragmaCmd.ExecuteNonQuery();
				}
			}
		}
		catch (Exception exception_)
		{
			Commom.smethod_58(exception_, "CheckConnectServer");
		}
	}

	public DataTable method_1(string string_1)
	{
		DataTable dataTable = new DataTable();
		lock (_dbLock)
		{
			try
			{
				method_0();
				using (SQLiteCommand cmd = new SQLiteCommand(string_1, ABACF9B6))
				using (SQLiteDataAdapter sQLiteDataAdapter = new SQLiteDataAdapter(cmd))
				{
					sQLiteDataAdapter.Fill(dataTable);
				}
			}
			catch
			{
			}
		}
		return dataTable;
	}

	public int method_2(string string_1)
	{
		int result = 0;
		lock (_dbLock)
		{
			try
			{
				method_0();
				using (SQLiteCommand sQLiteCommand = new SQLiteCommand(string_1, ABACF9B6))
				{
					result = sQLiteCommand.ExecuteNonQuery();
				}
			}
			catch (Exception)
			{
			}
		}
		return result;
	}

	public int method_3(string B5B84B02)
	{
		int result = -1;
		lock (_dbLock)
		{
			try
			{
				method_0();
				using (SQLiteCommand sQLiteCommand = new SQLiteCommand(B5B84B02, ABACF9B6))
				{
					object num = sQLiteCommand.ExecuteScalar();
					if (num != null && num != DBNull.Value)
					{
						result = Convert.ToInt32(num);
					}
				}
			}
			catch
			{
			}
		}
		return result;
	}
}
