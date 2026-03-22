namespace LeetCodeTestApp;

public class TictactoeTask
{
    private enum Players
    {
        A, // X
        B  // 0
    }
    public string Tictactoe(int[][] moves)
    {
        var field = new Players?[3, 3];
        var player = Players.A;
        foreach (var t in moves)
        {
            field[t[0], t[1]] = player;
            
            if (IsWin(field))
                return player.ToString();
            player = player == Players.A ? Players.B : Players.A;
        }

        if (moves.Length < 9)
            return "Pending";
        return "Draw";
    }

    private bool IsWin(Players?[,] field)
    {
        var firstDiagonal = field[0, 0] == field[1, 1] && field[1, 1] == field[2, 2] && field[0, 0] != null;
        if (firstDiagonal)
            return true;
        var secondDiagonal = field[2, 0] == field[1, 1] && field[1, 1] == field[0, 2] && field[2, 0] != null;
        if (secondDiagonal)
            return true;
        for (var c = 0; c < 3; c++)
            if (field[0, c] == field[1, c] && field[1, c] == field[2, c] && field[0, c] != null)
                return true;
        for (var r = 0; r < 3; r++)
            if (field[r, 0] == field[r, 1] && field[r, 1] == field[r, 2] && field[r, 0] != null)
                return true;
        return false;
    }
}