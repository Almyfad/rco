using System.ComponentModel.DataAnnotations;

namespace Helios.Context.Models
{
    public abstract class ModelBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime Creation { get; set; } = DateTime.UtcNow;
        public DateTime? Modification { get; set; }
    }

    public abstract class ModelEnumBase<T> where T : struct, Enum
    {
        [Key]
        public int Id { get; set; }
        public String? Description { get; set; }
        public T Code { get; set; }
        public DateTime Creation { get; set; } = DateTime.UtcNow;
        public DateTime? Modification { get; set; }
    }
}
