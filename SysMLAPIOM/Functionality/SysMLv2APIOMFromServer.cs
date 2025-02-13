using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace SysMLv2APIOM.Functionality
{
    public class SysMLv2APIOMFromServer
    {

        #region Project API
        public static void GetProjects(Configuration config)
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

        public static void GetProjectById(Configuration config, Guid projectId)
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

        public static void CreateProject(Configuration config, Project newProject)
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

        public static void DeleteProject(Configuration config, Guid projectId)
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



        public static Guid GetMainBranchIdByProjectId(ProjectApi apiInstance, Guid projectId)
        {


            Project project = apiInstance.GetProjectById(projectId);
            Guid branchId = project.DefaultBranch.Id;

            return branchId;
        }

        public static void UpdateProject(Configuration config, Guid projectId, string name, string descript)
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
        public static void GetCommitsByProjectId(Configuration config, Guid projectId)
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

        public static void CreateBasicNewCommit(Configuration config)
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

        public static void CreateDefinedNewCommit(Configuration config)
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

        public static void pruebaFeature(Configuration config, Guid projectId)
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

        public static void GetElementsByProjectCommitId(Configuration config, Guid projectId, Guid commitId)
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
    }
}
