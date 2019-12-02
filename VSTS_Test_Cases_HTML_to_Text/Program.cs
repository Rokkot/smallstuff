using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace VSTS_Test_Cases_HTML_to_Text
{
    class Program
    {
        private const string C_SEPARATOR = "\",\"";

        private const string C_STEPS_START = "<steps id=";
        private const string C_STEPS_END = "/steps>";

        private const string C_STEP_START = "<step id=";
        private const string C_STEP_END = "/step>";

        private const string C_STEP_SECTION_START = "<parameterizedString isformatted=";
        private const string C_STEP_SECTION_END = "/parameterizedString>";

        private static bool m_bIsInDebugMode = false;

        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    Info();
                    return;
                }

                Info();

                if (File.Exists(args[0]) == false)
                {
                    throw new Exception(string.Format("File '{0}' does not exist.", args[0]));
                }

                if (File.Exists(args[1]) == true)
                {
                    Console.WriteLine(string.Format("The file '{0}' will be deleted.", args[1]));

                    File.Delete(args[1]);
                }

                if ((args.Length == 3) && ((args[2] == "-d") || (args[2] == "-D")))
                {
                    m_bIsInDebugMode = true;
                }

                Convert_CSV_HTM_toText(args[0], args[1]);

            }
            catch (Exception exp)
            {
                WriteError(exp.Message, "0c9c4632-e2c1-4e1b-ba76-efa81b2e0cf8");

            }
            finally
            {
                Console.WriteLine("\r\n\r\nPress any key to exit.");
                Console.ReadKey();
            }
        }

        static void Info()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("The VSTS_Test_Cases_HTML_to_Text convers HTML script into plane text in CSV files");
            Console.WriteLine("VSTS_Test_Cases_HTML_to_Text.exe [path to a CSV file that needs to be converted] [path to the output file]");
            Console.WriteLine("If the output *.csv file exists it will be overwritten.");
            Console.WriteLine("---------------------------------------------------------------------------------------\r\n");
        }

        static void Convert_CSV_HTM_toText(string _fIn, string _fOut)
        {
            try
            {
                int ilineIndex = 1;

                StringBuilder sbOut = new StringBuilder();

                using (StreamReader reader = new StreamReader(_fIn))
                {
                    string sLine = string.Empty;
                    string sCsvLine = string.Empty;

                    sLine = reader.ReadLine();

                    sbOut.AppendFormat("{0},\"Result\"", sLine);
                    sbOut.AppendLine();

                    while (reader.EndOfStream == false)
                    {
                        sLine = reader.ReadLine();

                        if (m_bIsInDebugMode == true)
                        {
                            Console.Write(ilineIndex.ToString());
                            Console.Write(": ");
                            Console.WriteLine(sLine);
                        }

                        sCsvLine += sLine;

                        if (HasTag(sCsvLine, C_STEPS_START) == true)
                        {
                            if (HasTag(sCsvLine, C_STEPS_END) == false)
                            {
                                continue;
                            }
                        }

                        sbOut.AppendLine(ProcessLine(sCsvLine));

                        sCsvLine = string.Empty;

                        ilineIndex++;
                    }
                }

                File.WriteAllText(_fOut, sbOut.ToString());

                Console.WriteLine(string.Format("The file {0} was created.", _fOut));
            
            }
            catch (Exception exp)
            {
                WriteError(exp.Message, "c7e0c150-1a3a-433f-9c79-2969ae1a6720");
                throw exp;
            }
        }

        static string ProcessLine(string _sLine)
        {
            try
            {
                StringBuilder sbTemp = new StringBuilder();
                string sSeparator = string.Empty;
                string sSteps = string.Empty;

                if (HasTag(_sLine, C_STEPS_START))
                {
                    sSteps = _sLine.ExtractHTML_TAG(C_STEPS_START, C_STEPS_END);
                    _sLine = _sLine.Replace(sSteps, "");
                    _sLine = _sLine.Remove(_sLine.Length - 2,2);

                }

                List<Test> tests = ProcessSteps(sSteps);

                sbTemp.Append(_sLine);

                if ((tests != null) && (tests.Count > 0))
                {
                    sbTemp.AppendFormat("\"{0}\",\"{1}\"", tests[0].Step, tests[0].Result);

                    for (int i = 1; i < tests.Count; i++)
                    {
                        sbTemp.AppendLine("");
                        sbTemp.Append(_sLine);
                        sbTemp.AppendFormat("\"{0}\",\"{1}\"", tests[i].Step, tests[i].Result);
                    }
                }

                return sbTemp.ToString();
            }
            catch (Exception exp)
            {
                WriteError(exp.Message, "236d2c38-33c2-471b-ad64-b206acc7c9da");
                throw exp;
            }
        }

        private static bool HasTag(string _sCellText, string _sTagStart)
        {
            try
            {
                return (_sCellText.Contains(_sTagStart));
            }
            catch (Exception exp)
            {
                WriteError(exp.Message, "80cc694e-5cf3-4d87-824d-b525f748e52c");
                throw exp;
            }
        }

        private static List<Test> ProcessSteps(string _sSteps)
        {
            int kk = 0;

            try
            {
                string sStep = string.Empty;
                string sAction = string.Empty;
                string sResult = string.Empty;
                List<Test> lstTests = new List<Test>();

                while (_sSteps.IndexOf(C_STEP_START) > 0)
                {
                    sStep = _sSteps.ExtractHTML_TAG(C_STEP_START, C_STEP_END);

                    if (string.IsNullOrEmpty(sStep) == false)
                    {
                        _sSteps = _sSteps.Replace(sStep, "");
                    }

                    sAction = sStep.ExtractHTML_TAG(C_STEP_SECTION_START, C_STEP_SECTION_END);

                    if (string.IsNullOrEmpty(sAction) == false)
                    {
                        sStep = sStep.Replace(sAction, "");
                    }

                    sResult = sStep.ExtractHTML_TAG(C_STEP_SECTION_START, C_STEP_SECTION_END);

                    if (string.IsNullOrEmpty(sResult) == false)
                    {
                        sStep = sStep.Replace(sResult, "");
                    }

                    sAction = sAction.StripHTML();
                    sAction = sAction.HtmlToPlainText();

                    if (sAction.IsFirstCharMathOpernd() == true)
                    {
                        sAction = sAction.Insert(0, "\r\n ");
                    }

                    sResult = sResult.StripHTML();
                    sResult = sResult.HtmlToPlainText();

                    if (sResult.IsFirstCharMathOpernd() == true)
                    {
                        sResult = sResult.Insert(0, "\r\n ");
                    }

                    lstTests.Add(new Test(sAction, sResult));

                    kk++;
                }

                return lstTests;
            }
            catch (Exception exp)
            {
                WriteError(exp.Message, "38a9422e-392e-4a88-9269-1a3aea3c44b2 " + kk.ToString());
                throw exp;
            }
        }

        private static void WriteError(string _sMessage, string _sID)
        {
            Console.WriteLine(string.Format("ERROR {0}: {1})", _sID, _sMessage));
        }

        private class Test
        {
            public Test(string _sStep, string _sResult)
            {
                Step = _sStep;
                Result = _sResult;
            }

            public string Step { get; set; }
            public string Result { get; set; }

        }
    }

    public static class Utils
    {
        public static bool IsFirstCharMathOpernd(this string _sStr)
        {
            return ((string.IsNullOrEmpty(_sStr) == false)
                    && ((_sStr.Substring(0, 1) == "-")
                        || (_sStr.Substring(0, 1) == "+")
                        || (_sStr.Substring(0, 1) == "*")
                        || (_sStr.Substring(0, 1) == "=")));
        }

        public static string StripHTML(this string _HTMLText)
        {
            //Regex reg = new Regex("<[^>]*>", RegexOptions.IgnoreCase);
            Regex reg = new Regex(@"\<[^\>]*\>", RegexOptions.IgnoreCase);
            var stripped = reg.Replace(_HTMLText, "");
            return HttpUtility.HtmlDecode(stripped);
        }

        public static string HtmlToPlainText(this string html)
        {
            const string tagWhiteSpace = @"(>|$)(\W|\n|\r)+<";//matches one or more (white space or line breaks) between '>' and '<'
            const string stripFormatting = @"<[^>]*(>|$)";//match any character between '<' and '>', even when end tag is missing
            const string lineBreak = @"<(br|BR)\s{0,1}\/{0,1}>";//matches: <br>,<br/>,<br />,<BR>,<BR/>,<BR />
            Regex lineBreakRegex = new Regex(lineBreak, RegexOptions.Multiline);
            Regex stripFormattingRegex = new Regex(stripFormatting, RegexOptions.Multiline);
            Regex tagWhiteSpaceRegex = new Regex(tagWhiteSpace, RegexOptions.Multiline);

            var text = html;
            //Remove tag whitespace/line breaks
            text = tagWhiteSpaceRegex.Replace(text, "><");
            //Replace <br /> with line breaks
            text = lineBreakRegex.Replace(text, Environment.NewLine);
            //Strip formatting
            text = stripFormattingRegex.Replace(text, string.Empty);

            //Decode html specific characters
            text = System.Net.WebUtility.HtmlDecode(text);

            return text;
        }

        public static string ExtractHTML_TAG(this string _sText, string _sSubStrStart, string _sSubStrEnd)
        {
            int iStartOfStep = _sText.IndexOf(_sSubStrStart);
            int iStartOfEnd = _sText.IndexOf(_sSubStrEnd) + _sSubStrEnd.Length;

            if ((iStartOfStep >= 0) && (iStartOfEnd > 0) && (iStartOfEnd < _sText.Length))
            {
                return _sText.Substring(iStartOfStep, iStartOfEnd - iStartOfStep);
            }

            return string.Empty;
        }
    }
}
