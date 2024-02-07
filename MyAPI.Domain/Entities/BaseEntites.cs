using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Domain.Entities
{
    public class BaseEntites<T>
    {
        public T Id { get; set; }
        public DateTime? Insert_DateTime { get; set; } = DateTime.Now;
        public long Insert_ByUserID { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? Delete_DateTime { get; set; }
        public long? Delete_ByUserID { get; set; }
        public DateTime? Update_DateTime { get; set; }
        public long? Update_ByUserID { get; set; }
    }
    public abstract class BaseEntites : BaseEntites<long>
    {

    }
}
