using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
	public class ObjModel
	{
		public int Id { get; set; }

		public int Grupare { get; set; }

		public string Tip { get; set; }

		public int Activ { get; set; }
		
		public int Ordine { get; set; }

		public string Simbol { get; set; }

		public DateTime Data { get; set; }

		public string Valoare { get; set; }

		public int Referinta { get; set; }
	}
}
