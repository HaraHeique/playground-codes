namespace Others.LeetCode.Solutions;

/// <summary>
/// Baseado no vídeo a seguir: https://youtu.be/3R9IszcQGeA?si=926Gi8aal-ZmqzNH
/// </summary>
public class WordSearchSolution
{
    private const char _inexistentToken = '#';
    private const int _secondLetterIndex = 1;
    private static HashSet<(int Line, int Column)> _positionsAlreadyVisited = [];

    public static void ShowSolution(params string[] _) 
    {
        // char[][] board =  
        // [
        //     ['X', 'A', 'G'],
        //     ['F', 'T', 'H'],
        //     ['E', 'O', 'P']
        // ];
        // string word = "GATO";

        char[][] board =  
        [
            ['A', 'B', 'C', 'D'],
            ['S', 'F', 'C', 'S'],
            ['A', 'D', 'C', 'E']
        ];
        string word = "ABCCCD";

        bool result = Exists(board, word);

        if (result) Console.WriteLine("FOUND IT!");
        else Console.WriteLine("It didn't find it!");
    }

    private static bool Exists(char[][] board, string word)
    {
        var possiblePositions = FindPossiblePositionsInBoard(board, word);

        if (possiblePositions.Count == 0) return false;

        foreach (var position in possiblePositions)
        {
            _positionsAlreadyVisited.Clear();
            if (ExistsInBoard(position, board, word, _secondLetterIndex)) return true;
        }

        return false;
    }

    private static List<(int Line, int Column)> FindPossiblePositionsInBoard(char[][] board, string word)
    {
        List<(int Line, int Column)> possibleWordsPositions = new();
        char firstLetter = word[0];

        for (int lineIndex = 0; lineIndex < board.Length; lineIndex++)
        {
            int qntColumns = board[lineIndex].Length;

            for (int colIndex = 0; colIndex < qntColumns; colIndex++)
            {
                char currentLetter = board[lineIndex][colIndex];

                if (currentLetter != firstLetter) continue;

                possibleWordsPositions.Add((lineIndex, colIndex));
            }
        }

        return possibleWordsPositions;
    }

    private static bool ExistsInBoard((int Line, int Column) positionToVerify, char[][] board, string word, int letterIndex)
    {
        if (AllLettersExistsInBoard(word, letterIndex)) return true;

        if (_positionsAlreadyVisited.Contains(positionToVerify)) return false;
        _positionsAlreadyVisited.Add(positionToVerify);

        char letterToFind = word[letterIndex];

        char upLetter = LetterFromDirection((positionToVerify.Line - 1, positionToVerify.Column), board);

        if (upLetter == letterToFind && ExistsInBoard((positionToVerify.Line - 1, positionToVerify.Column), board, word, letterIndex + 1))
            return true;

        char downLetter = LetterFromDirection((positionToVerify.Line + 1, positionToVerify.Column), board);

        if (downLetter == letterToFind && ExistsInBoard((positionToVerify.Line + 1, positionToVerify.Column), board, word, letterIndex + 1))
            return true;

        char leftLetter = LetterFromDirection((positionToVerify.Line, positionToVerify.Column - 1), board);

        if (leftLetter == letterToFind && ExistsInBoard((positionToVerify.Line, positionToVerify.Column - 1), board, word, letterIndex + 1))
            return true;

        char rightLetter = LetterFromDirection((positionToVerify.Line, positionToVerify.Column + 1), board);

        if (rightLetter == letterToFind && ExistsInBoard((positionToVerify.Line, positionToVerify.Column + 1), board, word, letterIndex + 1))
            return true;

        return false;

        static bool AllLettersExistsInBoard(string word, int letterIndex) => word.Length == letterIndex;

        static char LetterFromDirection((int Line, int Column) positionToSearch, char[][] board) 
        {
            int maxRowIndex = board.Length - 1;
            int maxColumnIndex = board.First().Length - 1;

            if (positionToSearch.Line < 0 || positionToSearch.Line > maxRowIndex) 
                return _inexistentToken;

            if (positionToSearch.Column < 0 || positionToSearch.Column > maxColumnIndex)
                return _inexistentToken;

            return board[positionToSearch.Line][positionToSearch.Column];
        }
    }
}