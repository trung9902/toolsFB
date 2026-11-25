using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;

public class GClass3
{
	[CompilerGenerated]
	private sealed class CE3A9331
	{
		internal GClass3 gclass3_0;

		internal int F810FD9C;

		internal void A29E608C()
		{
			try
			{
				while (Environment.TickCount - gclass3_0.Int32_0 < F810FD9C * 1000 && gclass3_0.Thread_0.IsAlive)
				{
					Thread.Sleep(1000);
				}
				gclass3_0.Thread_0.Abort();
				while (gclass3_0.Thread_0.IsAlive)
				{
					Thread.Sleep(1000);
				}
			}
			catch (Exception)
			{
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	internal Thread D48EEC8E;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int int_0;

	private Thread Thread_0
	{
		[CompilerGenerated]
		get
		{
			return D48EEC8E;
		}
		[CompilerGenerated]
		set
		{
			D48EEC8E = value;
		}
	}

	private int Int32_0
	{
		[CompilerGenerated]
		get
		{
			return int_0;
		}
		[CompilerGenerated]
		set
		{
			int_0 = value;
		}
	}

	public GClass3(Thread thread_0, int int_1 = 0)
	{
		GClass3 gclass3_0 = this;
		Thread_0 = thread_0;
		Int32_0 = Environment.TickCount;
		if (int_1 <= 0)
		{
			return;
		}
		new Thread((ThreadStart)delegate
		{
			try
			{
				while (Environment.TickCount - gclass3_0.Int32_0 < int_1 * 1000 && gclass3_0.Thread_0.IsAlive)
				{
					Thread.Sleep(1000);
				}
				gclass3_0.Thread_0.Abort();
				while (gclass3_0.Thread_0.IsAlive)
				{
					Thread.Sleep(1000);
				}
			}
			catch (Exception)
			{
			}
		}).Start();
	}

	public string method_0()
	{
		return Commom.smethod_25((Environment.TickCount - Int32_0) / 1000);
	}
}
