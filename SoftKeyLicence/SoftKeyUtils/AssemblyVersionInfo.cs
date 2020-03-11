/////////////////////////////////////////////////////////////////////////
//   Change history:
//       1.Draft.      -- Jack Yang Oct. 18,2004 
//
/////////////////////////////////////////////////////////////////////////                   //                                                           
//       Centralized Attributes for Metron 1.1               
//                                                           
//     As a group discussion result,Following sections of assembly information
//     have been centraized into AssemblyVersionInfo:
//     1.Commom General Information about an assembly.
//     2.Version number.
//     3.Strong Name related attributes.
//
//     Notes:Three almost identical AssemblyVersionInfo.
//           1.AssemblyVersionInfo.cs           
//           2.AssemblyVersionInfo.vb           
//           3.AssemblyVersionInfo.cpp            
//cs 11358 --  
/////////////////////////////////////////////////////////////////////////                                                          
                                                           
                                                           
#undef SIGN_MODE_NONE
#undef SIGN_MODE_DELAY
#undef SIGN_MODE_STRONG

#define SIGN_MODE_STRONG

#undef COMPILE_AccExpectedDBVersionAttribute
#if THIS_IS_ACCAPPBLOCKS
#define COMPILE_AccExpectedDBVersionAttribute
#define IGNORE_InFxCopCodeValidation
#endif
#if THIS_IS_ACCCLR
#define COMPILE_AccExpectedDBVersionAttribute
#endif
#if THIS_IS_ACLogBrowser
#define COMPILE_AccExpectedDBVersionAttribute
#endif
#if THIS_IS_ACCDBPatcher
#define COMPILE_AccExpectedDBVersionAttribute
#endif


using System;
using System.Reflection;
using System.Runtime.CompilerServices;

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//

[assembly: AssemblyVersion("0.0.0.48945")] //8f75e02d-a9a8-47c9-91a8-d0cdf5472739
[assembly: AssemblyFileVersion("0.0.0.48945")] //b97ef342-1c81-4699-af4a-ded79b3aeff4

//[assembly: AccExpectedDBVersion(0, 0, 0, 48945)] //3a3416d4-90c9-4b0e-925d-5f26808a41ae

//If you bamp up  AccExpectedDBVersion please put below the following:
//Which areas are affected
//What is the way to update the DB to syncronize it with the code. Example: add column blah to table blah blah, run temporalis, etc.
//As the part of the build process I will be removing all comments below (since they will be in the released DB) 

//@cmnt sdrobner: [16 August 12, 16:01:58]   [120816_160158]
//[assembly: AccExpectedClientVersion("6.0.1.41791")] //6299900e-489a-4367-a0c9-d79650cd23e9

[assembly: AssemblyCompany("Trimble Navigation Limited")] 
[assembly: AssemblyCopyright ("Copyright © Trimble Navigation Limited, 2002-2013")] //This is used in some about & splash screens
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]		 

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

#if SIGN_MODE_NONE
[assembly : AssemblyDelaySign(false)]
[assembly : AssemblyKeyFile("")]
#elif SIGN_MODE_DELAY
	[assembly : AssemblyDelaySign(true)]
[assembly: AssemblyKeyFile("S:\\WinDev32\\Enterprise_v3_00\\3_0_Features\\Source\\MasterKeyPair.dat")]
#elif SIGN_MODE_STRONG
[assembly : AssemblyDelaySign(false)]

//sn -k AccKey_5_0.snk 

#pragma warning disable 1699
// the following has to be run to install key to container
//sn -i C:\Dev\Enterprise_Dev\Source\MasterKeyPair.dat AccKey_Dev    
[assembly: AssemblyKeyName("AccKey_6_0_0")]
#pragma warning restore 1699

#endif




#if COMPILE_AccExpectedDBVersionAttribute


[AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
public class AccExpectedDBVersionAttribute : Attribute
{
    private int m_iMajor;
    private int m_iMinor;
    private int m_iBuild;
    private int m_iRevision;

	public AccExpectedDBVersionAttribute(int iMajor, int iMinor, int iRevision, int iBuild)
    {
        m_iMajor = iMajor;
        m_iMinor = iMinor;
        m_iBuild = iBuild;
        m_iRevision = iRevision;
    }


    public int Major
    {
        get
        {
            return m_iMajor;
        }
        set
        {
            m_iMajor = value;
        }
    }
    public int Minor
    {
        get
        {
            return m_iMinor;
        }
        set
        {
            m_iMinor = value;
        }
    }
    public int Build
    {
        get
        {
            return m_iBuild;
        }
        set
        {
            m_iBuild = value;
        }
    }
    public int Revision
    {
        get
        {
            return m_iRevision;
        }
        set
        {
            m_iRevision = value;
        }
	}

}

#region @cmnt sdrobner: [16 August 12, 16:00:59]   [120816_160059]

////AssemblyVersion("5.0.1.5935")]
//[AttributeUsage(AttributeTargets.Assembly, Inherited = false, AllowMultiple = false)]
//public //class AccExpectedClientVersionAttribute : Attribute
//{
	//private string m_strVersion;

	//public AccExpectedClientVersionAttribute(string strVersion)
	//{
		//m_strVersion = strVersion;
	//}

	//public string Version
	//{
		//get
		//{
			//return m_strVersion;
		//}
		//set
		//{
			//m_strVersion = value;
		//}
	//}
//}

 #endregion @cmnt sdrobner: [16 August 12, 16:00:59]   [120816_160059]


#endif



#if IGNORE_InFxCopCodeValidation
public class AccIgnoreForFXCopValidation : Attribute
{
	private string m_strReason;

	public AccIgnoreForFXCopValidation(string strReason)
	{
		m_strReason  = strReason;
	}

	public string Reason
	{
		get
		{
			return m_strReason;
		}
	}
}

#endif
