using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;
using Newtonsoft.Json.Linq;
using Newtonsoft;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;


namespace Org.OpenAPITools
{
    class Program
    {
        #region Project API
        private static void GetProjects(Configuration config)
        {
            var apiInstance = new ProjectApi(config);

            try
            {
                List<Project> projects = apiInstance.GetProjects();
                foreach (Project project in projects)
                {
                    Console.WriteLine($"ID: {project.Id}, Name: {project.Name}");
                }
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Error al obtener los proyectos: {ex.Message}");
                Console.WriteLine($"Detalle del error: {ex.ErrorContent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener los proyectos: {ex.Message}");
            }
        }

        private static void GetProjectById(Configuration config, Guid projectId)
        {
            var apiInstance = new ProjectApi(config);

            try
            {
                Project project = apiInstance.GetProjectById(projectId);
                Console.WriteLine($"ID: {project.Id}, Name: {project.Name}, Branch: {project.DefaultBranch}");
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Error al obtener el proyecto {ex.Message}");
                Console.WriteLine($"Detalle del error: {ex.ErrorContent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el proyecto: {ex.Message}");
            }
        }

        private static void CreateProject(Configuration config, Project newProject)
        {
            var apiInstance = new ProjectApi(config);

            try
            {
                Project createdProject = apiInstance.PostProject(newProject);
                Console.WriteLine($"Proyecto creado con éxito: ID: {createdProject.Id}, Name: {createdProject.Name}");
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Error al crear el proyecto: {ex.Message}");
                Console.WriteLine($"Detalle del error: {ex.ErrorContent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el proyecto: {ex.Message}");
            }
        }

        private static void DeleteProject(Configuration config, Guid projectId)
        {
            var apiInstance = new ProjectApi(config);

            try
            {
                apiInstance.DeleteProjectById(projectId);
                Console.WriteLine($"Proyecto con ID {projectId} eliminado con éxito.");
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Error al eliminar el proyecto: {ex.Message}");
                Console.WriteLine($"Detalle del error: {ex.ErrorContent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el proyecto: {ex.Message}");
            }
        }



        private static Guid GetMainBranchIdByProjectId(ProjectApi apiInstance, Guid projectId)
        {


            Project project = apiInstance.GetProjectById(projectId);
            Guid branchId = project.DefaultBranch.Id;

            return branchId;
        }

        private static void UpdateProject(Configuration config, Guid projectId, string name, string descript)
        {
            var apiInstance = new ProjectApi(config);
            Guid branchId = GetMainBranchIdByProjectId(apiInstance, projectId);
            ProjectDefaultBranch defaultBranch = new ProjectDefaultBranch { Id = branchId };

            try
            {
                var newProject = new Project { Name = name, Description = descript, DefaultBranch = defaultBranch };


                apiInstance.PutProjectById(projectId, newProject);
                Console.WriteLine($"Proyecto con ID {projectId} actualizado con éxito.");

            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Error al actualizar el proyecto: {ex.Message}");
                Console.WriteLine($"Detalle del error: {ex.ErrorContent}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al acualizar el proyecto: {ex.Message}");
            }
        }
        #endregion

