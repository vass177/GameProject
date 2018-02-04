using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GameProject
{
    class ShooterFramework: FrameworkElement
    {
        GameShooter shooter;
        public ShooterFramework()
        {
            this.Loaded += ShooterFramework_Loaded;
        }

        private void ShooterFramework_Loaded(object sender, RoutedEventArgs e)
        {
            if(DesignerProperties.GetIsInDesignMode(this)==false)
            {
                shooter = new GameShooter();
                this.InvalidateVisual();
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if(shooter!=null)
            {
                base.OnRender(drawingContext);

                for (int i = 0; i < shooter.ObjectList.Count; i++)
                {
                    Geometry geometry = shooter.ObjectList[i].GetTransformedGeometry();
                    drawingContext.DrawGeometry(Brushes.LightGray, new Pen(Brushes.Black, 5), geometry);
                }
            }
            
        }
    }
}
