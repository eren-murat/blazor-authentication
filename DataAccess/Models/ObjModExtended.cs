using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
	public class ObjModExtended
	{
		public int Id { get; set; }

		public int Grupare { get; set; }

		public string Tip { get; set; }

		public int Activ { get; set; }

		public int Ordine { get; set; }

		public string Simbol { get; set; }

		public DateTime Data { get; set; }

		public DateTime ValoareData { get; set; }

		public string ValoareString { get; set; }

		public int ValoareInt { get; set; }

		public int Referinta { get; set; }

		public List<int> Valori { get; set; }

		public Properties ProprietatiLabel { get; set; }

		public Properties ProprietatiControl { get; set; }

		public async void CopyFields(ObjModel rawObj, ISqlDataAccess sqlDataAccess)
		{
			Id = rawObj.Id;
			Grupare = rawObj.Grupare;
			Tip = rawObj.Tip;
			Activ = rawObj.Activ;
			Ordine = rawObj.Ordine;
			Simbol = rawObj.Simbol;
			Data = rawObj.Data;

			if (rawObj.Tip == "VARCHAR(255)")
			{
				ValoareString = rawObj.Valoare;
				ValoareData = DateTime.MinValue;
				ValoareInt = Int32.MinValue;
				Valori = null;
			}
			else if (rawObj.Tip == "INT")
			{
				ValoareString = null;
				ValoareData = DateTime.MinValue;
				ValoareInt = Int32.MinValue;
				Valori = await sqlDataAccess.GetComboboxList(rawObj.Id);
			}
			else if (rawObj.Tip == "DATETIME")
			{
				ValoareString = null;
				ValoareData = DateTime.Parse(rawObj.Valoare);
				ValoareInt = Int32.MinValue;
				Valori = null;
			}
			else
			{
				ValoareString = null; ;
				ValoareData = DateTime.MinValue;
				ValoareInt = Int32.MinValue;
				Valori = null;
			}
		}
	}
}
