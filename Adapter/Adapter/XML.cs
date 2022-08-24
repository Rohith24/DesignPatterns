using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Xml;

namespace Adapter
{
    public interface IXML
    {
        string ToString();
    }
    public class XML : IXML
    {
       public XmlDocument XmlDocument { get; set; }

        public XML(XmlDocument xmlDocument)
        {
            XmlDocument = xmlDocument;
        }

        public override string ToString()
        {
            return XmlDocument.ToString();
        }
    }

    public interface IJSON
    {
        string ToString();
    }

    public class JSON : IJSON
    {
        public JsonObject JsonObject { get; set; }

        public JSON(JsonObject jobject)
        {
            JsonObject = jobject;
        }

        public override string ToString()
        {
            return JsonObject.ToString();
        }
    }


    public class XMLToJSONAdapter : IJSON
    {
        JSON JSON;

        public XMLToJSONAdapter(XML xML)
        {
            JSON = new JSON(new JsonObject());//Convertion logic from xml to json 
        }
    }


    public  class Program
    {
        public static void DOSOMEJSONOppration(IJSON jSON)
        {

        }
        public static void Main()
        {
            XML xML = new XML(new XmlDocument());

            XMLToJSONAdapter xMLToJSONAdapter = new XMLToJSONAdapter(xML);

            DOSOMEJSONOppration(xMLToJSONAdapter);
        }
    }
}
