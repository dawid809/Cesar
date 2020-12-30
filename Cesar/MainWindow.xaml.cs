using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cesar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_ClickSzyfruj(object sender, RoutedEventArgs e)
        {
            char[] tablicaZnakow = textset.Text.ToCharArray();
            char[] alfabet = Alfabet();
            int selectedIndex = scroll.SelectedIndex;

            ToLower(tablicaZnakow);

            for (int i = 0; i < tablicaZnakow.Length; i++)
            {
                char letter = tablicaZnakow[i];

                if (!(alfabet.Contains(letter)))
                    letter = default;

                for (int j = 0; j < alfabet.Length; j++)
                {
                    char alfabetLetter = alfabet[j];

                    int index = alfabet.FindIndex(alfabetLetter);
                    int sum = index + selectedIndex;
                    int outIndex = sum - alfabet.Length;

                    if (letter.Equals(alfabetLetter))
                    {
                        if (index + selectedIndex >= alfabet.Length)
                            letter = alfabet[outIndex];
                        else
                            letter = alfabet[j + selectedIndex];
                        break;
                    }
                }
                tablicaZnakow[i] = letter;
            }
            string ciagString = new string(tablicaZnakow);

            textget.Text = ciagString;
        }

        private void Button_ClickDeszyfruj(object sender, RoutedEventArgs e)
        {
            char[] tablicaZnakow = textset.Text.ToCharArray();
            char[] alfabet = Alfabet();
            int selectedIndex = scroll.SelectedIndex;

            ToLower(tablicaZnakow);

            for (int i = 0; i < tablicaZnakow.Length; i++)
            {
                char letter = tablicaZnakow[i];

                if (!(alfabet.Contains(letter)))
                    letter = default;

                for (int j = 0; j < alfabet.Length; j++)
                {
                    char alfabetLetter = alfabet[j];

                    int index = alfabet.FindIndex(alfabetLetter);
                    int sum = index - selectedIndex;
                    int outIndex = sum + alfabet.Length;

                    if (letter.Equals(alfabetLetter))
                    {
                        if (index - selectedIndex < 0)
                            letter = alfabet[outIndex];
                        else
                            letter = alfabet[j - selectedIndex];
                        break;
                    }
                }
                tablicaZnakow[i] = letter;
            }
            string ciagString = new string(tablicaZnakow);

            textget.Text = ciagString;
        }

        private void Button_ClickCzysc(object sender, RoutedEventArgs e)
        {
            textget.Text = default;
            textset.Text = default;
            scroll.SelectedItem = null;
        }

        static string ToLower(char[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                char let = arr[i];
                if (char.IsUpper(let))
                    arr[i] = char.ToLower(let);
            }
            string ciag = new string(arr);
            return ciag;
        }

        private char[] Alfabet()
        {
            char[] alfabet = { 'a','ą', 'b', 'c', 'ć', 'd', 'e', 'ę', 'f', 'g', 'h', 'i', 'j','k',
                'l','ł','m','n','ń','o','ó','p','q','r','s','ś','t','u','v','w','x','y','z','ź','ż'};
            return alfabet;
        }

        private void textset_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            textset.Clear();
        }

        private void scroll_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 34; i++)
            {
                scroll.Items.Add(i);
            }
        }
    }

    public static class Extensions
    {
        public static int FindIndex<T>(this T[] array, T item)
        {
            return Array.FindIndex(array, val => val.Equals(item));
        }
    }
}