        #region Commit API
        private static void GetCommitsByProjectId(Configuration config, Guid projectId)
        {
            var apiInstance = new CommitApi(config);
            try
            {
                List<Commit> commits = apiInstance.GetCommitsByProject(projectId);
                foreach (Commit commit in commits)
                {
                    Console.WriteLine(commit);
                }
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Error al visualizar los commits del proyecto: {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al visualizar los commits del proyecto: {ex.Message}");
            }
        }

        private static void CreateBasicNewCommit(Configuration config)
        {
            var apiInstance = new CommitApi(config);
            
            
            Commit commit = new Commit();

            try
            {
                apiInstance.PostCommitByProject(Guid.Parse("1994c851-94bc-4c9c-9f13-46bd57aaf6c3"), commit);
                Console.WriteLine("Commit creado con éxito");
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Error al crear los commits del proyecto: {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear los commits del proyecto: {ex.Message}");
                }

            }

        private static void CreateDefinedNewCommit(Configuration config)
        {
            
            var apiInstance = new CommitApi(config);
            // Pedir al usuario el GUID del proyecto
            Console.WriteLine("Ingrese el ID del proyecto:");
            if (!Guid.TryParse(Console.ReadLine(), out Guid projectId))
            {
                Console.WriteLine("ID de proyecto no válido.");
                return;
            }

            Guid commitId = Guid.NewGuid(); // Nuevo ID para el commit

            // Crear el objeto ContainingProject con el ID del proyecto
            BranchOwningProject containingProject = new BranchOwningProject
            {
                Id = projectId // Asignar el ID del proyecto
            };

            // Crear una lista de cambios para el commit
            List<DataVersion> changes = new List<DataVersion> {

                new DataVersion {
                    Id = Guid.NewGuid(),
                        Type = DataVersion.TypeEnum.DataVersion,
                        Payload = new Data(
                            id: Guid.NewGuid(), // Nuevo ID para el Payload
                            type: "PartDefinition" // Tipo válido, coincide con el @type esperado en JSON

                        ),
                        Identity = new DataIdentity // Agregando el objeto "identity" con su tipo correspondiente
                                    {
                                        Id = Guid.NewGuid(), // ID para DataIdentity
                                            Type = DataIdentity.TypeEnum.DataIdentity // Asignar el tipo como DataIdentity usando la enumeración correcta
                                    }
                }

            };

            Data payloadData = (Data)changes[0].Payload;
            
            if (payloadData.AdditionalProperties == null)
            {
                payloadData.AdditionalProperties = new Dictionary<string, object>();
            }

            // Agregar la propiedad adicional se puede añadir cualquier clave valor como descipción
            payloadData.AdditionalProperties["name"] = "Defined Commit";

            
            // Crear el nuevo objeto Commit
            Commit commit = new Commit(
                //id: commitId,// No incluir el ID en el commit
                type: Commit.TypeEnum.Commit,
                change: changes

            );

            try
            {
                // Convertir el objeto Commit a JSON y mostrar en consola
                string commitJson = commit.ToJson(); // Convertir a JSON usando el método ToJson
                Console.WriteLine("Petición JSON que se va a enviar: \n" + commitJson); // Imprimir la petición JSON

                // Llamada a la API para crear el commit
                apiInstance.PostCommitByProject(projectId, commit);
                Console.WriteLine("_____Commit Creado_____"); // Imprimir la petición JSON

            }
            catch (Org.OpenAPITools.Client.ApiException apiEx)
            {
                // Muestra el código de error y el mensaje de la excepción
                Console.WriteLine($"Error al llamar a la API: Código HTTP: {apiEx.ErrorCode}");
                Console.WriteLine($"Mensaje de Error: {apiEx.Message}");

                // Intentar obtener el contenido de la respuesta desde el cuerpo de la excepción, si es posible
                if (apiEx.ErrorContent != null)
                {
                    Console.WriteLine($"Contenido del error: {apiEx.ErrorContent}");
                }
                else
                {
                    Console.WriteLine("No se pudo obtener el contenido de la respuesta.");
                }
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción genérica
                Console.WriteLine($"Error genérico: {ex.Message}");
            }
        }

        private static void pruebaFeature(Configuration config, Guid projectId)
        {

            var apiInstance = new CommitApi(config);
            
            Guid commitId = Guid.NewGuid(); // Nuevo ID para el commit

            // Crear el objeto ContainingProject con el ID del proyecto
            BranchOwningProject containingProject = new BranchOwningProject
            {
                Id = projectId // Asignar el ID del proyecto
            };

            // Crear una lista de cambios para el commit
            List<DataVersion> changes = new List<DataVersion> {

                new DataVersion {
                    Id = Guid.NewGuid(),
                        Type = DataVersion.TypeEnum.DataVersion,
                        Payload = new Data(
                            id: Guid.NewGuid(), // Nuevo ID para el Payload
                            type: "PartDefinition" // Tipo válido, coincide con el @type esperado en JSON

                        ),
                        Identity = new DataIdentity // Agregando el objeto "identity" con su tipo correspondiente
                                    {
                                        Id = Guid.NewGuid(), // ID para DataIdentity
                                            Type = DataIdentity.TypeEnum.DataIdentity // Asignar el tipo como DataIdentity usando la enumeración correcta
                                    }
                },
                new DataVersion {
                    Id = Guid.NewGuid(),
                        Type = DataVersion.TypeEnum.DataVersion,
                        Payload = new Data(
                            id: Guid.NewGuid(), // Nuevo ID para el Payload
                            type: "PartUsage" // Tipo válido, coincide con el @type esperado en JSON

                        ),
                        Identity = new DataIdentity // Agregando el objeto "identity" con su tipo correspondiente
                                    {
                                        Id = Guid.NewGuid(), // ID para DataIdentity
                                            Type = DataIdentity.TypeEnum.DataIdentity // Asignar el tipo como DataIdentity usando la enumeración correcta
                                    }
                }

            };

            Data payloadData2 = (Data)changes[0].Payload;
            if (payloadData2.AdditionalProperties == null)
            {
                payloadData2.AdditionalProperties = new Dictionary<string, object>();
            }
            payloadData2.AdditionalProperties["name"] = "Electric Motor";

            Data payloadData = (Data)changes[1].Payload;
            if (payloadData.AdditionalProperties == null)
            {
                payloadData.AdditionalProperties = new Dictionary<string, object>();
            }
            payloadData.AdditionalProperties["name"] = "motor_a";

            List<Dictionary<string, Guid>> listOfDictionaries = new List<Dictionary<string, Guid>>();
            Dictionary<string, Guid> dict1 = new Dictionary<string, Guid>();
            dict1["@id"] = changes[1].Identity.Id;
            listOfDictionaries.Add(dict1);
            payloadData2.AdditionalProperties["feature"] = listOfDictionaries;

           
            // Crear el nuevo objeto Commit
            Commit commit = new Commit(
                //id: commitId,// No incluir el ID en el commit
                type: Commit.TypeEnum.Commit,
                change: changes

            );

            try
            {
                // Convertir el objeto Commit a JSON y mostrar en consola
                string commitJson = commit.ToJson(); // Convertir a JSON usando el método ToJson
                Console.WriteLine("Petición JSON que se va a enviar: \n" + commitJson); // Imprimir la petición JSON

                // Llamada a la API para crear el commit
                apiInstance.PostCommitByProject(projectId, commit);
                Console.WriteLine("_____Commit Creado_____"); // Imprimir la petición JSON

            }
            catch (Org.OpenAPITools.Client.ApiException apiEx)
            {
                // Muestra el código de error y el mensaje de la excepción
                Console.WriteLine($"Error al llamar a la API: Código HTTP: {apiEx.ErrorCode}");
                Console.WriteLine($"Mensaje de Error: {apiEx.Message}");

                // Intentar obtener el contenido de la respuesta desde el cuerpo de la excepción, si es posible
                if (apiEx.ErrorContent != null)
                {
                    Console.WriteLine($"Contenido del error: {apiEx.ErrorContent}");
                }
                else
                {
                    Console.WriteLine("No se pudo obtener el contenido de la respuesta.");
                }
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción genérica
                Console.WriteLine($"Error genérico: {ex.Message}");
            }
        }

        #endregion Commit API

        #region Element API

        private static void GetElementsByProjectCommitId(Configuration config, Guid projectId, Guid commitId)
        {
            var apiInstance = new ElementApi(config);
            try
            {
                List<Element> elements = apiInstance.GetElementsByProjectCommit(projectId, commitId);
                foreach (Element element in elements)
                {
                    Console.WriteLine(element);
                    var ap = element.AdditionalProperties;
                    Console.WriteLine(ap.GetType());
                    
                    
                    
                }
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Error al visualizar los elementos del proyecto: {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al visualizar los elementos del proyecto: {ex.Message}");
            }
        }

        #endregion

        #region Tree Function

        /// <summary>
        /// Returns list of Ids of features
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static List<string> GetMemberFeatures(Element element)
        {
            // Try to retrieve the "feature" key and check if it's a JArray
            if (element.AdditionalProperties.TryGetValue("feature", out var elementFeatures) && elementFeatures is JArray featureArray)
            {
                // Use LINQ to select the @id values and return them as a list
                return featureArray
                        .OfType<JObject>()                 // Ensure we are working with JObject elements
                        .Select(jo => jo["@id"]?.ToString()) // Extract the @id property
                        .Where(id => id != null)            // Filter out null values
                        .ToList();                          // Convert to List<string>
            }

            return new List<string>();  // Return an empty list if no "feature" is found
        }

        /// <summary>
        /// Builds element hierarchy based on feature membership.
        /// </summary>
        /// <param name="elementApiInstance"></param>
        /// <param name="projectId"></param>
        /// <param name="commitId"></param>
        public static void BuildElementsTree(ElementApi elementApiInstance, Guid projectId, Guid commitId)
        {
            List<Element> elements = elementApiInstance.GetElementsByProjectCommit(projectId, commitId);
            Dictionary<string, Element> elementDictionary = new Dictionary<string, Element>();
            HashSet<string> rootElements = new HashSet<string>();


            foreach (var element in elements)
            {
                elementDictionary[element.Id.ToString()] = element;
                rootElements.Add(element.Id.ToString()); // Assume all elements are roots initially
            }

            // Mark non-root elements (those that are features of others)
            foreach (var element in elements)
            {
                List<string> memberFeatures = GetMemberFeatures(element);
                foreach (var featureId in memberFeatures)
                {
                    rootElements.Remove(featureId); // Remove the feature from root elements
                }
            }

            // Process only the elements that are roots (not a feature of another element)
            foreach (var rootElementId in rootElements)
            {
                Element rootElement = elementDictionary[rootElementId];
                ProcessElement(rootElement, elementApiInstance, projectId, commitId, elementDictionary, new HashSet<string>(), "");
            }
        }

        /// <summary>
        /// Recursively prints feature members.
        /// </summary>
        /// <param name="element"></param>
        /// <param name="elementApiInstance"></param>
        /// <param name="projectId"></param>
        /// <param name="commitId"></param>
        /// <param name="elementDictionary"></param>
        /// <param name="processedElements"></param>
        /// <param name="indent"></param>
        public static void ProcessElement(Element element, ElementApi elementApiInstance, Guid projectId, Guid commitId, Dictionary<string, Element> elementDictionary, HashSet<string> processedElements, string indent)
        {
            // Print the element details
            Console.WriteLine($"{indent}- {element.AdditionalProperties["name"]} (id = {element.Id}, type = {element.Type})");
            processedElements.Add(element.Id.ToString());
            List<string> memberFeatures = GetMemberFeatures(element);

            // Recursively process each member feature
            foreach (var featureId in memberFeatures)
            {
                if (elementDictionary.ContainsKey(featureId) && !processedElements.Contains(featureId))
                {
                    Element featureElement = elementDictionary[featureId];
                    ProcessElement(featureElement, elementApiInstance, projectId, commitId, elementDictionary, processedElements, indent + "  ");
                }
            }
        }
        private static void buildTreeCommitsElements(Configuration config, Guid projectId)
        {
            var commitApiInstance = new CommitApi(config);
            var elementApiInstance = new ElementApi(config);
            try
            {
                List<Commit> commits = commitApiInstance.GetCommitsByProject(projectId);
                int cont = 0;
                foreach (Commit commit in commits)
                {
                    
                    Guid commitId = commit.Id;
                    List<Element> elements = elementApiInstance.GetElementsByProjectCommit(projectId, commitId);
                    Console.WriteLine($"{cont+1}. Commit {commit.Id}");
                    cont += 1;
                    
                    foreach (Element element in elements)
                    {
                       
                       Console.WriteLine($"-------------> Element {element.Id} {element.AdditionalProperties["name"]}");
                        
                    }
                }
            }
            catch (ApiException ex)
            {
                Console.WriteLine($"Error al visualizar el árbol del proyecto: {ex.Message}");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al visualizar el árbol del proyecto: {ex.Message}");
            }
        }

        #endregion

        #region SysMLv2 API OM

        public static Project ProjectJson2AOm (string jsonData)
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

        public static List<Element> ElementsJson2AOm(string jsonData)
        {

            List<JObject> preElements = Newtonsoft.Json.JsonConvert.DeserializeObject<List<JObject>>(jsonData);
            int error_count = 0;
            foreach (JObject element in preElements)
            {
                
                var dict = readJson(element);
                string type = dict["@type"];
                string schemaFilePath = $@"C:\Users\jolis\Documents\sysmlv2_connector\Sandbox\Sandbox\src\Org.OpenAPITools\Jsons\jsons\{type}.json";
                JObject partDefSchema = JObject.Parse(File.ReadAllText(schemaFilePath));
                var schema = readJson(partDefSchema);

                Console.WriteLine(validateKeys(dict, schema));
                var errors = ValidateSchema(schema, dict);

                error_count += errors.Count;
            }

            if (error_count == 0) 
            {
                //Replace
                string todayDateTime = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
                string pattern = @"(?<!@)type";
                string replacement = $"type{todayDateTime}";
                string result = Regex.Replace(jsonData, pattern, replacement);
                List<Element> commits = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Element>>(result);
                return commits;
            }
            else { return new List<Element>(); }
            
        }

        #endregion

        #region Validation

        private static Dictionary<String, String> readJson(JObject json)
        {
            //JObject jsonObject = JObject.Parse(json);
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

        private static Boolean validateKeys(Dictionary<String, String> data, Dictionary<String, String> schema)
        {
            var dataKeys = new HashSet<string>(data.Keys);
            var schemaKeys = new HashSet<string>(schema.Keys);

            // Verifica si todas las claves de data están en schema
            return dataKeys.IsSubsetOf(schemaKeys);
        }

        private static List<KeyValuePair<string, string>> ValidateSchema(Dictionary<string, string> schema, Dictionary<string, string> data)
        {
            var errors = new List<KeyValuePair<string, string>>();

            foreach (var kvp in data)
            {
                string value = kvp.Value;
                string key = kvp.Key;

                try
                {
                    string toCheck = schema[key];

                    if (value == "List")
                    {
                        if (!(toCheck.StartsWith("[") && toCheck.EndsWith("]")))
                        {
                            errors.Add(new KeyValuePair<string, string>(key, toCheck));
                        }
                    }
                    else if (value == "String")
                    {
                        if (string.IsNullOrEmpty(toCheck) || toCheck.StartsWith("[") || toCheck.StartsWith("{") || toCheck.EndsWith("]") || toCheck.EndsWith("}"))
                        {
                            errors.Add(new KeyValuePair<string, string>(key, toCheck ?? "null"));
                        }
                    }
                }
                catch { errors.Add(new KeyValuePair<string, string>(key, "Not found in json")); }
            }

            return errors;
        }

        #endregion

        public static void Main()
        {

            // Para conectarnos al servidor simplemente tenemos que pasarle la URL
            var basePath = "http://163.117.147.66:9000";
            var config = new Configuration { BasePath = basePath };

            string jsonFilePath = "C:\\Users\\jolis\\Documents\\sysmlv2_connector\\Sandbox\\Sandbox\\src\\Org.OpenAPITools\\Jsons\\elements.json";
            string jsonData = File.ReadAllText(jsonFilePath);

            
        }
    }
}