using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GridGame
{

    class Program
    {
        static void Main(string[] args)
        {
            Game myGame = new Game(22, 8);
            while (true)
            {
                myGame.UpdateBoard();
                myGame.DrawBoard();
                //Console.ReadKey();
            }
        }
    }

    class Game
    {

        List<GameObject> GameObjects = new List<GameObject>();

        public Game(int xSize, int ySize)
        {
            for (int i = 0; i < ySize + 2; i++)
            {
                for (int j = 0; j < xSize + 2; j++)
                {
                    if (j == 0 || i == 0 || i == ySize + 1 || j == xSize + 1)
                    {
                        GameObjects.Add(new Wall(j, i));
                    }
                }
            }
            GameObjects.Add(new Player(5, 5));

        }

        public void DrawBoard()
        {
            foreach (GameObject gameObject in GameObjects)
            {
                gameObject.Draw(5, 3);
            }

        }

        public void UpdateBoard()
        {
            foreach (GameObject gameObject in GameObjects)
            {
                gameObject.Update();
            }

        }
    }

    abstract class GameObject
    {
        public int XPosition;
        public int YPosition;
        public abstract void Draw(int xBoxSize, int yBoxSize);
        public abstract void Update();
    }

    class Wall : GameObject
    {
        public Wall(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }

        public override void Draw(int xBoxSize, int yBoxSize)
        {
            int startX = XPosition * xBoxSize;
            int startY = YPosition * yBoxSize;
            Console.SetCursorPosition(startX, startY);
            Console.Write("█████");
            Console.SetCursorPosition(startX, startY + 1);
            Console.Write("█████");
            Console.SetCursorPosition(startX, startY + 2);
            Console.Write("█████");
        }

        public override void Update()
        {

        }
    }

    class Player : GameObject
    {
        int lastX;
        int lastY;

        public Player(int xPos, int yPos)
        {
            XPosition = xPos;
            YPosition = yPos;
        }

        public override void Draw(int xBoxSize, int yBoxSize)
        {
            int curX = XPosition * xBoxSize;
            int curY = YPosition * yBoxSize;
            Console.SetCursorPosition(curX, curY);
            Console.Write("█████");
            Console.SetCursorPosition(curX, curY + 1);
            Console.Write("█████");
            Console.SetCursorPosition(curX, curY + 2);
            Console.Write("█████");

            lastY = curY;
            lastX = curX;
        }

        public override void Update()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();   

            Erase();

            if (keyInfo.Key == ConsoleKey.W)
            {
                YPosition--;
            }
            else if (keyInfo.Key == ConsoleKey.S)
            {
                YPosition++;
            }
            else if (keyInfo.Key == ConsoleKey.D)
            {
                XPosition++;
            }
            else if (keyInfo.Key == ConsoleKey.A)
            {
                XPosition--;
            }
        }

        public void Erase()
        {
            Console.SetCursorPosition(lastX, lastY);
            Console.Write("     ");
            Console.SetCursorPosition(lastX, lastY + 1);
            Console.Write("     ");
            Console.SetCursorPosition(lastX, lastY + 2);
            Console.Write("     ");
        }
    }
}