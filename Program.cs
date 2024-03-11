using QuizSolution;
using QuizSolution.Easy;
using QuizSolution.Hard;
using QuizSolution.Medium;
using System;
//
int[] A = { 3,2 };
int[] B = { 2, 2, 5, 2, 3, 6 };
//int[] C = { -1, 1 };
//int[] D = { 1, -1 };
string[] ZZ = { "eae", "ea", "aaf", "bda", "fcf", "dc", "ac", "ce", "cefde", "dabae" };
string[] Z = { "hit" };
var C = 2;
var D = 2;
var ZZZ = "CAC";
//IList<IList<int>> ZZZ = new List<IList<int>>
//{
//    new List<int> { 1 },
//    new List<int> { 2 },
//    new List<int> { 3 },
//    new List<int>()
//};

int[][] DD =
    {
    new[] { 1,2,-1 },
    new[] { 4,-1,6},
    //new[] { 7,8,9 },
    //new[] { 0, 1, 0, 0 }
    };
//[1,0],[0,3],[0,2],[3,2],[2,5],[4,5],[5,6],[2,4]
int[][] E =
{
    new[] {2},
    new[] { 3,4},
    new[] { 6,5,7},
    new[] {4,1,8,3 },
    //new[] { 1,1,1,1,1 },
    //new[] { 16, 17 },
    //new[] { 5, 6 },
    //new[] { 2, 4 }
};
int[] F = new[] { 4, 3, 3, 8, 5, 2 };
char[][] E2 = { new[] { '1' } };
char[][] E3 = {
    new[]{'0','1','1','0','0' },
    new[]{'1','1','1','1','0' },
    new[]{'1','1','1','0','0' },
    new[]{'1','0','1','1','0' },
    //new[]{'0','1','1','1' },
    };
//, 'b', 'b', 'b','b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b'
//char[][] Board =
//{new []{'.', '.', '.', '.','9', '.', '.','5','.'},
//new []{ '.','4', '.','1', '.', '.', '.', '.', '.'},
//new []{ '.', '.', '.', '.', '.','3', '.', '.','1'},
//new []{'8', '.', '.', '.', '.', '.','.','2','.'},
//new []{ '.', '.','2', '.','7', '.', '.', '.', '.'},
//new []{ '.','1','5', '.', '.', '.', '.', '.', '.'},
//new []{ '.', '.', '.', '.', '.', '2','.', '.', '.'},
//new []{ '.','2', '.', '9','.', '.', '.', '.', '.' },
//new []{ '.', '.','4', '.', '.', '.', '.', '.', '.' } };
//Console.WriteLine(new GenerateRandomPointInACircle(C, D, z).RandPoint());
Console.WriteLine(new MaximumNumberOfOperationsWithTheSameScoreI().MaxOperations(A));
Console.ReadLine();
