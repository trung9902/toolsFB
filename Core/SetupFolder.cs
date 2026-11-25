using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

internal class SetupFolder
{
	public static string GetUseragentIphone()
	{
		return ModernUserAgentHub.GetRandomIphone();
	}

	public static string GetModernDesktopUserAgent()
	{
		return ModernUserAgentHub.GetRandomDesktopChrome();
	}

	public static List<string> GetAllModernIphoneUserAgents()
	{
		return ModernUserAgentHub.GetAllModernIphoneUserAgents();
	}

	public static List<string> smethod_2()
	{
		return new List<string>
		{
			"0|Random", "1|Ha Noi", "2|Phu Tho", "3|Ho Chi Minh", "4|Dak Lak", "5|Hai Duong", "6|Binh Dinh", "7|Nghe An", "8|Nam Dinh", "10|Thai Binh",
			"11|Ha Tinh"
		};
	}

	public static List<string> smethod_3()
	{
		return new List<string>
		{
			"so_SO|Af-Soomaali", "af_ZA|Afrikaans", "az_AZ|Azərbaycan dili", "id_ID|Bahasa Indonesia", "ms_MY|Bahasa Melayu", "jv_ID|Basa Jawa", "cx_PH|Bisaya", "bs_BA|Bosanski", "br_FR|Brezhoneg", "ca_ES|Català",
			"co_FR|Corsu", "cy_GB|Cymraeg", "da_DK|Dansk", "de_DE|Deutsch", "et_EE|Eesti", "en_GB|English (UK)", "en_US|English (US)", "en_UD|English (uʍop əpısdՈ)", "es_LA|Español", "es_ES|Español (España)",
			"eo_EO|Esperanto", "eu_ES|Euskara", "tl_PH|Filipino", "fr_CA|Français (Canada)", "fr_FR|Français (France)", "fy_NL|Frysk", "ff_NG|Fula", "fo_FO|Føroyskt", "ga_IE|Gaeilge", "gl_ES|Galego",
			"gn_PY|Guarani", "ha_NG|Hausa", "hr_HR|Hrvatski", "rw_RW|Ikinyarwanda", "it_IT|Italiano", "sw_KE|Kiswahili", "ht_HT|Kreyòl Ayisyen", "ku_TR|Kurdî (Kurmancî)", "lv_LV|Latviešu", "lt_LT|Lietuvių",
			"hu_HU|Magyar", "mg_MG|Malagasy", "mt_MT|Malti", "nl_NL|Nederlands", "nl_BE|Nederlands (België)", "nb_NO|Norsk (bokmål)", "nn_NO|Norsk (nynorsk)", "uz_UZ|O'zbek", "pl_PL|Polski", "pt_BR|Português (Brasil)",
			"pt_PT|Português (Portugal)", "ro_RO|Română", "sc_IT|Sardu", "sn_ZW|Shona", "sq_AL|Shqip", "sk_SK|Slovenčina", "sl_SI|Slovenščina", "fi_FI|Suomi", "sv_SE|Svenska", "vi_VN|Tiếng Việt",
			"tr_TR|Türkçe", "zz_TR|Zaza", "is_IS|Íslenska", "cs_CZ|Čeština", "sz_PL|ślōnskŏ gŏdka", "el_GR|Ελληνικά", "be_BY|Беларуская", "bg_BG|Български", "mk_MK|Македонски", "mn_MN|Монгол",
			"ru_RU|Русский", "sr_RS|Српски", "tt_RU|Татарча", "tg_TJ|Тоҷикӣ", "uk_UA|Українська", "ky_KG|кыргызча", "kk_KZ|Қазақша", "hy_AM|Հայերեն", "he_IL|עברית", "ur_PK|اردو",
			"ar_AR|العربية", "fa_IR|فارسی", "ps_AF|پښتو", "cb_IQ|کوردیی ناوەندی", "sy_SY|ܣܘܪܝܝܐ", "ne_NP|न\u0947प\u093eल\u0940", "mr_IN|मर\u093eठ\u0940", "hi_IN|ह\u093fन\u094dद\u0940", "as_IN|অসম\u09c0য\u09bc\u09be", "bn_IN|ব\u09be\u0982ল\u09be",
			"pa_IN|ਪ\u0a70ਜ\u0a3eਬ\u0a40", "gu_IN|ગ\u0ac1જર\u0abeત\u0ac0", "or_IN|ଓଡ\u0b3c\u0b3fଆ", "ta_IN|தம\u0bbfழ\u0bcd", "te_IN|త\u0c46ల\u0c41గ\u0c41", "kn_IN|ಕನ\u0ccdನಡ", "ml_IN|മലയ\u0d3eള\u0d02", "si_LK|ස\u0dd2\u0d82හල", "th_TH|ภาษาไทย", "lo_LA|ພາສາລາວ",
			"my_MM|မ\u103cန\u103aမ\u102cဘ\u102cသ\u102c", "ka_GE|ქართული", "am_ET|አማርኛ", "km_KH|ភ\u17b6ស\u17b6ខ\u17d2ម\u17c2រ", "tz_MA|ⵜⴰⵎⴰⵣⵉⵖⵜ", "zh_TW|中文(台灣)", "zh_CN|中文(简体)", "zh_HK|中文(香港)", "ja_JP|日本語", "ja_KS|日本語(関西)",
			"ko_KR|한국어"
		};
	}

