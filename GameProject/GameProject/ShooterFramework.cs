using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace GameProject
{
    class ShooterFramework: FrameworkElement
    {
        GameShooter shooter;
        double screenWidth;
        double screenHeight;
        DispatcherTimer timer;
        public ShooterFramework()
        {
            this.Loaded += ShooterFramework_Loaded;
            this.MouseDown += ShooterFramework_MouseDown;
        }

        private void ShooterFramework_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Point point = e.GetPosition(this);
            for (int i = 0; i < shooter.ObjectList.Count; i++)
            {
                if (shooter.ObjectList[i].Location.X <= point.X && shooter.ObjectList[i].Location.X + shooter.ObjectList[i].Width >= point.X)
                {
                    if (shooter.ObjectList[i].Location.Y <= point.Y && shooter.ObjectList[i].Location.Y + shooter.ObjectList[i].Height >= point.Y)
                    {
                        if (shooter.ObjectList[i] is Circle)
                        {
                            Console.WriteLine("circle");
                        }
                    }
                }
            }
        }

        private void ShooterFramework_Loaded(object sender, RoutedEventArgs e)
        {
            if(DesignerProperties.GetIsInDesignMode(this)==false)
            {
                screenWidth = this.ActualWidth;
                screenHeight = this.ActualHeight;
                shooter = new GameShooter(screenHeight, screenWidth);
                timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
                timer.Tick += Timer_Tick;
                timer.Start();
                this.InvalidateVisual();

                //for mouse click -> focus FrameworkElement
                this.Focusable = true;
                this.Focus();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            shooter.DoTurn();
            this.InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if(shooter!=null)
            {
                base.OnRender(drawingContext);

                for (int i = 0; i < shooter.ObjectList.Count; i++)
                {
                    if (shooter.ObjectList[i] is Cross)
                    {
                        drawingContext.DrawGeometry(Brushes.Azure, new Pen(Brushes.Black, 25), shooter.ObjectList[i].GetTransformedGeometry());
                    }
                    else
                    {
                        drawingContext.DrawGeometry(Brushes.Azure, new Pen(Brushes.Black, 4), shooter.ObjectList[i].GetTransformedGeometry());
                    }


                }
                if (shooter.ChoosenElement is Cross)
                {
                    drawingContext.DrawGeometry(Brushes.Azure, new Pen(Brushes.Black, 25), shooter.ChoosenElement.GetTransformedGeometry());
                }
                else
                {
                    drawingContext.DrawGeometry(Brushes.Azure, new Pen(Brushes.Black, 4), shooter.ChoosenElement.GetTransformedGeometry());
                }


            }
            
        }
    }
}
