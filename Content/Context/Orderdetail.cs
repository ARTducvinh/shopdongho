//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace shopdongho.Content.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orderdetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public int Orders { get; set; }
        public string Amount { get; set; }
    }
}