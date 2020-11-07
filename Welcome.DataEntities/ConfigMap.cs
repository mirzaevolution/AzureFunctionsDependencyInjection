using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Welcome.DataEntities
{
    [Table("COnfigMaps")]
    public class ConfigMap
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
