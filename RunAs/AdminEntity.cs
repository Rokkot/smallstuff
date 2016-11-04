using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;

using Utils;

namespace RunAs
{
	public class AdminEntity
	{
		private const int C_INT = 158507486;

		private string m_sUserName = string.Empty;
		private string m_sDomain = string.Empty;
		private string m_sPWD = string.Empty;

		public AdminEntity(string _sUserName, string _sDomain, string _sPWD)
		{
			m_sUserName = _sUserName;
			m_sDomain = _sDomain;
			m_sPWD = _sPWD;
		}

		public AdminEntity()
		{
			FromConfig();
		}

		public AdminEntity(string _sEntity)
		{
			FromString(_sEntity);
		}

		public string UserName
		{
			get { return m_sUserName; }
			//set { m_sUserName = value; }
		}

		public string Domain
		{
			get { return m_sDomain; }
			//set { m_sDomain = value; }
		}

		public string Password
		{
			get { return m_sPWD; }
			//set { m_sPWD = value; }
		}

		private void FromConfig()
		{
			try
			{
				DataAccessConfig config = new DataAccessConfig();
				config = (DataAccessConfig)ConfigurationManager.GetConfiguration((AppConfigBase)config);

				if ((config != null) || (string.IsNullOrEmpty(config.Entity) == false))
				{
					FromString(config.Entity);
				}
			}
			catch (Exception exp)
			{
				Logger.ThrowException(exp, "e86583ac-77d3-42b1-a0ba-490c5e52affb");
			}
		}

		private void FromString(string _sEntity)
		{
			try
			{
				DataAccessConfig config = new DataAccessConfig();
				config = (DataAccessConfig)ConfigurationManager.GetConfiguration((AppConfigBase)config);

				if (string.IsNullOrEmpty(_sEntity) == false)
				{
					string sEntity = EncDec.Decrypt(_sEntity, C_INT.ToString());

					if (string.IsNullOrEmpty(sEntity) == false)
					{
						string[] saEntityArray = sEntity.Split(';');

						if( (saEntityArray != null) && (saEntityArray.Length == 3))
						{
							m_sUserName = saEntityArray[0];
							m_sDomain = saEntityArray[1];
							m_sPWD = saEntityArray[2];
						}
					}
				}
			}
			catch (Exception exp)
			{
				Logger.ThrowException(exp, "c479aeaa-f54e-4d5b-8d35-412dd92eecc7");
			}
		}

		public override string ToString()
		{
			try
			{
				return  EncDec.Encrypt(string.Format("{0};{1};{2}", m_sUserName, m_sDomain, m_sPWD)
								, C_INT.ToString());
			}
			catch (Exception exp)
			{
				Logger.ThrowException(exp, "6a63396d-b113-4e03-b449-bf0cf3225b7a");
			}

			return string.Empty;
		}

		public SecureString PwdToSecureString()
		{
			try
			{
				char[] PasswordChars = m_sPWD.ToCharArray();

				SecureString Password = new SecureString();

				foreach (char c in PasswordChars)
				{
					Password.AppendChar(c);
				}

				return Password;
			}
			catch (Exception exp)
			{
				Logger.ThrowException(exp, "975d8fa4-4aae-4075-8993-85137130874b");
			}

			return null;
		}
	}
}
