using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace QuizSolution.Medium
{
    public class CourseSchedule
    {
        public int TopClassCount { get; set; }
        public bool canFinishDFSFail(List<List<int>> graph, List<int> visit, int i)
        {
            if (visit[i] == -1) return false;
            if (visit[i] == 1) return true;
            visit[i] = -1;
            foreach (var a in graph[i])
            {
                if (!canFinishDFSFail(graph, visit, a)) return false;
            }
            visit[i] = 1;
            return true;

        }
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            //太慢
            for (int i = 0; i < prerequisites.Length; i++)
            {
                List<int> visit = new List<int>() { prerequisites[i][0] };
                if (!canFinishDFS(prerequisites[i][1], visit, prerequisites, numCourses, 0))
                {
                    return false;
                }
            }
            return true;
        }

        public bool canFinishDFS(int start, List<int> visit, int[][] prerequisites, int numCourses, int index)
        {
            if (visit.Count > numCourses)
            {
                return false;
            }
            for (int i = 0; i < prerequisites.Length; i++)
            {
                if (prerequisites[i][0] == start)
                {
                    visit.Add(prerequisites[i][1]);

                    if (!canFinishDFS(prerequisites[i][1], visit, prerequisites, numCourses, i))
                    {
                        return false;
                    }
                }
            }
            if (TopClassCount < visit.Count)
            {
                TopClassCount = visit.Count;
            }
            visit.RemoveAt(visit.Count - 1);
            return true;
        }
        

        
    }
    
}
