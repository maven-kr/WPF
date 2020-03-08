using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace UserControlOnRenderTest
{
    /// <summary>
    /// UserControl1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        protected DrawingGroup backStore;

        public UserControl1()
        {
            InitializeComponent();

            backStore = new DrawingGroup();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            drawingContext.DrawDrawing(backStore);
        }

        protected void Render()
        {
            var context = backStore.Open();

            var text = string.Format("Width: {0}, Height: {1}", ActualWidth, ActualHeight);
            var ft = new FormattedText(
                text,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                20,
                Brushes.Black,
                VisualTreeHelper.GetDpi(this).PixelsPerDip);

            context.DrawText(ft, new Point(10, 10));

            context.Close();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Render();
        }
    }
}
