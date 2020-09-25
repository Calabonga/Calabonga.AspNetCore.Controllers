namespace Calabonga.AspNetCore.Controllers.Context
{
    /// <summary>
    /// Work parameters
    /// </summary>
    public class ContextParameter
    {
        public ContextParameter() { }

        public ContextParameter(string name, object value)
        {
            Name = name;
            Value = value;
            TypeName = value.GetType().FullName;
            AssemblyName = value.GetType().Assembly.GetName().FullName;
        }

        public string AssemblyName { get; set; }

        public string Name { get; set; }

        public string TypeName { get; set; }

        public object Value { get; set; }
    }
}