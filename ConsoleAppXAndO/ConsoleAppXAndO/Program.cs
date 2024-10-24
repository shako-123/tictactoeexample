// See https://aka.ms/new-console-template for more information

var board = new char[3,3];
var currentPlayer = 'X';
var movesCount = 0;
var isGameOver = false;

InitializeBoard();

while (isGameOver != true)
{
    PrintBoard();

    int row = -1;
    int col = -1;
    bool isGoodMove = false;

    while (!isGoodMove)
    {
        Console.WriteLine("\nPlease enter a number between 0 and 2:");
        var canParseRow = int.TryParse(Console.ReadLine(), out row);
        Console.WriteLine("\nPlease enter a number between 0 and 2:");
        var canParseCol = int.TryParse(Console.ReadLine(), out col);

        if (!canParseRow || !canParseCol)
        {
            Console.WriteLine("Invalid input");
            continue;
            
        }

        if (row < 0 || row >= board.GetLength(0) || col < 0 || col >= board.GetLength(1))
        {
            Console.WriteLine("Invalid input");
            continue;
        }
        if (board[row, col] != ' ')
        {
            Console.WriteLine("Invalid move");
            continue;
        }

        isGoodMove = true;
    }
    
    UpdateBoard(row, col);
    
    var hasWon = HasWon();
    if (hasWon)
    {
        Console.WriteLine("Player " + currentPlayer + " won");
        isGameOver = true;
    }
    if (movesCount == 9)
    {
        Console.WriteLine("Its draw");
        isGameOver = true;
    }

    if (currentPlayer == 'X')
    {
        currentPlayer = 'O';
    }
    else
    {
        currentPlayer = 'X';
    }
}

bool HasWon()
{
    for (var j = 0; j < 3; j++)
    {
        if (board[j, 0] == currentPlayer && board[j, 1] == currentPlayer && board[j, 2] == currentPlayer)
            return true;
        if (board[0, j] == currentPlayer && board[1, j] == currentPlayer && board[2, j] == currentPlayer)
            return true;

        if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer ||
            board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
        {
            return true;
        }
    }
    return false;
}

void UpdateBoard(int row, int col)
{
    board[row, col] = currentPlayer;
    movesCount++;
}

void InitializeBoard()
{
    for (var i = 0; i < 3; i++)
    {
        for (var j = 0; j < 3; j++)
        {
            board[i, j] = ' ';
        }
    }
}

void PrintBoard()
{
    Console.Clear();
    for (var i = 0; i < 3; i++)
    {
        Console.WriteLine();
        for (var j = 0; j < 3; j++)
        {
            var toPrint = board[i,j] == ' '?  '*' : board[i, j];
            Console.Write(toPrint  + " ");
        }
    }
}