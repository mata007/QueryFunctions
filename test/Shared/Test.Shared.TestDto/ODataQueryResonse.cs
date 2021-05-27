using System.Runtime.Serialization;

namespace Test.QueryFunctions.OData
{
    public class ODataQueryResonse<TEntity>
    {
        [DataMember(Name = "@odata.context")]
        public string ODataContext { get; set; }
        [DataMember(Name = "value")]
        public TEntity[] Value { get; set; }
    }
}
