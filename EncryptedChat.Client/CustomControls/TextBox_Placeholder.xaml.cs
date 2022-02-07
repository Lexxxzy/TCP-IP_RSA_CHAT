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

namespace EncryptedChat.Client.CustomControls
{
  /// <summary>
  /// Логика взаимодействия для TextBox_Placeholder.xaml
  /// </summary>
  public partial class TextBox_Placeholder : UserControl
  {
    public TextBox_Placeholder()
    {
      InitializeComponent();
    }



    public string PlaceHolder
    {
      get { return (string)GetValue(PlaceHolderProperty); }
      set { SetValue(PlaceHolderProperty, value); }
    }

    // Using a DependencyProperty as the backing store for PlaceHolder.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty PlaceHolderProperty =
        DependencyProperty.Register("PlaceHolder", typeof(string), typeof(TextBox_Placeholder));


    private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {
      var text = (sender as TextBox).Text;
      var result = string.Empty;

      foreach (var ch in text)
      {
        if (char.IsDigit(ch))
          result += ch;
      }

    (sender as TextBox).Text = result;
    }
    public string Text
    {
      get { return (string)GetValue(TextProperty); }
      set { SetValue(TextProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(TextBox_Placeholder));


  
}
}
