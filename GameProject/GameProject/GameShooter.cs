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

        public List<GameElement> ObjectList
        {
            get { return objectList; }
            set { objectList = value; }
        }

        public GameShooter()
        {
            objectList = new List<GameElement>();
            objectList.Add(new Circle(100, 100) { Location = new Point(0, 180) });
            objectList.Add(new Cross(100, 100) { Location = new Point(150, 180) });
            objectList.Add(new Rectangle(100, 100) { Location = new Point(300, 180) });
            objectList.Add(new Circle(100, 100) { Location = new Point(450, 180) });

        }
    }
}
