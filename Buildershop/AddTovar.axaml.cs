using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Buildershop.Context;
using Buildershop.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;

namespace Buildershop;

public partial class AddTovar : Window
{
    public AddTovar()
    {
        InitializeComponent();
        DataContext = new Tovar();
    }

    public AddTovar(Tovar tovar)
    {
        InitializeComponent();
        DataContext = tovar;
    }

    private void AddNew_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Demka24Context context = new Demka24Context();

        var prod = DataContext as Tovar;

        if(Article.Text != null
            && Name.Text != null
            && EdIzmer.Text != null
            && Cost.Text != null
            && Seller.Text != null
            && Creator.Text != null
            && Category.Text != null
            &&Discount.Text != null
            && Colvo.Text != null
            &&Description.Text != null
            )
        {

            try
            {


        context.Add(prod);
        context.SaveChanges();
        Glavnoe glavnoe = new Glavnoe();
        glavnoe.Show();
        this.Close();
            }
            catch
            {
                durak.IsVisible = true;
            }
        }
        else
        {
            durak.IsVisible = true;
        }

    }

    private void Edit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        

        if (Article.Text != null
            && Name.Text != null
            && EdIzmer.Text != null
            && Cost.Text != null
            && Seller.Text != null
            && Creator.Text != null
            && Category.Text != null
            && Discount.Text != null
            && Colvo.Text != null
            && Description.Text != null
            )
        {

        

                try
            {
                Demka24Context context = new Demka24Context();

                var prod = DataContext as Tovar;

                var editprod = context.Tovars.FirstOrDefault(x => x.Id == prod.Id);

                editprod.Article = Article.Text;
                editprod.Name = Name.Text;
                editprod.EdIzmer = EdIzmer.Text;
                editprod.Cost = float.Parse(Cost.Text);
                editprod.Seller = Seller.Text;
                editprod.Creator = Creator.Text;
                editprod.Category = Category.Text;
                editprod.Discount = int.Parse(Discount.Text);
                editprod.Colvo = int.Parse(Colvo.Text);
                editprod.Description = Description.Text;

                context.Tovars.Update(editprod);
            context.SaveChanges();

            Glavnoe glavnoe = new Glavnoe();

            glavnoe.Show();
            this.Close();
            }

            catch
            {
                durak.IsVisible = true;
            }

        }
        else
        {
            durak.IsVisible = true;
        }



    }
}