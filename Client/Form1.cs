using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tavis;
using Tavis.IANA;
using Tavis.UriTemplates;

namespace Client
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private HttpClient client = new HttpClient();
		private async void button1_Click(object sender, EventArgs e)
		{

			//k	client.BaseAddress = baseAddress;

			//var response = await client.GetAsync("/api/books");

			//MessageBox.Show(response.StatusCode.ToString());

			var allBooks = new Link()
			{
				Target = new Uri("http://localhost:8080/api/books")
			};

			var result = client.FollowLinkAsync(allBooks).Result;

			MessageBox.Show(result.ToString());


		}

		private async void btnGetOne_Click(object sender, EventArgs e)
		{
			var id = int.Parse(txtId.Text);
			var bookLink = new BookLink() {Id = id};
			var result = await client.FollowLinkAsync(bookLink);

			MessageBox.Show(result.Content.ReadAsStringAsync().Result);
		}

		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			client.Dispose();
		}



	}

	public class BookLink : Link
	{
		public BookLink()
		{
			Target = new Uri("http://localhost:8080/api/books/{id}");
			SetParameter("id", 1);
		}

		public int Id
		{
			set { SetParameter("id", value); }
		}

	}
}
