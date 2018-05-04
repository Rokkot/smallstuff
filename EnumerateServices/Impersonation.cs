//
//
// Matt Johnson 
// http://stackoverflow.com/questions/125341/how-do-you-do-impersonation-in-net
//

using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EnumerateServices
{
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public class Impersonation : IDisposable
	{
		private readonly SafeTokenHandle m_handle;
		private readonly WindowsImpersonationContext m_context;

		const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

		public Impersonation(string _sDomain, string _sUserName, string _sPassword)
		{
			var ok = LogonUser(_sUserName
								, _sDomain
								, _sPassword
								, LOGON32_LOGON_NEW_CREDENTIALS
								, 0
								, out this.m_handle);
			if (ok == false)
			{
				int errorCode = Marshal.GetLastWin32Error();

				throw new ApplicationException(string.Format("Could not impersonate the elevated user.  LogonUser returned error code {0}.", errorCode));
			}

			this.m_context = WindowsIdentity.Impersonate(this.m_handle.DangerousGetHandle());
		}

		public void Dispose()
		{
			this.m_context.Dispose();
			this.m_handle.Dispose();
		}

		[DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		private static extern bool LogonUser(String lpszUsername
											, String lpszDomain
											, String lpszPassword
											, int dwLogonType
											, int dwLogonProvider
											, out SafeTokenHandle phToken);

		public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
		{
			private SafeTokenHandle()
				: base(true) { }

			[DllImport("kernel32.dll")]
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			[SuppressUnmanagedCodeSecurity]
			[return: MarshalAs(UnmanagedType.Bool)]
			private static extern bool CloseHandle(IntPtr handle);

			protected override bool ReleaseHandle()
			{
				return CloseHandle(handle);
			}
		}
	}
}
