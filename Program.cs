using EnumsNET;
using LibVLCSharp.Shared;
using QuizSolution;
using QuizSolution.Easy;
using QuizSolution.Hard;
using QuizSolution.Medium;
using System;

int[] A = { 1,3 };
int[] B = { 2,7};
//int[] C = { -1, 1 };
//int[] D = { 1, -1 };
string[] ZZ = { "eae", "ea", "aaf", "bda", "fcf", "dc", "ac", "ce", "cefde", "dabae" };
string[] Z = { "hit" };
var C = "a2345678999999999999999";
var D = 1;
var z = 0;

int[][] DD =
    {
    new[] { 1,1 },
    new[] { 3,4 }
    };
//[1,0],[0,3],[0,2],[3,2],[2,5],[4,5],[5,6],[2,4]
int[][] E =
{
    new[] {1,1,0,0,0},
    new[] { 1,1,1,1,0},
    new[] { 1,0,0,0,0},
    new[] { 1,1,0,0,0 },
    new[] { 1,1,1,1,1 },
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
//Console.WriteLine(B.Sum());
//Console.WriteLine(new GenerateRandomPointInACircle(C, D, z).RandPoint());
Console.WriteLine(new DecodedStringAtIndex().DecodeAtIndex(C,D));
Console.ReadLine();


//using (var libVLC = new LibVLC())
//{
//    using (var mediaPlayer = new MediaPlayer(libVLC))
//    {
//        // 指定要播放的影片文件的路徑
//        var media = new Media(libVLC, new Uri("\\\\fsha03\\產學合作-撕膠行為偵測\\Cam_1\\2023-09-27\\2023-09-27 04-20-11.mp4"));

//        mediaPlayer.Play(media);

//        Console.WriteLine("Press any key to exit...");
//        Console.ReadKey();
//    }
//}
