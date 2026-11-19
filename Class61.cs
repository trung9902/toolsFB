using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

internal class Class61
{
	internal string string_0;

	internal string D31DA009;

	internal string string_1;

	internal string string_2;

	internal int int_0;

	internal string string_3;

	internal string string_4;

	internal RequestXNet D00A7D18;

	internal bool bool_0 = false;

	internal string string_5 = "";

	internal string D8A2E7BC = "";

	internal string string_6 = "";

	internal int int_1 = 0;

	public Class61(string A5339998, string string_7, string BC1DE523, string string_8, int int_2, string string_9)
	{
		if (Regex.Match(string_7, "i_user=\\d+").Success)
		{
			string_7 = string_7.Replace(Regex.Match(string_7, "i_user=\\d+").Value, "");
		}
		string_0 = A5339998;
		D31DA009 = string_7;
		string_1 = BC1DE523;
		string_2 = string_8;
		int_0 = int_2;
		string_3 = string_9;
		D00A7D18 = new RequestXNet(string_7, BC1DE523, string_8, int_2);
	}

	public bool method_5(string B8948EA5)
	{
		return B8948EA5.Contains("The user is enrolled in a blocking, logged-in checkpoint") || B8948EA5.Contains("The session has been invalidated") || B8948EA5.Contains("Sessions for the user are not allowed") || B8948EA5.Contains("Malformed access token") || B8948EA5.Contains("Error loading application") || B8948EA5.Contains("This Page access token belongs to a Page that is not accessible") || B8948EA5.Contains("Invalid OAuth access token - Cannot parse access token");
	}

	public bool method_7(string E9381732)
	{
		return E9381732.Contains("temporarily restricted") || E9381732.Contains("The action attempted has been deemed abusive or is otherwise disallowed") || E9381732.Contains("sentry_block_data");
	}
}
