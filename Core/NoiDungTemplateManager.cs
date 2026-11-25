using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

public class ContentTemplate
{
	public int Id { get; set; }
	public string Title { get; set; } = "";
	public string Category { get; set; } = "Chung";
	public string Content { get; set; } = "";
	public string CreatedAt { get; set; } = "";
	public int SortOrder { get; set; } = 0;
}

public static class NoiDungTemplateManager
{
	private static readonly object _lock = new object();

	private static string GetJsonPath()
	{
		string dir = Path.Combine(Commom.smethod_95(), "settings");
		if (!Directory.Exists(dir))
		{
			try
			{
				Directory.CreateDirectory(dir);
			}
			catch { }
		}
		return Path.Combine(dir, "content_templates.json");
	}

	public static void EnsureDatabaseAndDefaults()
	{
		lock (_lock)
		{
			try
			{
				ConnectorKichBan.ConnectorKichBan_0.method_2(@"CREATE TABLE IF NOT EXISTS NoiDungMau (
					Id_NoiDung INTEGER PRIMARY KEY AUTOINCREMENT,
					TieuDe TEXT,
					ChuDe TEXT,
					NoiDung TEXT,
					NgayTao TEXT,
					STT INTEGER
				);");

				DataTable dt = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT COUNT(*) FROM NoiDungMau;");
				int count = 0;
				if (dt != null && dt.Rows.Count > 0)
				{
					int.TryParse(dt.Rows[0][0].ToString(), out count);
				}

				if (count == 0)
				{
					// If json exists, load from json
					string jsonPath = GetJsonPath();
					List<ContentTemplate> templates = null;
					if (File.Exists(jsonPath))
					{
						try
						{
							string json = File.ReadAllText(jsonPath);
							templates = JsonConvert.DeserializeObject<List<ContentTemplate>>(json);
						}
						catch { }
					}

					if (templates == null || templates.Count == 0)
					{
						templates = GetDefaultTemplates();
					}

					foreach (var item in templates)
					{
						InsertToDb(item);
					}
					SaveToJson(templates);
				}
			}
			catch (Exception ex)
			{
				Commom.smethod_49("EnsureDatabaseAndDefaults error: " + ex.Message);
			}
		}
	}

