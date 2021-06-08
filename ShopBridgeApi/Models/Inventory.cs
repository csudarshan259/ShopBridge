using System;
using System.ComponentModel.DataAnnotations;
using FluentValidation;

namespace ShopBridgeApi.Models
{
    public class Inventory
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public long quantity { get; set; }
        
        public string hsn_sac { get; set; }
        public DateTime createdOn { get; set; }
        public DateTime updatedOn { get; set; }
    }
    public class InventoryValidator: AbstractValidator<Inventory>
    {
        public InventoryValidator()
        {
            RuleFor(x => x.name).NotNull().NotEmpty().Length(255);
            RuleFor(x => x.quantity).NotNull().NotEmpty();
            RuleFor(x => x.price).NotEmpty().NotNull();
            RuleFor(X => X.description).NotNull();
            RuleFor(x => x.hsn_sac).NotNull();
        }
    }
}
