using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace RunAs
{
	//[XmlInclude(typeof(<list clss name>))]
	public class DataAccessConfig : AppConfigBase
	{
		private bool m_bCloseWhenRun = true;
		private string m_sEntity = string.Empty;
		List<ApplicationUnit> m_lstApplications = null;

		public DataAccessConfig()
		{
			m_lstApplications = new List<ApplicationUnit>();
		}

		public override string GetConfigSectionName()
		{
			return this.GetType().Name;
		}

		public string Entity
		{
			get { return m_sEntity; }
			set { m_sEntity = value; }
		}

		public bool CloseWhenRun
		{
			get { return m_bCloseWhenRun; }
			set { m_bCloseWhenRun = value; }
		}
		
		public List<ApplicationUnit> ApplicationsList
		{
			get { return m_lstApplications; }
			set { m_lstApplications = value; }
		}
	}
}