	public static List<string> smethod_4()
	{
		string text = "Nguyễn|Trần|Lê|Phạm|Hoàng|Phan|Vũ|Đặng|Bùi|Đỗ|Hồ|Ngô|Dương|Lý|Huỳnh|Võ";
		return text.Split('|').ToList();
	}

	public static List<string> B92F5E26()
	{
		return new List<string>
		{
			"Diệu", "Quỳnh", "Trâm", "Nguyệt", "Trân", "Quế", "Trúc", "Xuyến", "Thiên", "Ngọc",
			"Nghi", "Linh", "Thục", "Thu", "Thiên", "Hiếu", "Thái", "Dạ", "Quỳnh", "Thiên",
			"Ái", "Kim", "Vân", "Hồng", "Minh", "Diễm", "Chi", "Bạch", "Ngọc", "Mộc",
			"Ha", "Thương", "Dại", "Thu", "Uyển", "Yến", "Thục", "Hạnh", "Thanh", "Tú",
			"Song", "Cát", "Lâm", "Hương", "Dạ", "Anh", "Đoan", "Phượng", "Tịnh", "Hải",
			"Thiên", "Gia", "Thành", "Trung", "Thái", "Hải", "Thành", "Thông", "Phúc", "Tài",
			"Mạnh", "Chấn", "Bảo", "Khang", "Đăng", "Tuấn", "Thanh", "Hiền", "Thiện", "Thụ",
			"Minh", "Nhân", "Trọng", "Trung", "Khôi", "Hạo", "Phương", "Thanh", "Hữu", "Minh",
			"Đông", "Sơn", "Tùng", "Ái", "Thái", "Trường", "Thiện", "Thạch", "An", "Anh",
			"Thanh", "Chiến", "Toàn", "Minh", "Đình", "Kiến", "Nhân", "Khôi", "Quang", "Uy",
			"Hoài", "Huyền", "Thùy", "Trung", "Tú", "Vàng", "Hạ", "Lệ", "Tuyết", "Yên",
			"Ngọc", "Bảo", "Khải", "Sơn", "Nguyệt", "Bảo", "Ly", "Minh", "Hương", "Lan",
			"Lien", "Linh", "Mai", "Quỳnh", "Hiền", "Hạc", "Nhật", "Quỳnh", "Huyền", "Kỳ",
			"Vinh", "Thụy", "Van", "Hạnh", "Kiều", "Từ", "Thien", "Hải", "Hướng", "Thuy",
			"Kim", "Minh", "Yen", "Truc", "Hồng", "Hạ", "Hồng", "Hương", "Khánh"
		};
	}

