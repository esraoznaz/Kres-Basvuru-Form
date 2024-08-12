using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Kres_Basvuru_Form
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		void Basvuran_Bilgisi()
		{
			string connectionString = "Server=LAPTOP-3H9G77VD\\SQLEXPRESS;Database=Kres_Basvuru;Integrated Security=True";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				if (conn.State == System.Data.ConnectionState.Open)
				{
					
					if (string.IsNullOrWhiteSpace(txt_basvuranTel.Text))
					{
						MessageBox.Show("Lütfen tüm alanları doldurunuz.");
						return;
					}
					
					SqlCommand cmd = new SqlCommand("INSERT INTO Basvuranin_Bilgisi(Telefon) VALUES (@Telefon)", conn);

					cmd.Parameters.AddWithValue("@Telefon", txt_basvuranTel.Text);
					
					int rowsAffected = cmd.ExecuteNonQuery();
					if (rowsAffected > 0)
					{
						MessageBox.Show("Başvuran Bilgisi Kaydetme İşilemi Tamamlandı");
					}
					else
					{
						MessageBox.Show(" Başvuran Bilgisi Kaydetme İşleminde Bir Sorun Oluştu");
					}

				}

				else
				{
					MessageBox.Show("Veritabanına Bağlantı Başarısız.");
				}
			}
		}
		void Cocuk_Bilgisi()
		{
			string connectionString = "Server=LAPTOP-3H9G77VD\\SQLEXPRESS;Database=Kres_Basvuru;Integrated Security=True";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				if (conn.State == System.Data.ConnectionState.Open)
				{
					// Cinsiyeti belirle
					string cinsiyet = "Yok"; // Default değer, eğer hiçbir seçenek seçilmemişse.
					if (radioButton_Erkek.Checked)
					{
						cinsiyet = "Erkek"; // Erkek
					}
					else if (radioButton_Kız.Checked)
					{
						cinsiyet = "Kız"; // Kadın
					}
					else
					{
						MessageBox.Show("Lütfen Cinsiyet seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					
					string dogumTarihiStr = txt_cocuk_dg.Text;  // TextBox'tan doğum tarihini al
					DateTime dogumTarihi;

					// Doğum tarihini doğrula ve dönüştür
					if (!DateTime.TryParse(dogumTarihiStr, out dogumTarihi))
					{
						MessageBox.Show("Geçerli bir doğum tarihi giriniz.");
						return;
					}
					if (string.IsNullOrWhiteSpace(txt_cocuk_AdSoyad.Text) ||
					string.IsNullOrWhiteSpace(txt_cocuk_tc.Text) ||
					string.IsNullOrWhiteSpace(txt_cocuk_dg.Text) ||
					!radioButton_Kız.Checked && !radioButton_Erkek.Checked ||
					string.IsNullOrWhiteSpace(comboBox_ilce.Text) ||
					string.IsNullOrWhiteSpace(comboBox_mahalle.Text))
					{
						MessageBox.Show("Lütfen tüm alanları doldurunuz.");
						return;
					}
					
					SqlCommand cmd = new SqlCommand("INSERT INTO Cocuk_Bilgisi(Cocuk_Adi_Soyadi, Cocuk_TC_No, Dogum_Tarihi, Cocuk_Cinsiyeti, Ev_Adresi ) VALUES (@Adi_Soyadi, @TC_No, @Dogum_Tarihi, @Cinsiyeti, @Adres)", conn);

					cmd.Parameters.AddWithValue("@Adi_Soyadi", txt_cocuk_AdSoyad.Text);
					cmd.Parameters.AddWithValue("@Tc_No", txt_cocuk_tc.Text);
					cmd.Parameters.AddWithValue("@Dogum_Tarihi", dogumTarihi.ToString("yyyy-MM-dd"));
					cmd.Parameters.AddWithValue("@Cinsiyeti", cinsiyet);
					cmd.Parameters.AddWithValue("@Adres", (comboBox_ilce.Text + comboBox_mahalle.Text));
					
					 int rowsAffected = cmd.ExecuteNonQuery();
					if (rowsAffected > 0)
					{
						MessageBox.Show("Çocuk Bilgisi Kaydetme İşilemi Tamamlandı");
					}
					else
					{
						MessageBox.Show("Çocuk Bilgisi Kaydetme İşleminde Bir Sorun Oluştu");
					}
					

				}

				else
				{
					MessageBox.Show("Veritabanına Bağlantı Başarısız.");
				}
			}
		}
		void Harici_Bilgisi()
		{
			string connectionString = "Server=LAPTOP-3H9G77VD\\SQLEXPRESS;Database=Kres_Basvuru;Integrated Security=True";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				if (conn.State == System.Data.ConnectionState.Open)
				{
					

					if (string.IsNullOrWhiteSpace(richTxt_kronik.Text)|| 
						string.IsNullOrWhiteSpace(richTxt_alerji.Text) ||
						string.IsNullOrWhiteSpace(richTxt_Davranis.Text) ||
						string.IsNullOrWhiteSpace(richTxt_ozelDurum.Text))
					{
						MessageBox.Show("Lütfen tüm alanları doldurunuz.");
						return;
					}

					SqlCommand cmd = new SqlCommand("INSERT INTO Cocuk_Harici_Bilgi(Cocuk_Kronik_Hastalik, Cocuk_Alerji, Cocuk_Davranis_Problemi, Cocuk_Ozel_Durum) VALUES (@kronik, @alerji, @davranis, @ozelDurum)", conn);

					cmd.Parameters.AddWithValue("@kronik", richTxt_kronik.Text);
					cmd.Parameters.AddWithValue("@alerji", richTxt_alerji.Text);
					cmd.Parameters.AddWithValue("@davranis", richTxt_Davranis.Text);
					cmd.Parameters.AddWithValue("@ozelDurum", richTxt_ozelDurum.Text);
					
					int rowsAffected = cmd.ExecuteNonQuery();
					if (rowsAffected > 0)
					{
						MessageBox.Show("Harici Bilgi Kaydetme İşilemi Tamamlandı");
					}
					else
					{
						MessageBox.Show("Harici Bilgi Kaydetme İşleminde Bir Sorun Oluştu");
					}

				}
				
				else
				{
					MessageBox.Show("Veritabanına Bağlantı Başarısız.");
				}
			}
		}

		void Anne_Bilgisi()
		{
			string connectionString = "Server=LAPTOP-3H9G77VD\\SQLEXPRESS;Database=Kres_Basvuru;Integrated Security=True";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				if (conn.State == System.Data.ConnectionState.Open)
				{
					// meslek tipi belirle
					string meslekTipi = "Yok"; // Default değer, eğer hiçbir seçenek seçilmemişse.
					if (radioButton_Personel_anne.Checked)
					{
						meslekTipi = "Personel"; 
					}
					else if (radioButton_memur_anne.Checked)
					{
						meslekTipi = "Memur"; 
					}
					else if (radioButton_OzelSektor_anne.Checked)
					{
						meslekTipi = "Özel Sektör";
					}
					else
					{
						// Eğer hiçbir radioButton seçilmemişse, uyarı mesajı göster
						MessageBox.Show("Lütfen Meslek Tipi seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}


					string anneDurumu = "Yok"; // Default değer, eğer hiçbir seçenek seçilmemişse.
					if (radioButton_Oz_anne.Checked)
					{
						anneDurumu = "Öz"; 
					}
					else if (radioButton_Uvey_anne.Checked)
					{
						anneDurumu = "Üvey"; 
					}
					else
					{
						MessageBox.Show("Lütfen Anne durumu seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

				

					if (string.IsNullOrWhiteSpace(txt_anne_adSoyad.Text) ||
					string.IsNullOrWhiteSpace(txt_anne_tc.Text) ||
					string.IsNullOrWhiteSpace(txt_anne_meslek.Text) ||
					!radioButton_Personel_anne.Checked && !radioButton_memur_anne.Checked && !radioButton_OzelSektor_anne.Checked ||
					string.IsNullOrWhiteSpace(richtxt_anne_isAdres.Text) ||
					string.IsNullOrWhiteSpace(txt_anne_calısmaSaati.Text)||
					string.IsNullOrWhiteSpace(txt_anne_tel.Text) ||
					string.IsNullOrWhiteSpace(txt_anneye_UlasilmadigindaTel.Text) ||
					!radioButton_Oz_anne.Checked && !radioButton_Uvey_anne.Checked)
					{
						MessageBox.Show("Lütfen tüm alanları doldurunuz.");
						return;
					}

					SqlCommand cmd = new SqlCommand("INSERT INTO Anne_Bilgisi(Anne_Adi_Soyadi, Anne_TC_No, Anne_Meslegi, Anne_Meslek_Tipi, Anne_Acik_Is_Adresi, Anne_Calisma_Saatleri, Anne_Cep_Telefonu, Anneye_Ulasilamadiginda_Irtibat_No, Anne_Durumu) VALUES (@Adi_Soyadi, @TC_No, @Meslegi, @Meslek_Tipi, @Is_Adresi, @Calisma_Saatleri, @Telefonu, @Ulasilamadiginda_Irtibat_No, @Durumu)", conn);

					cmd.Parameters.AddWithValue("@Adi_Soyadi",txt_anne_adSoyad.Text);
					cmd.Parameters.AddWithValue("@Tc_No", txt_anne_tc.Text);
					cmd.Parameters.AddWithValue("@Meslegi", txt_anne_meslek.Text);
					cmd.Parameters.AddWithValue("@Meslek_Tipi", meslekTipi);
					cmd.Parameters.AddWithValue("@Is_Adresi", richtxt_anne_isAdres.Text);
					cmd.Parameters.AddWithValue("@Calisma_Saatleri", txt_anne_calısmaSaati.Text);
					cmd.Parameters.AddWithValue("@Telefonu", txt_anne_tel.Text);
					cmd.Parameters.AddWithValue("@Ulasilamadiginda_Irtibat_No", txt_anneye_UlasilmadigindaTel.Text);
					cmd.Parameters.AddWithValue("@Durumu", anneDurumu);
					
					int rowsAffected = cmd.ExecuteNonQuery();
					if (rowsAffected > 0)
					{
						MessageBox.Show("Anne Bilgisi Kaydetme İşilemi Tamamlandı");
					}
					else
					{
						MessageBox.Show("Anne Bilgisi Kaydetme İşleminde Bir Sorun Oluştu");
					}
					



				}

				else
				{
					MessageBox.Show("Veritabanına Bağlantı Başarısız.");
				}
			}
		}

		void Baba_Bilgisi()
		{
			string connectionString = "Server=LAPTOP-3H9G77VD\\SQLEXPRESS;Database=Kres_Basvuru;Integrated Security=True";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				if (conn.State == System.Data.ConnectionState.Open)
				{
					// meslek tipi belirle
					string meslekTipi = "Yok"; // Default değer, eğer hiçbir seçenek seçilmemişse.
					if (radioButton_baba_personel.Checked)
					{
						meslekTipi = "Personel";
					}
					else if (radioButton_baba_memur.Checked)
					{
						meslekTipi = "Memur";
					}
					else if (radioButton_baba_ozelSektor.Checked)
					{
						meslekTipi = "Özel Sektör";
					}
					else
					{
						// Eğer hiçbir radioButton seçilmemişse, uyarı mesajı göster
						MessageBox.Show("Lütfen Meslek Tipi seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}


					string babaDurumu = "Yok"; // Default değer, eğer hiçbir seçenek seçilmemişse.
					if (radioButton_baba_oz.Checked)
					{
						babaDurumu = "Öz"; 
					}
					else if (radioButton_baba_uvey.Checked)
					{
						babaDurumu = "Üvey"; 
					}
					else
					{
						MessageBox.Show("Lütfen Baba durumu seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					

					if (string.IsNullOrWhiteSpace(txt_baba_adSoyad.Text) ||
					string.IsNullOrWhiteSpace(txt_baba_tc.Text) ||
					string.IsNullOrWhiteSpace(txt_baba_meslek.Text) ||
					!radioButton_baba_personel.Checked && !radioButton_baba_memur.Checked && !radioButton_baba_ozelSektor.Checked ||
					string.IsNullOrWhiteSpace(richtxt_baba_isAdresi.Text) ||
					string.IsNullOrWhiteSpace(txt_baba_calısmaSaati.Text) ||
					string.IsNullOrWhiteSpace(txt_baba_tel.Text) ||
					string.IsNullOrWhiteSpace(txt_baba_ulasilmadigindaTEL.Text) ||
					!radioButton_baba_oz.Checked && !radioButton_baba_uvey.Checked)
					{
						MessageBox.Show("Lütfen tüm alanları doldurunuz.");
						return;
					}

					SqlCommand cmd = new SqlCommand("INSERT INTO Baba_Bilgisi(Baba_Adi_Soyadi, Baba_TC_No, Baba_Meslegi, Baba_Meslek_Tipi, Baba_Acik_Is_Adresi, Baba_Calisma_Saatleri, Baba_Cep_Telefonu, Babaya_Ulasilamadiginda_Irtibat_No, Baba_Durumu) VALUES " +
						"(@Adi_Soyadi, @TC_No, @Meslegi, @Meslek_Tipi, @Is_Adresi, @Calisma_Saatleri, @Telefonu, @Ulasilamadiginda_Irtibat_No, @Durumu)", conn);

					cmd.Parameters.AddWithValue("@Adi_Soyadi", txt_baba_adSoyad.Text);
					cmd.Parameters.AddWithValue("@Tc_No", txt_baba_tc.Text);
					cmd.Parameters.AddWithValue("@Meslegi", txt_baba_meslek.Text);
					cmd.Parameters.AddWithValue("@Meslek_Tipi", meslekTipi);
					cmd.Parameters.AddWithValue("@Is_Adresi", richtxt_baba_isAdresi.Text);
					cmd.Parameters.AddWithValue("@Calisma_Saatleri", txt_baba_calısmaSaati.Text);
					cmd.Parameters.AddWithValue("@Telefonu", txt_baba_tel.Text);
					cmd.Parameters.AddWithValue("@Ulasilamadiginda_Irtibat_No", txt_baba_ulasilmadigindaTEL.Text);
					cmd.Parameters.AddWithValue("@Durumu", babaDurumu);
					
					int rowsAffected = cmd.ExecuteNonQuery();
					if (rowsAffected > 0)
					{
						MessageBox.Show("Baba Bilgisi Kaydetme İşilemi Tamamlandı");
					}
					else
					{
						MessageBox.Show("Baba Bilgisi Kaydetme İşleminde Bir Sorun Oluştu");
					}
				}

				else
				{
					MessageBox.Show("Veritabanına Bağlantı Başarısız.");
				}
			}
		}
		void Bakan_Bilgisi()
		{
			string connectionString = "Server=LAPTOP-3H9G77VD\\SQLEXPRESS;Database=Kres_Basvuru;Integrated Security=True";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				if (conn.State == System.Data.ConnectionState.Open)
				{
					string torun = "Yok"; // Default değer, eğer hiçbir seçenek seçilmemişse.
					if (radioButton_evet_torun.Checked)
					{
						torun= "EVET";
					}
					else if (radioButton_hayir_torun.Checked)
					{
						torun = "HAYIR"; 
					}
					else
					{
						MessageBox.Show("Lütfen torun kısmını seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

				

					if (!radioButton_evet_torun.Checked && !radioButton_hayir_torun.Checked ||
					string.IsNullOrWhiteSpace(txt_bakan_tc.Text) ||
					string.IsNullOrWhiteSpace(txt_bakan_tel.Text))
					{
						MessageBox.Show("Lütfen tüm alanları doldurunuz.");
						return;
					}

					SqlCommand cmd = new SqlCommand("INSERT INTO Bakanin_Bilgisi(Emekli_Personel_Torun, Bakan_TC_No, Bakan_Telefon_Numarasi) VALUES (@Torun, @TC_No, @telefon)", conn);
					cmd.Parameters.AddWithValue("@Torun", torun);
					cmd.Parameters.AddWithValue("@TC_No", txt_bakan_tc.Text);
					cmd.Parameters.AddWithValue("@telefon", txt_bakan_tel.Text);
					
					int rowsAffected = cmd.ExecuteNonQuery();
					if (rowsAffected > 0)
					{
						MessageBox.Show("Bakan Bilgisi Kaydetme İşilemi Tamamlandı");
					}
					else
					{
						MessageBox.Show("Bakan Bilgisi Kaydetme İşleminde Bir Sorun Oluştu");
					}

				}

				else
				{
					MessageBox.Show("Veritabanına Bağlantı Başarısız.");
				}
			}
		}



		private void Form1_Load(object sender, EventArgs e)
		{
			LoadIlceler();			
		}

		private void button_basvuruOlustur_Click(object sender, EventArgs e)
		{
			Cocuk_Bilgisi();
			Basvuran_Bilgisi();
			Harici_Bilgisi();
			Anne_Bilgisi();
			Baba_Bilgisi();
			Bakan_Bilgisi();
		}

		private void LoadIlceler()
		{

			string connectionString = "Server=LAPTOP-3H9G77VD\\SQLEXPRESS;Database=Kres_Basvuru;Integrated Security=True";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				if (conn.State == System.Data.ConnectionState.Open)
				{
					string query = "SELECT ID, ILCELER FROM ILCELER";
					SqlDataAdapter da = new SqlDataAdapter(query, conn);
					DataTable dt = new DataTable();
					da.Fill(dt);

					comboBox_ilce.DisplayMember = "ILCELER";
					comboBox_ilce.ValueMember = "ID";
					comboBox_ilce.DataSource = dt;

				}

				else
				{
					MessageBox.Show("Veritabanına Bağlantı Başarısız.");
				}
			}
			
		}
		private void LoadMahalleler(int ilceId)
		{
			string connectionString = "Server=LAPTOP-3H9G77VD\\SQLEXPRESS;Database=Kres_Basvuru;Integrated Security=True";
			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				conn.Open();
				if (conn.State == System.Data.ConnectionState.Open)
				{
					string query = "SELECT ID, MAHALLE FROM MAHALLE WHERE ILCE_ID = @ilceId ORDER BY MAHALLE ASC";
					SqlCommand cmd = new SqlCommand(query, conn);
					cmd.Parameters.AddWithValue("@ilceId", ilceId);

					SqlDataAdapter da = new SqlDataAdapter(cmd);
					DataTable dt = new DataTable();
					da.Fill(dt);

					comboBox_mahalle.DisplayMember = "MAHALLE";
					comboBox_mahalle.ValueMember = "ID";
					comboBox_mahalle.DataSource = dt;

				}

				else
				{
					MessageBox.Show("Veritabanına Bağlantı Başarısız.");
				}
			}
			
		}
		private void comboBox_ilce_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox_ilce.SelectedValue != null)
			{
				int selectedIlceId = (int)comboBox_ilce.SelectedValue;
				LoadMahalleler(selectedIlceId);
			}

		}
	}
}