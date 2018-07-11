using System.Linq;
namespace _25linegames
{class Program{
        static int[] playerPos = new int[] { 0, 0 };
        static int[] enemypos = new int[] { new System.Random().Next(0, 2), 50 };
        static int score = 0;
        static System.Collections.Generic.Dictionary<System.ConsoleKey, System.Action> moves = new System.Collections.Generic.Dictionary<System.ConsoleKey, System.Action>() { { System.ConsoleKey.W, () => playerPos[0] = 0 }, { System.ConsoleKey.S, () => playerPos[0] = 1 } };
        private static string Line(int line) => new string((Enumerable.Range(0, 50).ToList().Select(x => playerPos[0] == line && playerPos[1] == x ? 'X' : enemypos[0] == line && enemypos[1] == x ? 'E' : ' ').ToArray()));
        static void Main(string[] args)
        { System.Threading.Tasks.Task.Run(() =>{
                while (true){
                if (playerPos[0] == enemypos[0] && playerPos[1] == enemypos[1]){
                        System.Console.WriteLine($"Game Over. Your score is:{score}");
                        break;}
                    else if (playerPos[1] == 40) System.Console.WriteLine("You won!");
                    System.Console.Clear();
                    for (int i = 0; i < 2; i++) System.Console.WriteLine(Line(i));
                    System.Console.WriteLine($"Score:{score}");
                    System.Threading.Thread.Sleep(9);
                    enemypos[1]--;
                    if (enemypos[1] == -1){
                        enemypos = new int[] { new System.Random().Next(0, 2), 50 };
                        score = ++playerPos[1];}}});
        while (true) new[] { System.Console.ReadKey() }.Select(e => moves.Where(x => x.Key == e.Key).FirstOrDefault().Value).FirstOrDefault()?.Invoke();}}}
