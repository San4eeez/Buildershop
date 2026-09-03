using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace Buildershop.Models;

public partial class Tovar
{
    public int Id { get; set; }

    public string? Article { get; set; }

    public string? Name { get; set; }

    public string? EdIzmer { get; set; }

    public double? Cost { get; set; }

    public string? Seller { get; set; }

    public string? Creator { get; set; }

    public string? Category { get; set; }

    public int? Discount { get; set; }

    public int? Colvo { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public Bitmap GetImage
    {
        get
        {
            if (Image != null && Image != "")
            {
                return new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "/Images/" + Image);
            }
            else
            {
                return new Bitmap(AppDomain.CurrentDomain.BaseDirectory + "/Images/picture.png");
            }
        }
    }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
