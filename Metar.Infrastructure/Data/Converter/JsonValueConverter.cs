using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace MetarApi.Data.Converter
{
    public class JsonValueConverter<T> : ValueConverter<T?, string>
    {
        public JsonValueConverter() 
            : base((obj) =>(obj == null?string.Empty:  JsonConvert.SerializeObject(obj)) , (json)=>JsonConvert.DeserializeObject<T?>(json), null)
        {
        }
    }


}
