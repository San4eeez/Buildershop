using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Buildershop.Context;
using Buildershop.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Buildershop;

public partial class Glavnoe : Window
{
    public Glavnoe()
    {
        InitializeComponent();
        fio.Text = SaveUser._user.Fio;


        if( SaveUser._user.RoleId == 3 || SaveUser._user.RoleId ==4)
        {
            SortBox.IsVisible = false;
            SearchBox.IsVisible = false;
            NewTovar.IsVisible = false;
            Zakaziki.IsVisible = false;
            ListProduct.IsVisible = false;
            ListProduct2.IsVisible = true;
        }

        GetInfo();
    }

    public void GetInfo()
    {
        Demka24Context context = new Demka24Context();

        var listProduct = context.Tovars.Include(x => x.Orders).ToList();

        if (SearchBox.Text != null)
        {
            listProduct = listProduct.Where(x => x.Name.Contains(SearchBox.Text)
            || x.Description.Contains(SearchBox.Text)
            || x.Creator.Contains(SearchBox.Text)
            ).ToList();
        }

        switch (SortBox.SelectedIndex)
        {
            case 0:
                listProduct = listProduct.OrderBy(x => x.Colvo).ToList();
                break;
            case 1:
                listProduct = listProduct.OrderByDescending(x => x.Colvo).ToList();
                break;
        }

        if (SaveUser._user.RoleId == 3 || SaveUser._user.RoleId == 4)
        {
            ListProduct2.ItemsSource = listProduct;

        }
        else
        {

            ListProduct.ItemsSource = listProduct;
        }

    }


    private void SearchBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
    {
        GetInfo();
    }

    private void SortBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        GetInfo();
    }

    private void Zakaziki_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
    }

    private void NewTovar_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        AddTovar addTovar = new AddTovar();
        addTovar.Show();
        this.Close();
    }

    private void Exit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }

    private void Remove_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Demka24Context context = new Demka24Context();

        int id = (int)(sender as Button)!.Tag!;

        var prod = context.Tovars.FirstOrDefault(x => x.Id == id);


        if (prod != null && prod.Orders.Count == 0)
        {
            try
            {

                context.Remove(prod);
                context.SaveChanges();
                GetInfo();
            }
            catch
            {

            }
        }

    }

    private void ListProduct_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        AddTovar addTovar = new AddTovar(ListProduct.SelectedItem as Tovar);
        addTovar.Show(); this.Close();
    }
}
