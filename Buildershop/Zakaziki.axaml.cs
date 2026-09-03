using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Buildershop.Context;
using System.Linq;

namespace Buildershop;

public partial class Zakaziki : Window
{
    public Zakaziki()
    {
        InitializeComponent();
    }

    public void GetInfo()
    {
        Demka24Context context = new Demka24Context();

        var listOrders = context.Orders.ToList();


    }
}