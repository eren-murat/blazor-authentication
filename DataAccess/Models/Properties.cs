using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Models
{
	public enum Props { Width, Height, Top, Left, Color, Border, FontSize }
	
	public class Properties
	{
		public int IdHtml { get; set; }

		public string Width { get; set; }

		public string Height { get; set; }

		public string TopOffset { get; set; }

		public string LeftOffset { get; set; }

		public string Color { get; set; }

		public string Border { get; set; }

		public string FontSize { get; set; }

		public void SetProperty(Props propertyName, string value)
		{
			switch (propertyName)
			{
				case Props.Width:
					Width = value + "px";
					break;
				case Props.Height:
					Height = value + "px";
					break;
				case Props.Top:
					TopOffset = value + "px";
					break;
				case Props.Left:
					LeftOffset = value + "px";
					break;
				case Props.Color:
					Color = value;
					break;
				case Props.Border:
					Border = value;
					break;
				case Props.FontSize:
					FontSize = value;
					break;
				default:
					break;
			}
		}
	}
}