	public static List<string> smethod_5()
	{
		return new List<string>
		{
			"Anh", "Cát", "Châu", "Chi", "Di", "Diệp", "Dung", "Đan", "Đoan", "Giang",
			"Hà", "Hạnh", "Hòa", "Hương", "Khanh", "Khánh", "Khuê", "Khue", "Kiều", "Lan",
			"Lien", "Mien", "Mi", "Nga", "Ngọc", "Nguyệt", "Nhã", "Oanh", "Quyên", "San",
			"Tâm", "Thư", "Tường", "Tuyền", "Thảo", "Thi", "Trang", "Vũ", "Yên", "Yến",
			"Ân", "Bảo", "Công", "Dũng", "Dương", "Đăng", "Đạt", "Điền", "Đức", "Hùng",
			"Hưng", "Kiện", "Khoa", "Kiệt", "Liêm", "Minh", "Ngôn", "Nhân", "Nhật", "Nghĩa",
			"Nguyên", "Nhiên", "Phi", "Phong", "Phước", "Quân", "Quốc", "Sơn", "Tùng", "Thái",
			"Thế", "Thắng", "Triết", "Trung", "Văn", "Vĩ", "Vinh", "An", "Băng", "Bằng",
			"Bích", "Bình", "Ca", "Chau", "Chung", "Cuc", "Dạ", "Dao", "Diệu", "Du",
			"Duyen", "Dan", "Dang"
		};
	}

	public static List<string> smethod_6()
	{
		return new List<string>
		{
			"Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor",
			"Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson",
			"Clark", "Rodriguez", "Lewis", "Lee", "Walker", "Hall", "Allen", "Young", "Hernandez", "King",
			"Wright", "Lopez", "Hill", "Scott", "Green", "Adams", "Baker", "Gonzalez", "Nelson", "Carter",
			"Mitchell", "Perez", "Roberts", "Turner", "Phillips", "Campbell", "Parker", "Evans", "Edwards", "Collins",
			"Stewart", "Sanchez", "Morris", "Rogers", "Reed", "Cook", "Morgan", "Bell", "Murphy", "Bailey",
			"Rivera", "Cooper", "Richardson", "Cox", "Howard", "Ward", "Torres", "Peterson", "Gray", "Ramirez",
			"James", "Watson", "Brooks", "Kelly", "Sanders", "Price", "Bennett", "Wood", "Barnes", "Ross",
			"Henderson", "Coleman", "Jenkins", "Perry", "Powell", "Long", "Patterson", "Hughes", "Flores", "Washington",
			"Butler", "Simmons", "Foster", "Gonzales", "Bryant", "Alexander"
		};
	}

	public static List<string> smethod_7()
	{
		return new List<string>
		{
			"James", "John", "Robert", "Michael", "William", "David", "Richard", "Joseph", "Thomas", "Charles",
			"Christopher", "Daniel", "Matthew", "Anthony", "Donald", "Mark", "Paul", "Steven", "Andrew", "Kenneth",
			"Joshua", "George", "Kevin", "Brian", "Edward", "Ronald", "Timothy", "Jason", "Jeffrey", "Ryan",
			"Jacob", "Gary", "Nicholas", "Eric", "Stephen", "Jonathan", "Larry", "Justin", "Scott", "Brandon",
			"Frank", "Benjamin", "Gregory", "Samuel", "Raymond", "Patrick", "Alexander", "Jack", "Dennis", "Jerry",
			"Tyler", "Aaron", "Jose", "Henry", "Douglas", "Adam", "Peter", "Nathan", "Zachary", "Walter",
			"Kyle", "Harold", "Carl", "Jeremy", "Keith", "Roger", "Gerald", "Ethan", "Arthur", "Terry",
			"Christian", "Sean", "Lawrence", "Austin", "Joe", "Noah", "Jesse", "Albert", "Bryan", "Billy",
			"Bruce", "Willie", "Jordan", "Dylan", "Alan", "Ralph", "Gabriel", "Roy", "Juan", "Wayne",
			"Eugene", "Logan", "Randy", "Louis", "Russell", "Vincent", "Philip", "Bobby", "Johnny", "Bradley"
		};
	}

