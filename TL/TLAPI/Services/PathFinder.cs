using System;
using System.Collections.Generic;
using System.Linq;

namespace TLAPI.Services
{
    public class PathFinder
    {
        public static IEnumerable<int> StringToIntList(string str)
        {
            if (String.IsNullOrEmpty(str))
                yield break;

            foreach(var s in str.Split(',')) {
                int num;
                if (int.TryParse(s, out num))
                    yield return num;
            }
        }
        
        public int findPath(int from, int to)
        {
            var lines = System.IO.File.ReadAllLines("distances.csv");

            int[][] stuff = lines.Select(l => StringToIntList(lines[0]).ToArray()).ToArray();
            
            int distance = Dijkstra(stuff, from, to, 4);
            
            return distance;
        }

        private int Dijkstra(int[][] graph, int source, int destination, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u][v]) && distance[u] != int.MaxValue && distance[u] + graph[u][v] < distance[v])
                        distance[v] = distance[u] + graph[u][v];
            }

            return distance[destination];
        }

        private int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
    }
}