	public static List<ContentTemplate> GetDefaultTemplates()
	{
		return new List<ContentTemplate>
		{
			new ContentTemplate
			{
				Title = "Website VMAX - Giải pháp Website Chuyên nghiệp",
				Category = "Website & Doanh nghiệp",
				Content = "🚨 KHÁCH HÀNG TÌM TRÊN GOOGLE NHƯNG KHÔNG THẤY DOANH NGHIỆP BẠN?\r\n\r\nKhách hàng ngày nay thường tìm hiểu trên Google trước khi quyết định mua sản phẩm hoặc sử dụng dịch vụ.\r\n\r\n❌ Không có website – Khách khó tìm thấy thông tin doanh nghiệp.\r\n❌ Chỉ bán hàng qua Facebook – Khách phải nhắn tin mới biết đầy đủ sản phẩm, dịch vụ.\r\n❌ Thiếu một kênh giới thiệu chuyên nghiệp – Khó tạo niềm tin với khách hàng mới.\r\n\r\n💡 ĐÃ ĐẾN LÚC DOANH NGHIỆP CẦN MỘT WEBSITE CHUYÊN NGHIỆP!\r\n\r\nTại VMAX, chúng tôi thiết kế website phù hợp với từng ngành nghề:\r\n\r\n✅ Giao diện riêng, đẹp mắt, phù hợp thương hiệu.\r\n✅ Hiển thị tốt trên điện thoại, máy tính.\r\n✅ Giới thiệu sản phẩm, dịch vụ rõ ràng, dễ tìm kiếm.\r\n✅ Tích hợp nút gọi điện, Zalo, form liên hệ.\r\n✅ Tối ưu SEO cơ bản, hỗ trợ Google tìm hiểu nội dung website.\r\n✅ Dễ dàng quản trị và cập nhật thông tin.\r\n\r\n🎯 Website không chỉ để giới thiệu doanh nghiệp, mà còn là nơi khách hàng tìm hiểu, tin tưởng và chủ động liên hệ với bạn.\r\n\r\n📩 Nhắn tin VMAX ngay hôm nay để được tư vấn và xem demo website phù hợp với ngành nghề của bạn!\r\n\r\n📞 Hotline/Zalo: 0825.99.33.55\r\n\r\n#ThietKeWebsite #ThietKeWebChuyenNghiep #WebsiteDoanhNghiep #VMAX",
				CreatedAt = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
				SortOrder = 1
			},
			new ContentTemplate
			{
				Title = "Bán hàng - Siêu khuyến mãi tri ân khách hàng",
				Category = "Bán hàng & Khuyến mãi",
				Content = "🔥 SIÊU BÃO KHUYẾN MÃI - TRI ÂN KHÁCH HÀNG THÂN THIẾT! 🔥\r\n\r\n💥 Duy nhất trong tuần này: Giảm ngay 30% cho tất cả đơn hàng!\r\n\r\n⭐ LỢI ÍCH KHI ĐẶT HÀNG NGAY HÔM NAY:\r\n✅ Cam kết sản phẩm chính hãng 100%, chất lượng đỉnh cao.\r\n✅ Bảo hành chu đáo, 1 đổi 1 nếu phát hiện lỗi.\r\n✅ Miễn phí giao hàng toàn quốc cho đơn từ 2 sản phẩm.\r\n✅ Nhận hàng kiểm tra ưng ý mới thanh toán.\r\n\r\n🎁 TẶNG KÈM: Quà tặng độc quyền trị giá 200k cho 50 khách hàng đầu tiên!\r\n\r\n👉 Số lượng có hạn - Ưu đãi kết thúc khi hết quà tặng!\r\n\r\n📩 Inbox ngay để được chuyên viên hỗ trợ tư vấn chi tiết!\r\n📞 Hotline tư vấn đặt hàng: 0825.99.33.55",
				CreatedAt = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
				SortOrder = 2
			},
			new ContentTemplate
			{
				Title = "Tuyển dụng đối tác kinh doanh & CTV toàn quốc",
				Category = "Tuyển dụng & Hợp tác",
				Content = "🚀 CƠ HỘI GIA TĂNG THU NHẬP - TUYỂN DỤNG CTV & ĐỐI TÁC TOÀN QUỐC 🚀\r\n\r\nBạn đang tìm kiếm một công việc tự do thời gian, gia tăng thu nhập thụ động mà KHÔNG cần vốn?\r\n\r\n💼 QUYỀN LỢI CỦA BẠN:\r\n✅ Chiết khấu hoa hồng hấp dẫn từ 20% - 40% trên từng đơn.\r\n✅ Không ôm hàng, không lo tồn kho, không cần đóng gói vận chuyển.\r\n✅ Được đào tạo bài bản từ A - Z quy trình bán hàng đa kênh.\r\n✅ Hỗ trợ hình ảnh, video, bài viết và tài liệu bán hàng chuyên nghiệp.\r\n\r\n📌 YÊU CẦU ĐƠN GIẢN:\r\n- Có điện thoại/máy tính kết nối Internet.\r\n- Chăm chỉ, nhiệt huyết, muốn tăng thêm thu nhập mỗi ngày.\r\n\r\n📩 Nhắn tin ngay cho chúng tôi để nhận thông tin và gia nhập đội ngũ ngay hôm nay!\r\n📞 Hotline/Zalo tuyển dụng: 0825.99.33.55",
				CreatedAt = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
				SortOrder = 3
			},
			new ContentTemplate
			{
				Title = "Chia sẻ kiến thức - 3 Sai lầm khi kinh doanh online",
				Category = "Chia sẻ kiến thức",
				Content = "💡 3 SAI LẦM KHIẾN KINH DOANH ONLINE MÃI KHÔNG RA ĐƠN!\r\n\r\nNhiều người nghĩ chỉ cần đăng bài là có khách, nhưng thực tế:\r\n\r\n❌ 1. Nội dung sơ sài, không có điểm nhấn và không tạo niềm tin.\r\n❌ 2. Không có kênh bán hàng uy tín ngoài trang cá nhân.\r\n❌ 3. Bỏ qua trải nghiệm của khách hàng khi tìm kiếm thông tin.\r\n\r\n🎯 BÍ QUYẾT ĐỂ TĂNG TỶ LỆ CHỐT ĐƠN:\r\n✅ Đầu tư hình ảnh, bài viết chỉn chu, bố cục rõ ràng.\r\n✅ Xây dựng kênh thương hiệu (Fanpage, Website, Zalo OA).\r\n✅ Tương tác và giải đáp thắc mắc của khách hàng thật nhanh chóng.\r\n\r\n👉 Follow chúng tôi để nhận thêm nhiều chia sẻ bổ ích về kinh doanh nhé!\r\n📞 Hotline: 0825.99.33.55",
				CreatedAt = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
				SortOrder = 4
			}
		};
	}

