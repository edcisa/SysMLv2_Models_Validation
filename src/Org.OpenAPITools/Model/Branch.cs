


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using OpenAPIDateConverter = Org.OpenAPITools.Client.OpenAPIDateConverter;

namespace Org.OpenAPITools.Model
{
    /// <summary>
    /// Branch
    /// </summary>
    [DataContract(Name = "Branch")]
    public partial class Branch : IValidatableObject
    {
        /// <summary>
        /// Defines Type
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TypeEnum
        {
            /// <summary>
            /// Enum Branch for value: Branch
            /// </summary>
            [EnumMember(Value = "Branch")]
            Branch = 1
        }


        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name = "@type", EmitDefaultValue = false)]
        public TypeEnum? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="Branch" /> class.
        /// </summary>
        /// <param name="id">id.</param>
        /// <param name="type">type.</param>
        /// <param name="head">head.</param>
        /// <param name="name">name.</param>
        /// <param name="owningProject">owningProject.</param>
        /// <param name="referencedCommit">referencedCommit.</param>
        /// <param name="timestamp">timestamp.</param>
        public Branch(Guid id = default(Guid), TypeEnum? type = default(TypeEnum?), BranchHead head = default(BranchHead), string name = default(string), BranchOwningProject owningProject = default(BranchOwningProject), BranchHead referencedCommit = default(BranchHead), DateTime timestamp = default(DateTime))
        {
            this.Id = id;
            this.Type = type;
            this.Head = head;
            this.Name = name;
            this.OwningProject = owningProject;
            this.ReferencedCommit = referencedCommit;
            this.Timestamp = timestamp;
        }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name = "@id", EmitDefaultValue = false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or Sets Head
        /// </summary>
        [DataMember(Name = "head", EmitDefaultValue = false)]
        public BranchHead Head { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets OwningProject
        /// </summary>
        [DataMember(Name = "owningProject", EmitDefaultValue = false)]
        public BranchOwningProject OwningProject { get; set; }

        /// <summary>
        /// Gets or Sets ReferencedCommit
        /// </summary>
        [DataMember(Name = "referencedCommit", EmitDefaultValue = false)]
        public BranchHead ReferencedCommit { get; set; }

        /// <summary>
        /// Gets or Sets Timestamp
        /// </summary>
        [DataMember(Name = "timestamp", EmitDefaultValue = false)]
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("class Branch {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Head: ").Append(Head).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  OwningProject: ").Append(OwningProject).Append("\n");
            sb.Append("  ReferencedCommit: ").Append(ReferencedCommit).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
