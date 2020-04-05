using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataProcessingWebAPI
{
    public class XMLValidatorSchemaAttribute : Attribute
    {
        public string SchemaName { get; set; }
        public XMLValidatorSchemaAttribute(string SchemaName)
        {
            this.SchemaName = SchemaName;
        }
    }
}