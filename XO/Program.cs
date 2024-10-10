bool gameOver = false;
string[,] board = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
int currentPlayer;
string choice;
//string aiChoice;

ChooseSide();
while (!gameOver)
{
    DrawBoard();
    choice = (currentPlayer == 1) ? "X" : "O";
    Input();
    //AiTurn();
    if (EndGame() == true)
    {
        DrawBoard();
        gameOver = true;
        Console.WriteLine($"Выиграл игрок {currentPlayer}");
    }
    if (Draw() == true)
    {
        DrawBoard();
        gameOver = true;
        Console.WriteLine("Ничья");
    }
    currentPlayer = (currentPlayer == 1) ? 2 : 1;
}
void ChooseSide()
{
    Console.WriteLine("Выберите чем играть: Х или О");
    choice = Console.ReadLine().ToUpper();
    switch (choice)
    {
        case "X":
            currentPlayer = 1;
            break;
        case "O":
            currentPlayer = 2;
            break;
        default:
            ChooseSide();
            break;
    }
}

void Input()
{
    Console.WriteLine($"Игрок {currentPlayer}, введите номер ячейки:");

    // Проверяем корректность ввода: число от 1 до 9
    string userCell = Console.ReadLine();
    switch (userCell)
    {
        case "1":
            FillCell(0, 0, choice);
            break;
        case "2":
            FillCell(0, 1, choice);
            break;
        case "3":
            FillCell(0, 2, choice);
            break;
        case "4":
            FillCell(1, 0, choice);
            break;
        case "5":
            FillCell(1, 1, choice);
            break;
        case "6":
            FillCell(1, 2, choice);
            break;
        case "7":
            FillCell(2, 0, choice);
            break;
        case "8":
            FillCell(2, 1, choice);
            break;
        case "9":
            FillCell(2, 2, choice);
            break;
        default:
            Console.WriteLine("Выберите клетку 1-9");
            Input();
            break;
    }
}

/*
void AiTurn()
{
    Random rand = new Random();
    aiChoice=(choice=="X") ? "O" : "X";
    int randomRow = rand.Next(2);
    int randomCol = rand.Next(2);
    if (board[randomRow, randomCol] != aiChoice)
    {
        FillCell(randomRow,randomCol,aiChoice);
    }
    else 
    {
        AiTurn();
    }
}
*/
void DrawBoard()
{
    Console.Clear();
    string firstRow = String.Format("|{0,1}|{1,1}|{2,1}|", board[0, 0], board[0, 1], board[0, 2]);
    string secondRow = String.Format("|{0,1}|{1,1}|{2,1}|", board[1, 0], board[1, 1], board[1, 2]);
    string thirdRow = String.Format("|{0,1}|{1,1}|{2,1}|", board[2, 0], board[2, 1], board[2, 2]);
    Console.WriteLine(firstRow);
    Console.WriteLine(secondRow);
    Console.WriteLine(thirdRow);
}
bool EndGame()
{
    return ((board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2]) ||
    (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2]) ||
    (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2]) ||
    (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0]) ||
    (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1]) ||
    (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2]) ||
    (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) ||
    (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]));
}
bool Draw()
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            if (board[i, j] is not "X" and not "O")
            {
                return false;
            }
        }
    }
    return true;
}

void FillCell(int row, int col, string mark)
{
    if (board[row, col] != "X" && board[row, col] != "O")
    {
        board[row, col] = mark;
    }
    else
    {
        Console.WriteLine("Ячейка занята");
        Input();
    }
}