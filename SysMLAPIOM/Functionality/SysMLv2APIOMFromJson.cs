using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;
using static SysMLAPIOM.Functionality.SysMLv2Validator;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SysMLAPIOM.Functionality
{
    public class SysMLv2APIOMFromJson
    {

        public static Project ProjectJson2AOm(string jsonData)
        {
            Project project = Newtonsoft.Json.JsonConvert.DeserializeObject<Project>(jsonData);
            return project;
        }

        public static List<Project> ProjectsJson2AOm(string jsonData)
        {
            List<Project> projects = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Project>>(jsonData);
            return projects;
        }

        public static List<Commit> CommitsJson2AOm(string jsonData)
        {
            List<Commit> commits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Commit>>(jsonData);
            return commits;
        }

        public static Tuple<List<Element>, List<object>, List<int>> ElementsJson2AOm(string jsonData)
        {

            List<JObject> preElements = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JObject>>(jsonData);
            int error_count = 0;
            List<object> errors = new List<object>();

            // Validation JSONS
            string classesData = System.IO.File.ReadAllText("..\\SysMLAPIOM\\Jsons\\Validation_jsons\\schema.json");
            string enumsData = System.IO.File.ReadAllText("..\\SysMLAPIOM\\Jsons\\Validation_jsons\\enums.json");

            Dictionary< string, JObject > classes = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, JObject>>(classesData);
            Dictionary<string, List<string>> enums = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(enumsData);

            List<int> errorsIDs = new List<int>();
            int index = 0;
            foreach (JObject element in preElements)
            {
                
                var dict = readJson(element);
                string type = dict["@type"].Split("?")[0];
                
                // Schema Extraction and parsing
                var schemaJobject = classes[type];
                var schema = readSchema(schemaJobject);

                
                

                
                // Validation of the Json with the corresponding schema
                var validationErrors = ValidateSchema(schema, dict, enums);
                
                if (validationErrors.Any())
                {
                    foreach (object valError in validationErrors)
                    {
                        errorsIDs.Add(index);
                    }
                    
                    errors.Add(validationErrors);
                    

                }
                error_count += errors.Count;
                index++;
            }
            if (error_count == 0)
            {
                //Replace

                string todayDateTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string pattern = @"(?<!@)type";
                string replacement = $"type{todayDateTime}";
                string result = Regex.Replace(jsonData, pattern, replacement);
                List<Element> commits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Element>>(result);
                return Tuple.Create(commits, new List<object>(), errorsIDs);
            }
            else { return Tuple.Create(new List<Element>(), errors, errorsIDs); }

        }
    }
}
