using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace CSV_HTML_to_Text
{
    class Program
    {
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

                Convert_CSV_HTM_toText(args[0], args[1]);

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);

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
            Console.WriteLine("The CSV_HTML_to_Text convers HTML script into plane text in CSV files");
            Console.WriteLine("If the output *.csv file exists it will be overwritten.");
            Console.WriteLine("---------------------------------------------------------------------------------------\r\n");
        }

        static void Convert_CSV_HTM_toText(string _fIn, string _fOut)
        {
            try
            {
                StringBuilder sbOut = new StringBuilder();

                using (StreamReader reader = new StreamReader(_fIn))
                {
                    string sLine = string.Empty;

                    while (reader.EndOfStream == false)
                    {
                        sLine = reader.ReadLine();

                        //sbOut.AppendLine(ProcessLine(sLine));

                        sbOut.AppendLine(sLine.StripHTML(true));
                    }
                }

                File.WriteAllText(_fOut, sbOut.ToString());

                Console.WriteLine(string.Format("The file {0} was created.", _fOut));
            
            }
            catch (Exception exp)
            {
                //Logger.WriteErrorLogOnly(exp, "d75bb75a-fd06-4250-9c4d-34b899122880");
                Console.WriteLine(exp.Message);
            }
        }

        static string ProcessLine(string _sLine)
        {
            try
            {
                String[] sLineValues = null;
                StringBuilder sbTemp = new StringBuilder();
                string sSeparator = string.Empty;

                sLineValues = _sLine.Split(',');

                if (sLineValues.Length == 0)
                {
                    sLineValues = _sLine.Split('\t');

                    if (sLineValues.Length == 0)
                    {
                        throw new Exception("Undefined CSV separator. (Neither ',' nor 'TAB' is not found).");
                    }
                    else
                    {
                        sSeparator = "\t";
                    }
                }
                else
                {
                    sSeparator = ",";
                }

                for (int i = 0; i < sLineValues.Length; i++)
                {
                    if (string.IsNullOrEmpty(sLineValues[i]) == false)
                    {
                        if (i < sLineValues.Length - 1)
                        {
                            sbTemp.AppendFormat("{0}{1}", sLineValues[i].StripHTML(true), sSeparator);
                        }
                        else
                        {
                            sbTemp.AppendFormat("{0}", sLineValues[i].StripHTML(true));
                        }
                    }
                }

                return sbTemp.ToString();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }        
    }

    public static class Utils
    {
        public static string StripHTML(this string _HTMLText, bool _bDecode = true)
        {
            Regex reg = new Regex("<[^>]+>", RegexOptions.IgnoreCase);
            var stripped = reg.Replace(_HTMLText, "");
            return _bDecode ? HttpUtility.HtmlDecode(stripped) : stripped;
        }
    }
}
