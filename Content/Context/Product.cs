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
    
    public partial class Product
    {
        public int Id { get; set; }
        public int CatId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Detail { get; set; }
        public string Metakey { get; set; }
        public string Metadese { get; set; }
        public string Img { get; set; }
        public int Number { get; set; }
        public double Price { get; set; }
        public double Pricesale { get; set; }
        public Nullable<int> Create_by { get; set; }
        public Nullable<System.DateTime> Create_at { get; set; }
        public Nullable<int> Update_by { get; set; }
        public Nullable<System.DateTime> Update_at { get; set; }
        public int Status { get; set; }
    }
}
