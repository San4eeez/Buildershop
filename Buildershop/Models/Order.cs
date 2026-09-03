using System;
using System.Collections.Generic;

namespace Buildershop.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? TovarId { get; set; }

    public int? Colvo { get; set; }

    public DateOnly? OrderDate { get; set; }

    public DateOnly? DeliveryDate { get; set; }

    public int? PvzId { get; set; }

    public int? UserId { get; set; }

    public int? Code { get; set; }

    public string? Status { get; set; }

    public virtual Adre? Pvz { get; set; }

    public virtual Tovar? Tovar { get; set; }

    public virtual User? User { get; set; }
}
