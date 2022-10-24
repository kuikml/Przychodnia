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

namespace MyControl
{
    /// <summary>
    /// Interaction logic for Rate.xaml
    /// </summary>
    public partial class Rate : UserControl
    {
        public Rate()
        {
            InitializeComponent();
        }

        private void star1_Click(object sender, RoutedEventArgs e)
        {
            Image _img = star1.Template.FindName("star1", star1) as Image;
            Style _imgStyle = new Style { TargetType = typeof(Image) };
            _imgStyle.Setters.Add(new Setter(Image.SourceProperty, new BitmapImage(new Uri(@"C:/Users/kuikb/Downloads/Gold.png"))));
            _img.Style = _imgStyle;
        }

        private void star2_Click(object sender, RoutedEventArgs e)
        {
            Image _img = star1.Template.FindName("star1", star1) as Image;
            Image _img2 = star2.Template.FindName("star2", star2) as Image;
            Style _imgStyle = new Style { TargetType = typeof(Image) };
            _imgStyle.Setters.Add(new Setter(Image.SourceProperty, new BitmapImage(new Uri(@"C:/Users/kuikb/Downloads/Gold.png"))));
            _img.Style = _imgStyle;
            _img2.Style = _imgStyle;

        }

        private void star3_Click(object sender, RoutedEventArgs e)
        {
            Image _img = star1.Template.FindName("star1", star1) as Image;
            Image _img2 = star2.Template.FindName("star2", star2) as Image;
            Image _img3 = star3.Template.FindName("star3", star3) as Image;
            Style _imgStyle = new Style { TargetType = typeof(Image) };
            _imgStyle.Setters.Add(new Setter(Image.SourceProperty, new BitmapImage(new Uri(@"C:/Users/kuikb/Downloads/Gold.png"))));
            _img.Style = _imgStyle;
            _img2.Style = _imgStyle;
            _img3.Style = _imgStyle;

        }

        private void star4_Click(object sender, RoutedEventArgs e)
        {
            Image _img = star1.Template.FindName("star1", star1) as Image;
            Image _img2 = star2.Template.FindName("star2", star2) as Image;
            Image _img3 = star3.Template.FindName("star3", star3) as Image;
            Image _img4 = star4.Template.FindName("star4", star4) as Image;
            Style _imgStyle = new Style { TargetType = typeof(Image) };
            _imgStyle.Setters.Add(new Setter(Image.SourceProperty, new BitmapImage(new Uri(@"C:/Users/kuikb/Downloads/Gold.png"))));
            _img.Style = _imgStyle;
            _img2.Style = _imgStyle;
            _img3.Style = _imgStyle;
            _img4.Style = _imgStyle;
            
        }

        private void star5_Click(object sender, RoutedEventArgs e)
        {
            Image _img = star1.Template.FindName("star1", star1) as Image;
            Image _img2 = star2.Template.FindName("star2", star2) as Image;
            Image _img3 = star3.Template.FindName("star3", star3) as Image;
            Image _img4 = star4.Template.FindName("star4", star4) as Image;
            Image _img5 = star5.Template.FindName("star5", star5) as Image;
            Style _imgStyle = new Style { TargetType = typeof(Image) };
            _imgStyle.Setters.Add(new Setter(Image.SourceProperty, new BitmapImage(new Uri(@"C:/Users/kuikb/Downloads/Gold.png"))));
            _img.Style = _imgStyle;
            _img2.Style = _imgStyle;
            _img3.Style = _imgStyle;
            _img4.Style = _imgStyle;
            _img5.Style = _imgStyle;
        }

    }
}
