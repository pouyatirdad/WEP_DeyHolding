using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Road.Core.Models
{
    public class StaticContent : IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "لوگو")]
        public string ImageLogo { get; set; }
        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "اینستاگرام")]
        public string Instagram { get; set; }

        [Display(Name = "فیسبوک")]
        public string Facebook { get; set; }

        [Display(Name = "واتساپ")]
        public string Whatsapp { get; set; }
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Display(Name = "درباره ما")]
        public string AboutUs { get; set; }
        [Display(Name = "پاورقی")]
        public string FooterDesc { get; set; }
        [Display(Name = "شماره تلفن")]
        public string Phonenumber { get; set; }
        [Display(Name = "عنوان ویژگی 1")]
        public string Feature1 { get; set; }
        [Display(Name = "توضیحات ویژگی 1")]
        public string Feature1Des { get; set; }
        [Display(Name = "عنوان ویژگی 2")]
        public string Feature2 { get; set; }
        [Display(Name = "توضیحات ویژگی 2")]
        public string Feature2Des { get; set; }
        [Display(Name = "عنوان ویژگی 3")]
        public string Feature3 { get; set; }
        [Display(Name = "توضیحات ویژگی 3")]
        public string Feature3Des { get; set; }
        [Display(Name = "عنوان ویژگی 4")]
        public string Feature4 { get; set; }
        [Display(Name = "توضیحات ویژگی 4")]
        public string Feature4Des { get; set; }


        [Display(Name = "عدد نشانگر 1")]
        public int Counter1Num { get; set; }

        [Display(Name = "متن نشانگر 1")]
        public string Counter1Text { get; set; }


        [Display(Name = "عدد نشانگر 2")]
        public int Counter2Num { get; set; }

        [Display(Name = "متن نشانگر 2")]
        public string Counter2Text { get; set; }


        [Display(Name = "عدد نشانگر 3")]
        public int Counter3Num { get; set; }

        [Display(Name = "متن نشانگر 3")]
        public string Counter3Text { get; set; }


        [Display(Name = "عدد نشانگر 4")]
        public int Counter4Num { get; set; }

        [Display(Name = "متن نشانگر 4")]
        public string Counter4Text { get; set; }



        [Display(Name = "تاریخچه شرکت")]
        public string History{get;set;}
        [Display(Name = "چشم انداز")]
        public string CompanyVision { get; set; }

        public string InsertUser { get ; set; }
        public DateTime? InsertDate { get ; set ; }
        public string UpdateUser { get ; set; }
        public DateTime? UpdateDate { get ; set; }
        public bool IsDeleted { get ; set; }
        [AllowHtml]
        [Display(Name = "نقشه")]
        public string Map { get; set; }
    }
}