	public static void CreateBasicFolder()
	{
		Commom.CreateFolder("backup");
		Commom.CreateFolder("settings");
		Commom.CreateFolder("profiles");
		Commom.CreateFolder("profilestemp");
		Commom.CreateFolder("update");
		Commom.CreateFolder("photos");
		Commom.CreateFolder("Image282");
		Commom.CreateFolder("posts");
        //Commom.CreateFolder("settings\\setting");
        Commom.CreateFolder("golike");
		Commom.CreateFolder("backupgroup");
		Commom.CreateFolder("output");
		Commom.CreateFolder("gologin");
		Commom.CreateFolder("database");
		Commom.CreateFolder("interact");
		try
		{
			File.AppendAllText("startup_log.txt", "Initializing SQLite tables if needed...\r\n");
			Class60.E211632E(@"CREATE TABLE IF NOT EXISTS accounts (
				id INTEGER PRIMARY KEY AUTOINCREMENT,
				uid TEXT,
				pass TEXT,
				token TEXT,
				cookie TEXT,
				cookie1 TEXT,
				email TEXT,
				name TEXT,
				friends TEXT,
				groups TEXT,
				birthday TEXT,
				gender TEXT,
				info TEXT,
				fa2 TEXT,
				idfile INTEGER,
				passmail TEXT,
				useragent TEXT,
				proxy TEXT,
				dateCreateAcc TEXT,
				dateImport TEXT,
				mailrecovery TEXT,
				passmailrecovery TEXT,
				active INTEGER DEFAULT 1,
				ghiChu TEXT,
				location TEXT,
				backup TEXT,
				avatar TEXT,
				profile TEXT,
				follow TEXT,
				interactEnd TEXT,
				pass_old TEXT,
				status TEXT,
				hometown TEXT,
				currentCity TEXT,
				pages TEXT,
				dating TEXT,
				ads TEXT,
				bm TEXT,
				pagePro5 TEXT,
				wallPosts TEXT,
				fbBlock TEXT,
				job TEXT,
				status282 TEXT,
				email2 TEXT,
				email_old TEXT,
				passmail_old TEXT,
				kichban TEXT,
				infoDevice TEXT,
				created_at TEXT,
				updated_at TEXT,
				cookieHotmail TEXT,
				dateDelete TEXT
			);
			CREATE TABLE IF NOT EXISTS files (
				id INTEGER PRIMARY KEY AUTOINCREMENT,
				name TEXT,
				createddate TEXT,
				active INTEGER DEFAULT 1,
				STT INTEGER
			);");

			ConnectorKichBan.ConnectorKichBan_0.method_2(@"CREATE TABLE IF NOT EXISTS Kich_Ban (
				Id_KichBan INTEGER PRIMARY KEY AUTOINCREMENT,
				TenKichBan TEXT,
				CauHinh TEXT,
				STT INTEGER
			);
			CREATE TABLE IF NOT EXISTS Hanh_Dong (
				Id_HanhDong INTEGER PRIMARY KEY AUTOINCREMENT,
				Id_KichBan INTEGER,
				Id_TuongTac INTEGER,
				TenHanhDong TEXT,
				CauHinh TEXT,
				STT INTEGER
			);
			CREATE TABLE IF NOT EXISTS Tuong_Tac (
				Id_TuongTac INTEGER PRIMARY KEY AUTOINCREMENT,
				TenTuongTac TEXT,
				MoTa TEXT
			);
			INSERT OR IGNORE INTO Tuong_Tac (Id_TuongTac, TenTuongTac, MoTa) VALUES
			(1, 'HDScriptGemLogin', 'Script GemLogin'),
			(2, 'HDUnlockProfile', 'Unlock profile'),
			(3, 'HDDangBai', 'Đăng bài'),
			(4, 'HDDocThongBao', 'Đọc thông báo'),
			(5, 'HDCapNhatThongTin', 'Cập nhật thông tin'),
			(6, 'HDBuffLikeComment', 'Tương tác bài viết chỉ định'),
			(7, 'HDHuyLoiMoiKetBan', 'Hủy lời mời kết bạn'),
			(8, 'HDTuongTacReelChiDinh', 'Tương tác reel chỉ định'),
			(9, 'HDDoiMatKhau', 'Đổi mật khẩu'),
			(10, 'HDTimKiemGoogle', 'Tìm kiếm Google'),
			(11, 'HDBaiVietNewsfeed', 'Bài viết Newsfeed'),
			(12, 'HDXemStory', 'Xem Story'),
			(13, 'HDXemWatch', 'Xem Watch'),
			(14, 'HDDangReel', 'Đăng Reel'),
			(15, 'HDShareBai', 'Share bài');");
			File.AppendAllText("startup_log.txt", "SQLite tables initialized successfully.\r\n");
			NoiDungTemplateManager.EnsureDatabaseAndDefaults();
		}
		catch (Exception exDb)
		{
			File.AppendAllText("startup_log.txt", "SQLite table init exception: " + exDb.Message + "\r\n");
		}
		if (!File.Exists(GClass9.string_0))
		{
			File.WriteAllText(GClass9.string_0, "[\r\n  {\r\n    \"id\": \"1740104501\",\r\n    \"name\": \"Comment\",\r\n    \"type\": \"Gemini\",\r\n    \"apikey\": \"\",\r\n    \"promt\": \"Tôi có bài viết nội dung như sau, hãy tạo cho tôi 1 comment vào bài viết. Nội dung tho\u0309a ma\u0303n ca\u0301c tiêu chi\u0301 sau:\\n+ Sô\u0301 lươ\u0323ng ky\u0301 tư\u0323 < 70\\n+ Nội dung comment bám sát vào nội dung bài viết\\n+ Sử dụng văn phong mạng xã hội\\n+ Nội dung comment phải nghiêm túc, mang tính gợi mở, tính tương tác và viết bằng tiếng việt\\nNội dung bài viết như sau:\\n{content}\"\r\n  },\r\n  {\r\n    \"id\": \"1740104670\",\r\n    \"name\": \"Nhă\u0301n tin\",\r\n    \"type\": \"Gemini\",\r\n    \"apikey\": \"\",\r\n    \"promt\": \"Tôi có nội dung tin nhă\u0301n như sau, hãy tạo cho tôi 1 tin nhă\u0301n pha\u0309n hô\u0300i. Nội dung tho\u0309a ma\u0303n ca\u0301c tiêu chi\u0301 sau:\\n+ Sô\u0301 lươ\u0323ng ky\u0301 tư\u0323 < 70\\n+ Nội dung bám sát vào tin nhă\u0301n đê\u0301n\\n+ Sử dụng văn phong mạng xã hội\\n+ Nội dung phải ha\u0300i hươ\u0301c, mang tính gợi mở, tính tương tác và viết bằng tiếng việt\\nNội dung tin nhă\u0301n đê\u0301n như sau:\\n{content}\"\r\n  },\r\n  {\r\n    \"id\": \"1740104789\",\r\n    \"name\": \"Reply comment\",\r\n    \"type\": \"Gemini\",\r\n    \"apikey\": \"\",\r\n    \"promt\": \"Tôi có nội dung comment như sau, hãy tạo cho tôi 1 comment đê\u0309 pha\u0309n hô\u0300i la\u0323i. Nội dung tho\u0309a ma\u0303n ca\u0301c tiêu chi\u0301 sau:\\n+ Sô\u0301 lươ\u0323ng ky\u0301 tư\u0323 < 70\\n+ Nội dung bám sát vào nội dung comment\\n+ Sử dụng văn phong mạng xã hội\\n+ Nội dung phải nghiêm túc, mang tính gợi mở, tính tương tác và viết bằng tiếng việt\\nNội dung comment như sau:\\n{content}\"\r\n  },\r\n  {\r\n    \"id\": \"1740125667\",\r\n    \"name\": \"Đăng ba\u0300i tha\u0309 thi\u0301nh\",\r\n    \"type\": \"Gemini\",\r\n    \"apikey\": \"\",\r\n    \"promt\": \"Ta\u0323o nô\u0323i dung đê\u0309 tôi đăng ba\u0300i lên facebook tho\u0309a ma\u0303n ca\u0301c tiêu chi\u0301 sau:\\n+ Như\u0303ng câu no\u0301i tha\u0309 thi\u0301nh\\n+ Sô\u0301 lươ\u0323ng ky\u0301 tư\u0323 < 70\\n+ Sử dụng văn phong mạng xã hội\\n+ Nội dung phải ha\u0300i hươ\u0301c, mang tính gợi mở, tính tương tác va\u0300 viê\u0301t bă\u0300ng tiê\u0301ng viê\u0323t\\n+ Chi\u0309 ta\u0323o 1 nô\u0323i dung, không da\u0300i do\u0300ng\"\r\n  }\r\n]");
		}
		// Extensions downloads disabled to prevent hanging/errors
		//if (!Directory.Exists("extension\\omocaptcha") || !File.Exists("extension\\omocaptcha\\250224.txt"))
		//{
		//	Commom.DeleteFolder("extension\\omocaptcha");
		//	Commom.smethod_14(Base.string_2 + "/download/omocaptchatiktok.zip");
		//}
		//if (!File.Exists("extension\\proxy2.crx"))
		//{
		//	Commom.smethod_14(Base.string_2 + "/download/proxy2.zip");
		//}
		if (!C5034B95.smethod_4())
		{
			//if (!File.Exists(Base.DE249839 + "\\database\\db_maxcare.sqlite"))
			//{
			//	Commom.smethod_85("CreateDBMaxCare('" + (Base.DE249839 + "\\database\\db_maxcare.sqlite").Replace("\\", "\\\\") + "')");
			//}
			List<Class2<string, string, string>> list = new Class2<string, string, string>[36]
			{
				new Class2<string, string, string>("fa2", "TEXT", ""),
				new Class2<string, string, string>("phone", "TEXT", ""),
				new Class2<string, string, string>("useragent", "TEXT", ""),
				new Class2<string, string, string>("proxy", "TEXT", ""),
				new Class2<string, string, string>("dateCreateAcc", "TEXT", ""),
				new Class2<string, string, string>("avatar", "TEXT", ""),
				new Class2<string, string, string>("profile", "TEXT", ""),
				new Class2<string, string, string>("ghiChu", "TEXT", ""),
				new Class2<string, string, string>("follow", "TEXT", ""),
				new Class2<string, string, string>("interactEnd", "TEXT", ""),
				new Class2<string, string, string>("dateImport", "TEXT", ""),
				new Class2<string, string, string>("pass_old", "TEXT", ""),
				new Class2<string, string, string>("status", "TEXT", ""),
				new Class2<string, string, string>("location", "TEXT", ""),
				new Class2<string, string, string>("hometown", "TEXT", ""),
				new Class2<string, string, string>("currentCity", "TEXT", ""),
				new Class2<string, string, string>("pages", "TEXT", ""),
				new Class2<string, string, string>("dating", "TEXT", ""),
				new Class2<string, string, string>("ads", "TEXT", ""),
				new Class2<string, string, string>("bm", "TEXT", ""),
				new Class2<string, string, string>("pagePro5", "TEXT", ""),
				new Class2<string, string, string>("wallPosts", "TEXT", ""),
				new Class2<string, string, string>("fbBlock", "TEXT", ""),
				new Class2<string, string, string>("job", "TEXT", ""),
				new Class2<string, string, string>("status282", "TEXT", ""),
				new Class2<string, string, string>("email2", "TEXT", ""),
				new Class2<string, string, string>("email_old", "TEXT", ""),
				new Class2<string, string, string>("passmail_old", "TEXT", ""),
				new Class2<string, string, string>("kichban", "TEXT", ""),
				new Class2<string, string, string>("infoDevice", "TEXT", ""),
				new Class2<string, string, string>("created_at", "TEXT", ""),
				new Class2<string, string, string>("updated_at", "TEXT", ""),
				new Class2<string, string, string>("passmailrecovery", "TEXT", ""),
				new Class2<string, string, string>("cookieHotmail", "TEXT", ""),
				new Class2<string, string, string>("active", "INT", "1"),
				new Class2<string, string, string>("dateDelete", "TEXT", "")
			}.ToList();
			foreach (Class2<string, string, string> item in list)
			{
				if (!CommonSQL.E106EC0B("accounts", item.Prop_0))
				{
					CommonSQL.smethod_17("accounts", item.Prop_0, (item.Prop_1 == "TEXT") ? 1 : 0);
					if (item.EA133E97 != "")
					{
						Class60.E211632E("UPDATE accounts SET " + item.Prop_0 + "='" + item.EA133E97 + "'");
					}
				}
			}
			if (!CommonSQL.E106EC0B("accounts", "cookie1"))
			{
				CommonSQL.smethod_17("accounts", "cookie1");
				Class60.E211632E("UPDATE accounts SET cookie1=cookie");
			}
			if (!CommonSQL.E106EC0B("files", "STT"))
			{
				CommonSQL.smethod_17("files", "STT", 0);
				Class60.E211632E("UPDATE files SET STT=id");
			}
			Class60.E211632E("UPDATE files SET STT = id WHERE stt IS NULL");
			List<Class2<string, string, string>> list2 = new Class2<string, string, string>[1]
			{
				new Class2<string, string, string>("active", "INT", "1")
			}.ToList();
			foreach (Class2<string, string, string> item2 in list2)
			{
				if (!CommonSQL.E106EC0B("files", item2.Prop_0))
				{
					CommonSQL.smethod_17("files", item2.Prop_0, (item2.Prop_1 == "TEXT") ? 1 : 0);
					if (item2.EA133E97 != "")
					{
						Class60.E211632E("UPDATE files SET " + item2.Prop_0 + "='" + item2.EA133E97 + "'");
					}
				}
			}
			//if (!File.Exists(Commom.smethod_95() + "\\interact\\interact.sqlite"))
			//{
			//	Commom.smethod_85("CreateDBInteract('" + (Commom.smethod_95() + "\\interact\\interact.sqlite").Replace("\\", "\\\\") + "')");
			//}
			try
			{
				Class154.D6132534("Kich_Ban", "CauHinh", 1);
				if (!Class154.smethod_0("Kich_Ban", "STT"))
				{
					Class154.D6132534("Kich_Ban", "STT", 0);
					ConnectorKichBan.ConnectorKichBan_0.method_2("UPDATE Kich_Ban SET STT=Id_KichBan");
				}
				Class87.bool_0 = C5034B95.smethod_0("configGeneral").method_3("ckbLuuTrangThai");
				Class87.smethod_2();
			}
			catch (Exception exKichBan)
			{
				File.AppendAllText("startup_log.txt", "KichBan warning: " + exKichBan.Message + "\r\n");
			}
		}
		File.AppendAllText("startup_log.txt", "SetupFolder.CreateBasicFolder completed.\r\n");
		try
		{
			string text3 = "lushcare";
			if (Base.bool_8)
			{
				text3 = "oakfacebook";
			}
			if (!File.Exists("update.ini"))
			{
				File.AppendAllText("update.ini", "[" + text3 + "]\r\nVersion=22.11.01\r\nContent=");
				return;
			}
			string text4 = File.ReadAllText("update.ini");
			string text5 = text4.Split('\r', '\n')[0];
			if (text5 != "[" + text3 + "]")
			{
				text4 = text4.Replace(text5, "[" + text3 + "]");
				File.WriteAllText("update.ini", text4);
			}
		}
		catch
		{
		}
	}
}
