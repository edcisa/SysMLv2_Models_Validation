using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.Design;
using System.Text.Json;


namespace SysMLAPIOM.Functionality
{
    public class SysMLv2Validator
    {
        public static Dictionary<String, String> readJson(JObject json)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            foreach (var property in json.Properties())
            {
                string value;
               
                if (property.Value.Type == JTokenType.Null)
                {
                    value = "null";
                }
                else
                {
                    value = property.Value.ToString();
                }

                string newString = value + "?" + property.Value.Type.ToString();

                data[property.Name] = newString;
            }

            return data;

        }

        public static Dictionary<String, String> readSchema(JObject json)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            foreach (var property in json.Properties())
            {
                string value;
                if (property.Value.Type == JTokenType.Array)
                {
                    value = "[]";
                }
                else if (property.Value.Type == JTokenType.Null)
                {
                    value = "null";
                }
                else
                {
                    value = property.Value.ToString();
                }


                data[property.Name] = value;
            }

            return data;
        }

        public static Boolean validateKeys(Dictionary<String, String> data, Dictionary<String, String> schema)
        {
            var dataKeys = new HashSet<string>(data.Keys);
            var schemaKeys = new HashSet<string>(schema.Keys);

            // Verifica si todas las claves de data están en schema
            return dataKeys.IsSubsetOf(schemaKeys);
        }

        public static List<KeyValuePair<string, string>> ValidateSchema(Dictionary<string, string> schema, Dictionary<string, string> data, Dictionary<string, List<string>> enums)
        {
            var errors = new List<KeyValuePair<string, string>>();
            var enumKeys = enums.Keys;

            foreach (var kvp in data)
            {
                string fullValue = kvp.Value;
                string key = kvp.Key;

                string value = fullValue.Split("?")[0];
                string type = fullValue.Split("?")[1];

                if (key == "@type") { continue; }

                else
                {
                    try
                    {
                        string fulltoCheck = schema[key];
                        string toCheck = fulltoCheck.Split("?")[0];
                        string cardinality = fulltoCheck.Split("?")[1];

                        if (key == "aliasIds")
                        {
                            continue;
                        }

                        else if (toCheck == "int")
                        {
                            if (type!= "Integer")
                            {
                                errors.Add(new KeyValuePair<string, string>($"{key}: {value}", "Type must be an Integer"));

                            }

                        }

                        else if (toCheck == "double")
                        {
                            if (type != "Float" && type != "Double")
                            {
                                errors.Add(new KeyValuePair<string, string>($"{key}: {value}", "Type must be Float or Double"));

                            }

                        }



                        else if (toCheck == "string")
                        {
                            if (key != "operator")
                            {
                                if (value.StartsWith("[") || value.StartsWith("{") || value.EndsWith("]") || value.EndsWith("}"))
                                {
                                    errors.Add(new KeyValuePair<string, string>($"{key}: {value}", "The value must be a string"));
                                }
                                else if (key == "elementId" || key == "@id")
                                {
                                    if (Guid.TryParse(value, out var guid) == false)
                                    {
                                        
                                        errors.Add(new KeyValuePair<string, string>($"{key}: {value}", "The format of the ID is not valid"));

                                    }
                                }
                            }
                        }
                        else if (toCheck == "boolean")
                        {
                            if (value != "False" && value != "True")
                            {
                                errors.Add(new KeyValuePair<string, string>($"{key}: {value}", "The value is not a boolean"));
                            }

                        }
                        else
                        {
                            // We check if there is an ENUM type
                            if (enumKeys.Contains(toCheck))
                            {
                                var possiblesValues = enums[toCheck];
                               
                                if (!(possiblesValues.Contains(value)))
                                {
                                    string fullString = "";
                                    foreach(string p in possiblesValues)
                                    {
                                        fullString += p + " ";
                                    }
                                    errors.Add(new KeyValuePair<string, string>($"{key}: {value}", $"The value should be contained in: {fullString}"));
                                }
                            }

                            // No ENUM type
                            else
                            {
                                if (toCheck == "array")
                                {
                                    if (!(value.StartsWith("[") && value.EndsWith("]")) )
                                    {
                                        errors.Add(new KeyValuePair<string, string>($"{key}: {value}", "The value should be a list"));
                                    }
                                    else
                                    {
                                        try
                                        {
                                            List<Dictionary<string, string>> aux = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(value);

                                            foreach(var element in aux)
                                            {
                                                if (element.TryGetValue("@id", out string id))
                                                {
                                                    if (!Guid.TryParse(id, out Guid projectId))
                                                    {
                                                        errors.Add(new KeyValuePair<string, string>($"{key}: {id}", "Cannot parse the ID"));
                                                    }
                                                }
                                            }
                                            
                                        }
                                        catch
                                        {
                                            continue;
                                        }
                                    }
                                }
                                else if (toCheck == "dict")
                                {
                                    if (!(value.StartsWith("{") && value.EndsWith("}")))
                                    {
                                        errors.Add(new KeyValuePair<string, string>($"{key}: {value}", "The value should be a dictionary"));
                                    }
                                    else
                                    {
                                        Dictionary<string, string> check_ID = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(value);
                                        value = check_ID["@id"];
                                        if (!Guid.TryParse(value, out Guid projectId))
                                        {
                                            errors.Add(new KeyValuePair<string, string>($"{key}: {value}", "Cannot parse the ID"));
                                        }
                                        
                                    }
                                }


                            }

                            
                            
                        }
                    }
                    catch { errors.Add(new KeyValuePair<string, string>(key, "The attribute is not valid")); }
                }

                
            }

            

            return errors;
        }
    }
}
