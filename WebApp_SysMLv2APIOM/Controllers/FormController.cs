using Microsoft.AspNetCore.Mvc;
using WebApp_SysMLv2APIOM.Models;
using SysMLv2APIOM;
using System;
using SysMLv2APIOM.Functionality;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;


namespace WebApp_SysMLv2APIOM.Controllers
{
    public class FormController : Controller
    {

        public IActionResult PathForm()
        {
            var model = new FormModel();
            return View(model);
        }

        private static int LevenshteinDistance(string str1, string str2)
        {
            var source1Length = str1.Length;
            var source2Length = str2.Length;

            var matrix = new int[source1Length + 1, source2Length + 1];

            // First calculation, if one entry is empty return full length
            if (source1Length == 0)
                return source2Length;

            if (source2Length == 0)
                return source1Length;

            // Initialization of matrix with row size source1Length and columns size source2Length
            for (var i = 0; i <= source1Length; matrix[i, 0] = i++) { }
            for (var j = 0; j <= source2Length; matrix[0, j] = j++) { }

            // Calculate rows and collumns distances
            for (var i = 1; i <= source1Length; i++)
            {
                for (var j = 1; j <= source2Length; j++)
                {
                    var cost = (str2[j - 1] == str1[i - 1]) ? 0 : 1;

                    matrix[i, j] = Math.Min(
                        Math.Min(matrix[i - 1, j] + 1, matrix[i, j - 1] + 1),
                        matrix[i - 1, j - 1] + cost);
                }
            }
            // return result
            return matrix[source1Length, source2Length];
        }
        private bool ValidatePath(string path)
        {
            // Validar que no sea nulo, vacío o que cumpla con ciertas reglas
            return !string.IsNullOrEmpty(path) && path.Contains("\\");
        }


        public static void ParseJson(string jsonData, FormModel model)
        {
            object apiModelObjects = null;
            List<object> errors = null;
            List<int> errorsIDs = null;
            string type = "";

            if (jsonData.Contains("previousCommit"))
            {
                type = "Commit";
            }
            else if (jsonData.Contains("defaultBranch"))
            {
                type = "Project";
            }
            else
            {
                type = "Element";
            }

            if (type == "Project")
            {
                try
                {
                    apiModelObjects = SysMLAPIOM.Functionality.SysMLv2APIOMFromJson.ProjectJson2AOm(jsonData);
                    model.ParsedObjects = JsonConvert.SerializeObject(apiModelObjects, Newtonsoft.Json.Formatting.Indented) ?? "No data was parsed.";
                }
                catch
                {
                    apiModelObjects = SysMLAPIOM.Functionality.SysMLv2APIOMFromJson.ProjectsJson2AOm(jsonData);
                    model.ParsedObjects = JsonConvert.SerializeObject(apiModelObjects, Newtonsoft.Json.Formatting.Indented) ?? "No data was parsed.";
                }

            }
            else if (type == "Commit")
            {
                apiModelObjects = SysMLAPIOM.Functionality.SysMLv2APIOMFromJson.CommitsJson2AOm(jsonData);
                model.ParsedObjects = JsonConvert.SerializeObject(apiModelObjects, Newtonsoft.Json.Formatting.Indented) ?? "No data was parsed.";
            }
            else
            {
                var result = SysMLAPIOM.Functionality.SysMLv2APIOMFromJson.ElementsJson2AOm(jsonData);
                apiModelObjects = result.Item1;
                errors = result.Item2;
                errorsIDs = result.Item3;

                model.ParsedObjects = JsonConvert.SerializeObject(apiModelObjects, Newtonsoft.Json.Formatting.Indented) ?? "No data was parsed.";

                model.ParsedErrors = JsonConvert.SerializeObject(errors, Newtonsoft.Json.Formatting.Indented) ?? "No errors were found.";

                try
                {
                    var nestedList = JsonConvert.DeserializeObject<List<List<Dictionary<string, string>>>>(model.ParsedErrors);
                    List<Dictionary<string, string>> flatList = nestedList.SelectMany(list => list).ToList();
                    model.toPrintErrors = flatList;

                }

                catch
                {
                    Console.WriteLine();
                }

                model.errorsIDs = errorsIDs;



                // Suggestions Computation
                Dictionary<string, string> suggestions = new Dictionary<string, string>();
                List<object> list = (List<object>)errors;
                int count = -1;
                foreach (var item in list)
                {
                    count += 1;
                    
                    List<KeyValuePair<string, string>> secondList = (List<KeyValuePair<string, string>>)item;
                    for (int i = 0; i < secondList.Count; i++)
                    {
                        List<(int index, int distance)> levenshteinDistances = new List<(int, int)>();
                        var error = secondList[i];
                        string typeOfError = error.Value;
                        if (typeOfError == "The attribute is not valid")
                        {
                            string keyToCompare = error.Key;
                            List<JObject> preElements = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JObject>>(jsonData);
                            var element = preElements[count];
                            var dict = SysMLAPIOM.Functionality.SysMLv2Validator.readJson(element);
                            string type2 = dict["@type"].Split("?")[0];

                            
                            string classesData = System.IO.File.ReadAllText("..\\..\\SysMLv2APIOM\\SysMLAPIOM\\Jsons\\Validation_jsons\\schema.json");
                            Dictionary<string, JObject> classes = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, JObject>>(classesData);

                            var schemaJobject = classes[type2];
                            var schema = SysMLAPIOM.Functionality.SysMLv2Validator.readSchema(schemaJobject);


                            foreach (var kvp in schema)
                            {
                                int distance = LevenshteinDistance(keyToCompare, kvp.Key);

                                // Almacenar el índice y la distancia
                                levenshteinDistances.Add((i, distance));
                            }

                            var min = levenshteinDistances
                                                .Select((x, index) => new { x.distance, x.index })
                                                .Min(x => x.distance);

                            if (min <= 3)
                            {

                                var minIndex = levenshteinDistances
                                                    .Select((x, index) => new { x.distance, index })
                                                    .Where(x => x.distance == min)
                                                    .Select(x => x.index)
                                                    .FirstOrDefault();
                                var suggestedKey = schemaJobject.Properties().Skip(minIndex).FirstOrDefault()?.Name;

                                if (!suggestions.ContainsKey(keyToCompare))
                                {
                                    suggestions.Add(keyToCompare, suggestedKey);
                                }
                            }
                            else
                            {
                                suggestions.Add(keyToCompare, "-");
                            }


                        }
                    }
                    model.toPrintSuggestions = suggestions;
                    model.Suggestions = JsonConvert.SerializeObject(suggestions, Newtonsoft.Json.Formatting.Indented) ?? "No suggestions."; ;
                    
                }



            }

        }


        [HttpPost]
        public IActionResult SubmitPath(FormModel model)
        {
            Console.WriteLine(ModelState.IsValid);
            if (ModelState.IsValid)
            {
                // Process the submitted path here
                // For example, you can print it to the console or do something else
                Console.WriteLine($"User submitted path: {model.Path}");
                bool isValid = ValidatePath(model.Path);
                

                if (!isValid) 
                {
                    ModelState.AddModelError(string.Empty, "Invalid path format.");
                    var errorModel = new ErrorViewModel();
                    return View("Error", errorModel);
                }

                else
                {
                    
                    string jsonData = System.IO.File.ReadAllText(model.Path);
                    
                    ParseJson(jsonData, model);
                   

                    return View("PathForm", model);
                }

                
            }

            // If the model is invalid, re-display the form with validation errors
            return View("PathForm", model);
        }
    }
}


