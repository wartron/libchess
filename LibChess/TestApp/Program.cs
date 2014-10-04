using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibChess;
using Client;

namespace TestApp
{
    public class Program
    {
        //static Game game = new Game(new List<Player>() { new Player("Karl"), new Player("Olle") });
        [STAThreadAttribute]
        static void Main(string[] args)
        {
           // GameWindow g = new GameWindow();
            Register r = new Register("WebChess@hotmail.com", "mattias@hotmail.com");
            r.Send();
            Console.WriteLine(r.MailSubject);
            Console.WriteLine(r.MailBody);
            Player p = new Player();
            p.Username = "Idiot1";
            Player p2 = new Player();
            p2.Username = "Idiot2";
            Game g = new Game(new List<Player>() { p, p2  });
            //Client.Appearance a = new Client.Appearance(g.Pf);
            Application.Run(new GameWindow(null, g));
           /*Test("Rook", new List<MoveBehaviour>() { new RookMoveBehaviour() });
            Test("Bishop", new List<MoveBehaviour>() { new BishopMoveBehaviour() });
            Test("King", new List<MoveBehaviour>() { new KingMoveBehaviour() });
            Test("Queen", new List<MoveBehaviour>() { new BishopMoveBehaviour(), new RookMoveBehaviour() });
            Test("Knight", new List<MoveBehaviour>() { new KnightMoveBehaviour() });
            Test("White Pawn", new List<MoveBehaviour>() { new WhitePawnMoveBehaviour() });
            Test("Black Pawn", new List<MoveBehaviour>() { new BlackPawnMoveBehaviour() });
            Console.WriteLine("Press return to quit!");*/
            Console.ReadLine();
            
        }

        static void Test(string Piece, List<MoveBehaviour> MoveBehaviours)
        {
            
            //Console.WriteLine("All squares a {0} at coords 4,4 can move to:", Piece);
            //Piece rook = new Piece(game.Players[0], game.Board[4, 4], MoveBehaviours);
            //avkommentera nedanstående rad för att lägga till en till pjäs, ändra gärna i koden för att testa olika varianter!
            //new Piece(game.Players[1], game.Board[5, 3], new List<MoveBehaviour>() { new RookMoveBehaviour() } );

            //List<Square> squares = rook.GetAccessibleSquares();

            /*foreach (Square lol in squares)
            {
                Console.WriteLine(lol.X + ", " + lol.Y);
            }*/
        }
    }
}
