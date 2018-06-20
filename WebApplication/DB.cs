using System.ComponentModel.DataAnnotations;

namespace WebApplication
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB() : base("name=DB") { }
            public virtual DbSet<Data> Datas { get; set; }
    }

    public partial class Data
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Sentence { get; set; }

        [Required]
        public string SearchWord { get; set; }
}
}
