using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Sample.Utility
{
    public class AppMethods
    {
        static ObjectCache cache = MemoryCache.Default;

        public static string EncryptPassword(string password)
        {
            //to do: encrypt the password using some hashing algorithm
            return password; 
        }

        public static string EncryptPassword(string inputPassword, string EncryptedPassword)
        {
            //to do : compare encrypted the password using some hashing algorithm

            return inputPassword;
        }

        public static string SerializeToXml<T>(T obj)
        {
            string result = string.Empty;
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                StringWriter writer = new StringWriter();
                ser.Serialize(writer, obj);
                result = writer.ToString();
                writer.Close();
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
            return result;
        }

        public static T DeserializeFromXml<T>(string xml)
        {
            T result;
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (TextReader tr = new StringReader(xml))
            {
                result = (T)ser.Deserialize(tr);
            }
            return result;
        }

        public static Dictionary<int, string> GenderList()
        {
            var genderList = new Dictionary<int, string>();

            foreach (Gender e in Enum.GetValues(typeof(Gender)))
            {
                genderList.Add((int)e, Enum.GetName(typeof(Gender), e));
            }

            return genderList;
        }

        public static Dictionary<int, string> NationalityList()
        {
            var nationalityList = new Dictionary<int, string>();

            foreach (Nationality e in Enum.GetValues(typeof(Nationality)))
            {
                nationalityList.Add((int)e, Enum.GetName(typeof(Nationality), e));
            }

            return nationalityList;
        }

        public static string TransformXmlToHtml(string inputXml, string xsltFilePath)
        {
            string result = string.Empty;
            try
            {
                StringWriter stringWriter = new StringWriter();

                XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
                XsltSettings settings = new XsltSettings();
                settings.EnableScript = true;

                xslCompiledTransform.Load(xsltFilePath, settings, null);

                XPathDocument doc = new XPathDocument(new StringReader(inputXml));

                using (StringWriter sw = new StringWriter())
                {
                    xslCompiledTransform.Transform(doc, null, sw);
                    result = sw.ToString();
                }
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return result;
        }

        public static string HtmlStringToPdfFile(string pdfOutputLocation, string outputFilename, string htmlData, string pdfHtmlToPdfExePath)
        {
            System.IO.StreamWriter stdin;
            try
            {
                //Determine inputs
                if (string.IsNullOrEmpty(htmlData))
                {
                    //log.Info("No input string is provided for HtmlToPdf.");
                    throw new Exception("No input string is provided for HtmlToPdf");
                }

               // string outputFolder = pdfOutputLocation;
                //log.Info("pdf Generation initiated.");

                var p = new System.Diagnostics.Process()
                {
                    StartInfo =
                    {
                        FileName = AppProperties.BasePhysicalPath + pdfHtmlToPdfExePath,
                        Arguments = "-q -n - " + outputFilename,
                        UseShellExecute = false, // needs to be false in order to redirect output
                        CreateNoWindow = true,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                        WorkingDirectory = AppProperties.BasePhysicalPath +pdfOutputLocation
                    }
                };
                p.Start();
                //log.Info("pdf Generation Started.");

                stdin = new StreamWriter(p.StandardInput.BaseStream, Encoding.UTF8);
                stdin.AutoFlush = true;
                stdin.Write(htmlData);
                stdin.Close();
                //log.Info("pdf Generated.");

                // read the output here...
                var output = p.StandardOutput.ReadToEnd();
                var errorOutput = p.StandardError.ReadToEnd();

                // ...then wait n milliseconds for exit (as after exit, it can't read the output)
                p.WaitForExit(60000);

                // read the exit code, close process
                int returnCode = p.ExitCode;
                p.Close();
                p.Dispose();
                p.Refresh();
                // if 0 or 2, it worked so return path of pdf
                if ((returnCode == 0) || (returnCode == 2))
                    return outputFilename;
                else
                    throw new Exception(errorOutput);
            }
            catch (Exception exc)
            {
                //log.Info("Problem generating PDF from HTML string." + exc.Message);

                throw new Exception("Problem generating PDF from HTML string, outputFilename: " + outputFilename, exc);
            }
        }

        public static T GetCache<T>(string key) where T : class
        {
            if(cache.Contains(key)) { 
                return (T)cache[key];
            }
            else{
                return null;
            }
        }

        public static void AddCache(string key,object value)
        {
            try
            {
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddHours(1.0);
                if (!cache.Contains(key))
                {
                    cache.Add(key, value, policy);
                }
            }
            catch
            {
            }
        }

        public static Guid GetGuid(string value)
        {
            var result = default(Guid);
            Guid.TryParse(value, out result);
            return result;
        }

        public static string GetHash(string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            byte[] byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }

        public static string CorrectCollectionName(string className)
        {
            return className.Replace("EntityModel", "");
        }
    }
}
