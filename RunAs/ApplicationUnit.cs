using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RunAs
{
	public class ApplicationUnit
	{
		private string m_sAppPath = string.Empty;
		private string m_sAppParams = string.Empty;
		private string m_sAppLabel = string.Empty;

		public ApplicationUnit()
		{
		}

		/// <summary>
		/// Gets the application path.
		/// </summary>
		/// <value>The app path.</value>
		public string Path
		{
			get { return m_sAppPath; }
			set 
			{
 
				m_sAppPath = value;
				m_sAppPath = m_sAppPath.Replace("\"", "");
			}
		}

		/// <summary>
		/// Gets or sets the params.
		/// </summary>
		/// <value>The params.</value>
		public string Params
		{
			get { return m_sAppParams; }
			set { m_sAppParams = value; }
		}

		/// <summary>
		/// Gets the application label.
		/// </summary>
		/// <value>The app label.</value>
		public string Label
		{
			get { return m_sAppLabel; }
			set { m_sAppLabel = value; }
		}
	}
}
