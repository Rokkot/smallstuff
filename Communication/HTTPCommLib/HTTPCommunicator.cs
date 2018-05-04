using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTPCommLib
{
    public class HttpCommunicator
    {
        private TimeSpan m_SendTimeout = TimeSpan.FromSeconds(100);
        private TimeSpan m_ReadWriteTimeout = TimeSpan.FromMinutes(5);
        private string m_strDestAddress = string.Empty;
    }
