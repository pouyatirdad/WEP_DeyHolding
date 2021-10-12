using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Road.Core.Models
{
    public class Video : IBaseEntity
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "عنوان ویدیو")]
        public string Title { get; set; }

        public string FileName { get; set; }
        public string InsertUser { get; set; }
        public DateTime? InsertDate { get; set; }
        public string UpdateUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
