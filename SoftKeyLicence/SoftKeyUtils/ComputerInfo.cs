using System;
using System.Management;
using System.Text;

namespace SoftKeyUtils
{
    public static class ComputerMetrics
    {
        public delegate void ProgressDelegate();

        #region Production Code
        public static string GetComputerUniqueID()
        {
            return GetComputerUniqueID(null);
        }

        private static void ExecuteProgressDelegate(ProgressDelegate _progress)
        {
            try
            {
                if (_progress != null)
                {
                    _progress();
                }
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "eed49181-133a-4072-b61f-b65ac2cd2d72");
            }
        }

        public static string GetComputerUniqueID(ProgressDelegate _progress)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine("MachineName_" + Environment.MachineName);

                ExecuteProgressDelegate(_progress);
                sb.Append(CPUID());

                ExecuteProgressDelegate(_progress);
                sb.Append(BIOSID());

                ExecuteProgressDelegate(_progress);
                sb.Append(DiskID());

                ExecuteProgressDelegate(_progress);
                sb.Append(BaseID());

                ExecuteProgressDelegate(_progress);
                sb.Append(VideoID());

                ExecuteProgressDelegate(_progress);
                sb.Append(MACID());

                string sInfo = sb.ToString();

                if (sInfo != string.Empty)
                {
                    sInfo = string.Format("3C396DADE58A4CC08AA3C1D0330D185A{0}4E289E01FD7D49B59FFB837A47456E7D", sInfo);

                    return CryptoUtils.CalculateChecksumSHA512(sInfo);
                }
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "8a6b271a-98c7-4d5f-a628-8fe6ab22f743");
            }

            return string.Empty;
        }

        public static string CPUID()
        {
            try
            {
                //Uses first CPU identifier available in order of preference
                //Don't get all identifiers, as it is very time consuming
                string retVal = GetPropertyInfo("Win32_Processor", "UniqueId");

                if (retVal == "") //If no UniqueID, use ProcessorID
                {
                    retVal = GetPropertyInfo("Win32_Processor", "ProcessorId");

                    if (retVal == "") //If no ProcessorId, use Name
                    {
                        retVal = GetPropertyInfo("Win32_Processor", "Name");
                        if (retVal == "") //If no Name, use Manufacturer
                        {
                            retVal = GetPropertyInfo("Win32_Processor", "Manufacturer");
                        }

                        //Add clock speed for extra security
                        retVal += GetPropertyInfo("Win32_Processor", "MaxClockSpeed");
                    }
                }

                return retVal;
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "9c0dfd68-ae48-42d5-85b2-f00a614e6f55");
            }

            return string.Empty;
        }

        public static string BIOSID()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(GetPropertyInfo("Win32_BIOS", "Manufacturer"));
                sb.Append(GetPropertyInfo("Win32_BIOS", "SMBIOSBIOSVersion"));
                sb.Append(GetPropertyInfo("Win32_BIOS", "IdentificationCode"));
                sb.Append(GetPropertyInfo("Win32_BIOS", "SerialNumber"));
                sb.Append(GetPropertyInfo("Win32_BIOS", "ReleaseDate"));
                sb.Append(GetPropertyInfo("Win32_BIOS", "Version"));
                return sb.ToString();
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "45ac196c-d879-44ec-b168-00c159f3e3d8");
            }
            return string.Empty;
        }

        public static string DiskID()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(GetPropertyInfo("Win32_DiskDrive", "Model"));
                sb.Append(GetPropertyInfo("Win32_DiskDrive", "Manufacturer"));
                sb.Append(GetPropertyInfo("Win32_DiskDrive", "SerialNumber"));
                sb.Append(GetPropertyInfo("Win32_DiskDrive", "Signature"));
                sb.Append(GetPropertyInfo("Win32_DiskDrive", "TotalHeads"));
                return sb.ToString();
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "ba918866-ada4-4b6c-92d3-8a23e52afdb3");
            }

            return string.Empty;
        }

        public static string BaseID()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(GetPropertyInfo("Win32_BaseBoard", "Model"));
                sb.Append(GetPropertyInfo("Win32_BaseBoard", "Manufacturer"));
                sb.Append(GetPropertyInfo("Win32_BaseBoard", "Name"));
                sb.Append(GetPropertyInfo("Win32_BaseBoard", "SerialNumber"));
                return sb.ToString();
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "e6f79a43-57be-49c1-9c86-3b180f2bb12b");
            }

            return string.Empty;
        }

        public static string VideoID()
        {

            try
            {
                StringBuilder sb = new StringBuilder();
                //sb.Append(GetPropertyInfo("Win32_VideoController", "DriverVersion"));
                sb.Append(GetPropertyInfo("Win32_VideoController", "Name"));
                return sb.ToString();
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "6963616d-d020-40f0-8968-7b650d1d205d");
            }

            return string.Empty;
        }

        public static string MACID()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(GetPropertyInfo("Win32_NetworkAdapterConfiguration",
                    "MACAddress", "IPEnabled"));
                return sb.ToString();
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "0bd89725-fccd-4ffb-ad4f-907d26721d70");
            }

            return string.Empty;
        }

        private static string GetPropertyInfo(string _sKey, string _sPropName)
        {
            return GetPropertyInfo(_sKey, _sPropName, string.Empty);
        }

        private static string GetPropertyInfo(string _sKey, string _sPropName, string _sPropNameMustBeTrue)
        {
            string sInfo = string.Empty;

            try
            {
                if (string.IsNullOrEmpty(_sPropNameMustBeTrue) == true)
                {
                    return GetSingleKeyInfo(_sKey, _sPropName);
                }
                else
                {
                    return GetSingleKeyInfo(_sKey, _sPropName, _sPropNameMustBeTrue);
                }
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "19fd9baa-b7c9-4a99-bee9-ed4171a7b34b");
            }

            return sInfo;
        }

        private static string GetSingleKeyInfo(string _sKey, string _sPropName, string _sPropNameMustBeTrue)
        {
            string result = string.Empty;
            string sValue = string.Empty;

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + _sKey);

                foreach (ManagementObject objMngmnt in searcher.Get())
                {
                    sValue = GetPropertyValue(objMngmnt.Properties[_sPropNameMustBeTrue]);

                    if (sValue == "True")
                    {
                        //Only get the first one
                        if (result == string.Empty)
                        {
                            result = GetPropertyValue(objMngmnt.Properties[_sPropName]);

                            if (string.IsNullOrEmpty(result) == false)
                            {
                                result = FormatResaltString(_sKey
                                                            , _sPropName
                                                            , result);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "29377f4d-88f5-4256-a3d1-1204f7a002cd");
            }

            return result;
        }

        private static string GetSingleKeyInfo(string _sKey, string _sPropName)
        {
            string result = string.Empty;

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + _sKey);

                foreach (ManagementObject objMngmnt in searcher.Get())
                {
                    //Only get the first one
                    if (result == string.Empty)
                    {
                        result = GetPropertyValue(objMngmnt.Properties[_sPropName]);

                        if (string.IsNullOrEmpty(result) == false)
                        {
                            result = FormatResaltString(_sKey
                                                        , _sPropName
                                                        , result);
                            break;
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "766112cb-3280-485a-9e4c-9545f6ce07be");
            }

            return result;
        }

        private static string FormatResaltString(string _sKey, string _sPropName, string _sValue)
        {
            try
            {
                return string.Format("{0}_{1}_{2}\r\n"
                                , _sKey.Replace("Win32_", "")
                                , _sPropName
                                , _sValue.Replace(" ", ""));
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "34531f8a-8513-4c8f-9956-0731bc16c073");
            }

            return string.Empty;
        }

        private static string GetPropertyValue(PropertyData _propData)
        {
            string sRetValue = string.Empty;

            try
            {
                if ((_propData != null)
                    && (_propData.Value != null)
                    && (_propData.Value.ToString() != string.Empty))
                {
                    switch (_propData.Value.GetType().ToString())
                    {
                        case "System.String[]":
                            {
                                string[] str = (string[])_propData.Value;

                                foreach (string st in str)
                                {
                                    sRetValue += st + " ";
                                }
                            }
                            break;
                        case "System.UInt16[]":
                            {
                                ushort[] shortData = (ushort[])_propData.Value;

                                foreach (ushort st in shortData)
                                {
                                    sRetValue += st.ToString() + " ";
                                }
                            }
                            break;

                        default:
                            sRetValue = _propData.Value.ToString();
                            break;
                    }
                }
                else
                {
                    sRetValue = string.Empty;
                }
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "4e83fcfd-a7e4-43e8-a7e4-1859d46dc624");
            }

            return sRetValue;
        }

        #endregion Production Code

        #region Info / Demo Code
        public static bool GetOneKeyInfo(string _sKey, out string _sInfo)
        {
            _sInfo = string.Empty;

            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + _sKey);
                StringBuilder sb = new StringBuilder();

                sb.AppendLine();
                sb.AppendLine("************************************************************");
                sb.AppendLine(_sKey);
                sb.AppendLine("************************************************************");

                foreach (ManagementObject objMngmnt in searcher.Get())
                {
                    try
                    {
                        sb.AppendLine(objMngmnt["Name"].ToString());
                    }
                    catch
                    {
                        sb.AppendLine(objMngmnt.ToString());
                    }

                    if (objMngmnt.Properties.Count <= 0)
                    {
                        sb.AppendLine("No Information available");
                        _sInfo = sb.ToString();

                        return true;
                    }

                    foreach (PropertyData propData in objMngmnt.Properties)
                    {
                        sb.AppendLine(string.Format("{0}: {1}"
                                                    , propData.Name
                                                    , GetPropertyValue(propData)));
                    }
                }

                _sInfo = sb.ToString();
            }
            catch (Exception exp)
            {
                Logger.WriteErrorLogOnly(exp, "4dbb1c66-2a5e-47a3-b278-1706b12b6ad3");
                _sInfo = string.Format("Can't get data for {0} because of the followeing error \n{1}", _sKey, exp.Message);
                return false;
            }

            return true;
        }

    }
    public enum ComputerInfoKeys
    {
        Win32_BaseBoard, // SerialNumber
        Win32_BIOS, // SerialNumber, ReleaseDate
        Win32_Bus,
        Win32_CDROMDrive, // PNPDeviceID
        Win32_DisplayConfiguration,
        Win32_DisplayControllerConfiguration,
        Win32_DMAChannel,
        Win32_DriverVXD,
        Win32_IDEController, // DeviceID: , PNPDeviceID
        Win32_MotherboardDevice,
        Win32_OnBoardDevice,
        Win32_PnPEntity, // HardwareID, DeviceID
        Win32_PointingDevice, // DeviceID, PNPDeviceID Mouse ?????
        Win32_PortConnector,
        Win32_PortResource,
        Win32_Processor, // ProcessorId
        Win32_SCSIController, // PNPDeviceID
        Win32_SerialPort, // PNPDeviceID
        Win32_SerialPortConfiguration,
        Win32_SerialPortSetting,
        Win32_SoundDevice,
        Win32_USBController,
        Win32_VideoController,
        Win32_DiskDrive, // SerialNumber, Signature, Caption, PNPDeviceID, ...
        Win32_NetworkAdapter,
    }

    public enum ComputerInfoKeysFull
    {
        Win32_1394Controller,
        Win32_1394ControllerDevice,
        Win32_Account,
        Win32_AccountSID,
        Win32_ACE,
        Win32_ActionCheck,
        Win32_AllocatedResource,
        Win32_ApplicationCommandLine,
        Win32_ApplicationService,
        Win32_AssociatedBattery,
        Win32_AssociatedProcessorMemory,
        Win32_BaseBoard,
        Win32_BaseService,
        Win32_Battery,
        Win32_Binary,
        Win32_BindImageAction,
        Win32_BIOS,
        Win32_BootConfiguration,
        Win32_Bus,
        Win32_CacheMemory,
        Win32_CDROMDrive,
        Win32_CheckCheck,
        Win32_CIMLogicalDeviceCIMDataFile,
        Win32_ClassicCOMApplicationClasses,
        Win32_ClassicCOMClass,
        Win32_ClassicCOMClassSetting,
        Win32_ClassicCOMClassSettings,
        Win32_ClassInfoAction,
        Win32_ClientApplicationSetting,
        Win32_CodecFile,
        Win32_COMApplication,
        Win32_COMApplicationClasses,
        Win32_COMApplicationSettings,
        Win32_COMClass,
        Win32_ComClassAutoEmulator,
        Win32_ComClassEmulator,
        Win32_CommandLineAccess,
        Win32_ComponentCategory,
        Win32_ComputerSystem,
        Win32_ComputerSystemProcessor,
        Win32_ComputerSystemProduct,
        Win32_COMSetting,
        Win32_Condition,
        Win32_CreateFolderAction,
        Win32_CurrentProbe,
        Win32_DCOMApplication,
        Win32_DCOMApplicationAccessAllowedSetting,
        Win32_DCOMApplicationLaunchAllowedSetting,
        Win32_DCOMApplicationSetting,
        Win32_DependentService,
        Win32_Desktop,
        Win32_DesktopMonitor,
        Win32_DeviceBus,
        Win32_DeviceMemoryAddress,
        Win32_DeviceSettings,
        Win32_Directory,
        Win32_DirectorySpecification,
        Win32_DiskDrive,
        Win32_DiskDriveToDiskPartition,
        Win32_DiskPartition,
        Win32_DisplayConfiguration,
        Win32_DisplayControllerConfiguration,
        Win32_DMAChannel,
        Win32_DriverVXD,
        Win32_DuplicateFileAction,
        Win32_Environment,
        Win32_EnvironmentSpecification,
        Win32_ExtensionInfoAction,
        Win32_Fan,
        Win32_FileSpecification,
        Win32_FloppyController,
        Win32_FloppyDrive,
        Win32_FontInfoAction,
        Win32_Group,
        Win32_GroupUser,
        Win32_HeatPipe,
        Win32_IDEController,
        Win32_IDEControllerDevice,
        Win32_ImplementedCategory,
        Win32_InfraredDevice,
        Win32_IniFileSpecification,
        Win32_InstalledSoftwareElement,
        Win32_IRQResource,
        Win32_Keyboard,
        Win32_LaunchCondition,
        Win32_LoadOrderGroup,
        Win32_LoadOrderGroupServiceDependencies,
        Win32_LoadOrderGroupServiceMembers,
        Win32_LogicalDisk,
        Win32_LogicalDiskRootDirectory,
        Win32_LogicalDiskToPartition,
        Win32_LogicalFileAccess,
        Win32_LogicalFileAuditing,
        Win32_LogicalFileGroup,
        Win32_LogicalFileOwner,
        Win32_LogicalFileSecuritySetting,
        Win32_LogicalMemoryConfiguration,
        Win32_LogicalProgramGroup,
        Win32_LogicalProgramGroupDirectory,
        Win32_LogicalProgramGroupItem,
        Win32_LogicalProgramGroupItemDataFile,
        Win32_LogicalShareAccess,
        Win32_LogicalShareAuditing,
        Win32_LogicalShareSecuritySetting,
        Win32_ManagedSystemElementResource,
        Win32_MemoryArray,
        Win32_MemoryArrayLocation,
        Win32_MemoryDevice,
        Win32_MemoryDeviceArray,
        Win32_MemoryDeviceLocation,
        Win32_MethodParameterClass,
        Win32_MIMEInfoAction,
        Win32_MotherboardDevice,
        Win32_MoveFileAction,
        Win32_MSIResource,
        Win32_NetworkAdapter,
        Win32_NetworkAdapterConfiguration,
        Win32_NetworkAdapterSetting,
        Win32_NetworkClient,
        Win32_NetworkConnection,
        Win32_NetworkLoginProfile,
        Win32_NetworkProtocol,
        Win32_NTEventlogFile,
        Win32_NTLogEvent,
        Win32_NTLogEventComputer,
        Win32_NTLogEventLog,
        Win32_NTLogEventUser,
        Win32_ODBCAttribute,
        Win32_ODBCDataSourceAttribute,
        Win32_ODBCDataSourceSpecification,
        Win32_ODBCDriverAttribute,
        Win32_ODBCDriverSoftwareElement,
        Win32_ODBCDriverSpecification,
        Win32_ODBCSourceAttribute,
        Win32_ODBCTranslatorSpecification,
        Win32_OnBoardDevice,
        Win32_OperatingSystem,
        Win32_OperatingSystemQFE,
        Win32_OSRecoveryConfiguration,
        Win32_PageFile,
        Win32_PageFileElementSetting,
        Win32_PageFileSetting,
        Win32_PageFileUsage,
        Win32_ParallelPort,
        Win32_Patch,
        Win32_PatchFile,
        Win32_PatchPackage,
        Win32_PCMCIAController,
        Win32_Perf,
        Win32_PerfRawData,
        Win32_PerfRawData_ASP_ActiveServerPages,
        Win32_PerfRawData_ASPNET_114322_ASPNETAppsv114322,
        Win32_PerfRawData_ASPNET_114322_ASPNETv114322,
        Win32_PerfRawData_ASPNET_ASPNET,
        Win32_PerfRawData_ASPNET_ASPNETApplications,
        Win32_PerfRawData_IAS_IASAccountingClients,
        Win32_PerfRawData_IAS_IASAccountingServer,
        Win32_PerfRawData_IAS_IASAuthenticationClients,
        Win32_PerfRawData_IAS_IASAuthenticationServer,
        Win32_PerfRawData_InetInfo_InternetInformationServicesGlobal,
        Win32_PerfRawData_MSDTC_DistributedTransactionCoordinator,
        Win32_PerfRawData_MSFTPSVC_FTPService,
        Win32_PerfRawData_MSSQLSERVER_SQLServerAccessMethods,
        Win32_PerfRawData_MSSQLSERVER_SQLServerBackupDevice,
        Win32_PerfRawData_MSSQLSERVER_SQLServerBufferManager,
        Win32_PerfRawData_MSSQLSERVER_SQLServerBufferPartition,
        Win32_PerfRawData_MSSQLSERVER_SQLServerCacheManager,
        Win32_PerfRawData_MSSQLSERVER_SQLServerDatabases,
        Win32_PerfRawData_MSSQLSERVER_SQLServerGeneralStatistics,
        Win32_PerfRawData_MSSQLSERVER_SQLServerLatches,
        Win32_PerfRawData_MSSQLSERVER_SQLServerLocks,
        Win32_PerfRawData_MSSQLSERVER_SQLServerMemoryManager,
        Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationAgents,
        Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationDist,
        Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationLogreader,
        Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationMerge,
        Win32_PerfRawData_MSSQLSERVER_SQLServerReplicationSnapshot,
        Win32_PerfRawData_MSSQLSERVER_SQLServerSQLStatistics,
        Win32_PerfRawData_MSSQLSERVER_SQLServerUserSettable,
        Win32_PerfRawData_NETFramework_NETCLRExceptions,
        Win32_PerfRawData_NETFramework_NETCLRInterop,
        Win32_PerfRawData_NETFramework_NETCLRJit,
        Win32_PerfRawData_NETFramework_NETCLRLoading,
        Win32_PerfRawData_NETFramework_NETCLRLocksAndThreads,
        Win32_PerfRawData_NETFramework_NETCLRMemory,
        Win32_PerfRawData_NETFramework_NETCLRRemoting,
        Win32_PerfRawData_NETFramework_NETCLRSecurity,
        Win32_PerfRawData_Outlook_Outlook,
        Win32_PerfRawData_PerfDisk_PhysicalDisk,
        Win32_PerfRawData_PerfNet_Browser,
        Win32_PerfRawData_PerfNet_Redirector,
        Win32_PerfRawData_PerfNet_Server,
        Win32_PerfRawData_PerfNet_ServerWorkQueues,
        Win32_PerfRawData_PerfOS_Cache,
        Win32_PerfRawData_PerfOS_Memory,
        Win32_PerfRawData_PerfOS_Objects,
        Win32_PerfRawData_PerfOS_PagingFile,
        Win32_PerfRawData_PerfOS_Processor,
        Win32_PerfRawData_PerfOS_System,
        Win32_PerfRawData_PerfProc_FullImage_Costly,
        Win32_PerfRawData_PerfProc_Image_Costly,
        Win32_PerfRawData_PerfProc_JobObject,
        Win32_PerfRawData_PerfProc_JobObjectDetails,
        Win32_PerfRawData_PerfProc_Process,
        Win32_PerfRawData_PerfProc_ProcessAddressSpace_Costly,
        Win32_PerfRawData_PerfProc_Thread,
        Win32_PerfRawData_PerfProc_ThreadDetails_Costly,
        Win32_PerfRawData_RemoteAccess_RASPort,
        Win32_PerfRawData_RemoteAccess_RASTotal,
        Win32_PerfRawData_RSVP_ACSPerRSVPService,
        Win32_PerfRawData_Spooler_PrintQueue,
        Win32_PerfRawData_TapiSrv_Telephony,
        Win32_PerfRawData_Tcpip_ICMP,
        Win32_PerfRawData_Tcpip_IP,
        Win32_PerfRawData_Tcpip_NBTConnection,
        Win32_PerfRawData_Tcpip_NetworkInterface,
        Win32_PerfRawData_Tcpip_TCP,
        Win32_PerfRawData_Tcpip_UDP,
        Win32_PerfRawData_W3SVC_WebService,
        Win32_PhysicalMemory,
        Win32_PhysicalMemoryArray,
        Win32_PhysicalMemoryLocation,
        Win32_PNPAllocatedResource,
        Win32_PnPDevice,
        Win32_PnPEntity,
        Win32_PointingDevice,
        Win32_PortableBattery,
        Win32_PortConnector,
        Win32_PortResource,
        Win32_POTSModem,
        Win32_POTSModemToSerialPort,
        Win32_PowerManagementEvent,
        Win32_Printer,
        Win32_PrinterConfiguration,
        Win32_PrinterController,
        Win32_PrinterDriverDll,
        Win32_PrinterSetting,
        Win32_PrinterShare,
        Win32_PrintJob,
        Win32_PrivilegesStatus,
        Win32_Process,
        Win32_Processor,
        Win32_ProcessStartup,
        Win32_Product,
        Win32_ProductCheck,
        Win32_ProductResource,
        Win32_ProductSoftwareFeatures,
        Win32_ProgIDSpecification,
        Win32_ProgramGroup,
        Win32_ProgramGroupContents,
        Win32_ProgramGroupOrItem,
        Win32_Property,
        Win32_ProtocolBinding,
        Win32_PublishComponentAction,
        Win32_QuickFixEngineering,
        Win32_Refrigeration,
        Win32_Registry,
        Win32_RegistryAction,
        Win32_RemoveFileAction,
        Win32_RemoveIniAction,
        Win32_ReserveCost,
        Win32_ScheduledJob,
        Win32_SCSIController,
        Win32_SCSIControllerDevice,
        Win32_SecurityDescriptor,
        Win32_SecuritySetting,
        Win32_SecuritySettingAccess,
        Win32_SecuritySettingAuditing,
        Win32_SecuritySettingGroup,
        Win32_SecuritySettingOfLogicalFile,
        Win32_SecuritySettingOfLogicalShare,
        Win32_SecuritySettingOfObject,
        Win32_SecuritySettingOwner,
        Win32_SelfRegModuleAction,
        Win32_SerialPort,
        Win32_SerialPortConfiguration,
        Win32_SerialPortSetting,
        Win32_Service,
        Win32_ServiceControl,
        Win32_ServiceSpecification,
        Win32_ServiceSpecificationService,
        Win32_SettingCheck,
        Win32_Share,
        Win32_ShareToDirectory,
        Win32_ShortcutAction,
        Win32_ShortcutFile,
        Win32_ShortcutSAP,
        Win32_SID,
        Win32_SMBIOSMemory,
        Win32_SoftwareElement,
        Win32_SoftwareElementAction,
        Win32_SoftwareElementCheck,
        Win32_SoftwareElementCondition,
        Win32_SoftwareElementResource,
        Win32_SoftwareFeature,
        Win32_SoftwareFeatureAction,
        Win32_SoftwareFeatureCheck,
        Win32_SoftwareFeatureParent,
        Win32_SoftwareFeatureSoftwareElements,
        Win32_SoundDevice,
        Win32_StartupCommand,
        Win32_SubDirectory,
        Win32_SystemAccount,
        Win32_SystemBIOS,
        Win32_SystemBootConfiguration,
        Win32_SystemDesktop,
        Win32_SystemDevices,
        Win32_SystemDriver,
        Win32_SystemDriverPNPEntity,
        Win32_SystemEnclosure,
        Win32_SystemLoadOrderGroups,
        Win32_SystemLogicalMemoryConfiguration,
        Win32_SystemMemoryResource,
        Win32_SystemNetworkConnections,
        Win32_SystemOperatingSystem,
        Win32_SystemPartitions,
        Win32_SystemProcesses,
        Win32_SystemProgramGroups,
        Win32_SystemResources,
        Win32_SystemServices,
        Win32_SystemSetting,
        Win32_SystemSlot,
        Win32_SystemSystemDriver,
        Win32_SystemTimeZone,
        Win32_SystemUsers,
        Win32_TapeDrive,
        Win32_TemperatureProbe,
        Win32_Thread,
        Win32_TimeZone,
        Win32_Trustee,
        Win32_TypeLibraryAction,
        Win32_UninterruptiblePowerSupply,
        Win32_USBController,
        Win32_USBControllerDevice,
        Win32_UserAccount,
        Win32_UserDesktop,
        Win32_VideoConfiguration,
        Win32_VideoController,
        Win32_VideoSettings,
        Win32_VoltageProbe,
        Win32_WMIElementSetting,
        Win32_WMISetting,
    }
    #endregion Info / Demo Code
}
