using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace F15Team26.Models
{
    public class Promotions
    {
        [Required]
        [Key]
        public String PromotionsID { get; set; }

        public virtual List<Books> Books { get; set; }
        public String OrderID { get; set; }
        public enum CouponType
        {
            [Display(Name = "For All Orders")]
            ForAllOrders,
            [Display(Name = "Above Set Amount")]
            AboveSetAmount,
            [Display(Name = "Off Total Price")]
            OffTotalPrice,
            [Display(Name = "No Coupon")]
            NoCoupon
        };

        public CouponType? CouponTypes{ get; set; }

    }
}