	public static List<ContentTemplate> GetAll()
	{
		EnsureDatabaseAndDefaults();
		List<ContentTemplate> list = new List<ContentTemplate>();
		lock (_lock)
		{
			try
			{
				DataTable dt = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT * FROM NoiDungMau ORDER BY STT ASC, Id_NoiDung DESC;");
				if (dt != null)
				{
					foreach (DataRow row in dt.Rows)
					{
						list.Add(new ContentTemplate
						{
							Id = Convert.ToInt32(row["Id_NoiDung"]),
							Title = row["TieuDe"]?.ToString() ?? "",
							Category = row["ChuDe"]?.ToString() ?? "Chung",
							Content = row["NoiDung"]?.ToString() ?? "",
							CreatedAt = row["NgayTao"]?.ToString() ?? "",
							SortOrder = row["STT"] != DBNull.Value ? Convert.ToInt32(row["STT"]) : 0
						});
					}
				}
			}
			catch (Exception ex)
			{
				Commom.smethod_49("GetAll templates db error: " + ex.Message);
			}

			if (list.Count == 0)
			{
				string jsonPath = GetJsonPath();
				if (File.Exists(jsonPath))
				{
					try
					{
						string json = File.ReadAllText(jsonPath);
						list = JsonConvert.DeserializeObject<List<ContentTemplate>>(json) ?? new List<ContentTemplate>();
					}
					catch { }
				}
			}
		}
		return list;
	}

	public static int Insert(ContentTemplate item)
	{
		lock (_lock)
		{
			EnsureDatabaseAndDefaults();
			if (string.IsNullOrEmpty(item.CreatedAt))
			{
				item.CreatedAt = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
			}
			int id = InsertToDb(item);
			item.Id = id;
			SyncToJson();
			return id;
		}
	}

	public static bool Update(ContentTemplate item)
	{
		lock (_lock)
		{
			EnsureDatabaseAndDefaults();
			try
			{
				string sql = string.Format(
					"UPDATE NoiDungMau SET TieuDe='{0}', ChuDe='{1}', NoiDung='{2}', STT={3} WHERE Id_NoiDung={4};",
					item.Title.Replace("'", "''"),
					item.Category.Replace("'", "''"),
					item.Content.Replace("'", "''"),
					item.SortOrder,
					item.Id
				);
				int rows = ConnectorKichBan.ConnectorKichBan_0.method_2(sql);
				SyncToJson();
				return rows > 0;
			}
			catch (Exception ex)
			{
				Commom.smethod_49("Update template error: " + ex.Message);
				return false;
			}
		}
	}

	public static bool Delete(int id)
	{
		lock (_lock)
		{
			try
			{
				int rows = ConnectorKichBan.ConnectorKichBan_0.method_2("DELETE FROM NoiDungMau WHERE Id_NoiDung=" + id + ";");
				SyncToJson();
				return rows > 0;
			}
			catch (Exception ex)
			{
				Commom.smethod_49("Delete template error: " + ex.Message);
				return false;
			}
		}
	}

	private static int InsertToDb(ContentTemplate item)
	{
		try
		{
			string sql = string.Format(
				"INSERT INTO NoiDungMau (TieuDe, ChuDe, NoiDung, NgayTao, STT) VALUES ('{0}', '{1}', '{2}', '{3}', {4});",
				item.Title.Replace("'", "''"),
				item.Category.Replace("'", "''"),
				item.Content.Replace("'", "''"),
				item.CreatedAt.Replace("'", "''"),
				item.SortOrder
			);
			ConnectorKichBan.ConnectorKichBan_0.method_2(sql);
			DataTable dt = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT last_insert_rowid();");
			if (dt != null && dt.Rows.Count > 0)
			{
				return Convert.ToInt32(dt.Rows[0][0]);
			}
		}
		catch (Exception ex)
		{
			Commom.smethod_49("InsertToDb template error: " + ex.Message);
		}
		return 0;
	}

	private static void SaveToJson(List<ContentTemplate> list)
	{
		try
		{
			string jsonPath = GetJsonPath();
			string json = JsonConvert.SerializeObject(list, Formatting.Indented);
			File.WriteAllText(jsonPath, json);
		}
		catch { }
	}

	private static void SyncToJson()
	{
		try
		{
			DataTable dt = ConnectorKichBan.ConnectorKichBan_0.method_1("SELECT * FROM NoiDungMau ORDER BY STT ASC, Id_NoiDung DESC;");
			List<ContentTemplate> list = new List<ContentTemplate>();
			if (dt != null)
			{
				foreach (DataRow row in dt.Rows)
				{
					list.Add(new ContentTemplate
					{
						Id = Convert.ToInt32(row["Id_NoiDung"]),
						Title = row["TieuDe"]?.ToString() ?? "",
						Category = row["ChuDe"]?.ToString() ?? "Chung",
						Content = row["NoiDung"]?.ToString() ?? "",
						CreatedAt = row["NgayTao"]?.ToString() ?? "",
						SortOrder = row["STT"] != DBNull.Value ? Convert.ToInt32(row["STT"]) : 0
					});
				}
			}
			SaveToJson(list);
		}
		catch { }
	}
}
