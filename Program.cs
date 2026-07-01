using System.Numerics;
using Raylib_cs;

namespace tjack_bot;

class Program
{
    static void Main(string[] args)
    {
        byte[] gameState = [
            3, 5, 4, 2, 1, 4, 5, 3,
            6, 6, 6, 6, 6, 6, 6, 6,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0,
            14, 14, 14, 14, 14, 14, 14, 14,
            11, 13, 12, 10, 9, 12, 13, 11
        ];

        int g = 100;

        Raylib.InitWindow(800, 800, "TjackBot");
        Raylib.SetTargetFPS(60);

        Texture2D pieces = Raylib.LoadTexture("pieces.png");

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            for (int y = 0; y < 8; y++)
            {
                for (int x = 0; x < 8; x++)
                {
                    if ((x + y) % 2 == 0)
                    {
                        Raylib.DrawRectangle(x * g, y * g, g, g, Color.White);
                    }

                    int piece = gameState[y * 8 + x];
                    Raylib.DrawTexturePro(
                        pieces,
                        new Rectangle(piece * 8, 0, 8, 8),
                        new Rectangle(x * g + 10, y * g + 10, 80, 80),
                        Vector2.Zero,
                        0,
                        Color.White
                    );
                }
            }

            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}