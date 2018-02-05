using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GameProject
{
    class GameShooter
    {
        private List<GameElement> objectList;
        private static Random rnd = new Random();
        private double screenHeight;
        private double screenWidth;

        public int Dx { get; set; }
        public int Dy { get; set; }

        public GameElement ChoosenElement { get; set; }
        

        public List<GameElement> ObjectList
        {
            get { return objectList; }
            set { objectList = value; }
        }

        public GameShooter(double screenH, double screenW)
        {
            screenHeight = screenH;
            screenWidth = screenW;
            objectList = new List<GameElement>();
            objectList.Add(GenerateNewItem(70,70));
            GenerateChoosenElement();
        }
        public GameElement GenerateNewItem(int width, int height)
        {
            int number = rnd.Next(1, 101);
            int yCoord = 180;
            if(number<=25)
            {
                return new Circle(height, width) { Location = new Point(screenWidth, yCoord) };
            }
            else if (number <= 50)
            {
                return new Rectangle(height, width) { Location = new Point(screenWidth, yCoord) };
            }
            else if (number <= 75)
            {
                return new Cross(height-15, width-15) { Location = new Point(screenWidth+10, yCoord+10) };
            }
            else
            {
                return new Triangle(height, width) { Location = new Point(screenWidth, yCoord) };
            }

        }
        private void GenerateChoosenElement()
        {
            ChoosenElement = GenerateNewItem(120, 120);
            ChoosenElement.Location = new Point(screenWidth / 2 - ChoosenElement.Width / 2, 10);
        }

        public void DoTurn()
        {

            for (int i = 0; i < ObjectList.Count; i++)
            {
                if (ObjectList[i].Location.X == (int)(screenWidth * 0.8))
                {
                    ObjectList.Add(GenerateNewItem(70, 70));
                }

                ObjectList[i].Location = new Point(ObjectList[i].Location.X - 1, ObjectList[i].Location.Y);

                if (ObjectList[i].Location.X == 0 - ObjectList[i].Width)
                {
                    ObjectList.Remove(ObjectList[i]);
                }
            }


        }
    }
}
