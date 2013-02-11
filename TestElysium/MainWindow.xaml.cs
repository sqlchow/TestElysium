using Elysium;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TestElysium
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Elysium.Controls.Window
    {
        private static readonly string Windows = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
        private static readonly string SegoeUI = Windows + @"\Fonts\SegoeUI.ttf";
        private static readonly string Verdana = Windows + @"\Fonts\Verdana.ttf";

        public class BooleanToVisibilityConverter : IValueConverter
        {
            public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
            {
                if (targetType == typeof(Visibility))
                {
                    var visible = System.Convert.ToBoolean(value, culture);
                    if (InvertVisibility)
                        visible = !visible;
                    return visible ? Visibility.Visible : Visibility.Collapsed;
                }
                throw new InvalidOperationException("Converter can only convert to value of type Visibility.");
            }
            public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
            {
                throw new InvalidOperationException("Converter cannot convert back.");
            }
            public Boolean InvertVisibility { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SettingGlyph_Initialized(object sender, EventArgs e)
        {
            SettingGlyph.FontUri = new Uri(File.Exists(SegoeUI) ? SegoeUI : Verdana);
        }

        private void OptionsGlyph_Initialized(Object sender, EventArgs e)
        {
            OptionsGlyph.FontUri = new Uri(File.Exists(SegoeUI) ? SegoeUI : Verdana);
        }


        private void tsMulti_IsChecked(object sender, RoutedEventArgs e)
        {
            txtBxNoTh.IsEnabled = true;
        }

    }
}
