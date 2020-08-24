using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Reflection;
using System.Runtime.Remoting;

namespace FlowController
{
    public class OperationConverter : JsonConverter
    {
        public override bool CanWrite => true;
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Operation);
        }
        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            JObject jo = new JObject();
            Type type = value.GetType();
            jo.Add("type", type.FullName);
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.CanRead)
                {
                    object propVal = prop.GetValue(value, null);
                    if (propVal != null)
                    {
                        jo.Add(prop.Name, JToken.FromObject(propVal, serializer));
                    }
                }
            }
            jo.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JObject jsonObject = null;
            if (objectType.IsSubclassOf(typeof(Operation))
                || objectType== typeof(Operation))
            {
                jsonObject = JObject.Load(reader);
                string typeString = jsonObject["type"].ToString();
                string assemblyType = typeString.Split('.')[0];
                Operation operationObject = null;
                try
                {
                    Assembly assembly = Assembly.Load(assemblyType);
                    operationObject=assembly.CreateInstance(typeString) as Operation;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Fail(ex.StackTrace);
                }

                if(operationObject!=null)
                {
                    serializer.Populate(jsonObject.CreateReader(), operationObject);
                }
                return operationObject;
            }
            return null;
        }
    }
}
