using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using TelstarLogistics.DataAccess;
using TelstarLogistics.DataAccess.Classes;
using TelstarLogistics.DataAccess.Entities;


namespace TLAPI.Services
{
    public class PathFinder
    {
        private readonly IRoutesService _routesService;

        Graph<int, string> graph = new Graph<int, string>();
        public List<City> cities = new List<City>();
        public PathFinder()
        {
            
            TelstarLogisticsContext dbContext = new TelstarLogisticsContext();
            _routesService = new RoutesService(dbContext);
            cities = GetCities();
            for (int x=0;x<=41;x++)
                graph.AddNode(x);

            string connections = "1,2,5;1,6,2;1,7,5;2,1,5;2,4,3;4,2,3;4,8,6;5,8,4;6,1,2;6,7,5;6,9,8;7,1,5;7,6,5;8,4,6;8,5,4;8,15,3;9,6,8;9,16,4;10,16,5;10,17,4;10,18,4;11,15,4;11,18,7;11,22,6;12,14,3;12,15,4;13,14,3;13,21,6;14,12,3;14,13,3;14,20,3;15,8,3;15,11,4;15,12,4;15,18,7;15,19,2;15,22,6;16,9,4;16,10,5;16,17,5;17,10,4;17,16,5;18,10,5;18,11,7;18,15,7;18,22,5;19,15,2;19,20,2;20,14,3;20,19,2;20,21,5;20,23,4;20,26,6;21,13,6;21,20,5;21,26,3;22,11,6;22,15,6;22,18,5;22,24,3;23,20,4;23,24,4;24,22,3;24,23,4;24,26,10;24,28,11;24,30,11;26,20,6;26,21,3;26,24,10;26,28,5;26,30,4;28,24,11;28,26,5;28,29,4;28,30,3;29,28,4;29,32,4;30,24,11;30,26,4;30,28,3;32,29,4";

            string[] connectionsArray = connections.Split(';');

            using (var db = new TelstarLogisticsContext())
            {
                foreach (string elementString in connectionsArray)
                {
                    string[] elemenSt = elementString.Split(',');
                    graph.Connect(UInt32.Parse(elemenSt[0]), uint.Parse(elemenSt[1]), Int32.Parse(elemenSt[2]), "");
                }
            }
        }

        public void populate()
        {
            string connections = "1,2,5;1,6,2;1,7,5;2,1,5;2,4,3;4,2,3;4,8,6;5,8,4;6,1,2;6,7,5;6,9,8;7,1,5;7,6,5;8,4,6;8,5,4;8,15,3;9,6,8;9,16,4;10,16,5;10,17,4;10,18,4;11,15,4;11,18,7;11,22,6;12,14,3;12,15,4;13,14,3;13,21,6;14,12,3;14,13,3;14,20,3;15,8,3;15,11,4;15,12,4;15,18,7;15,19,2;15,22,6;16,9,4;16,10,5;16,17,5;17,10,4;17,16,5;18,10,5;18,11,7;18,15,7;18,22,5;19,15,2;19,20,2;20,14,3;20,19,2;20,21,5;20,23,4;20,26,6;21,13,6;21,20,5;21,26,3;22,11,6;22,15,6;22,18,5;22,24,3;23,20,4;23,24,4;24,22,3;24,23,4;24,26,10;24,28,11;24,30,11;26,20,6;26,21,3;26,24,10;26,28,5;26,30,4;28,24,11;28,26,5;28,29,4;28,30,3;29,28,4;29,32,4;30,24,11;30,26,4;30,28,3;32,29,4";

            string[] connectionsArray = connections.Split(';');

            using (var db = new TelstarLogisticsContext())
            {
                foreach (string elementString in connectionsArray)
                {
                    string[] elemenSt = elementString.Split(',');
                    graph.Connect(UInt32.Parse(elemenSt[0]), uint.Parse(elemenSt[1]), Int32.Parse(elemenSt[2]), "");
                    var gg = UInt32.Parse(elemenSt[0]);
                    var hh = UInt32.Parse(elemenSt[1]);
                    var name1 = MapIdToName(gg);
                    var name2 = MapIdToName(hh);
                    var cityName1 =
                        db.Cities.FirstOrDefault(x => x.Name.Equals(name1));
                    var cityName2 =
                        db.Cities.FirstOrDefault(x => x.Name.Equals(name2));

                    db.RouteSegments.Add((new RouteSegment()
                    {
                        CityFrom = cityName1,
                        CityTo = cityName2,
                        Duration = Int32.Parse(elemenSt[2]) * 4,
                        Price = Int32.Parse(elemenSt[2]) * 3
                    }));
                    db.SaveChanges();
                }
            }
        }
        public uint MapNameToId(string name)
        {
            int id = cities.
                FirstOrDefault(x => x.Name.Equals(name)).
                Id;

            return (UInt32) id;
        }

        public string MapIdToName(uint id)
        {
            string name = cities.FirstOrDefault(x => x.Id == id).Name;
            return name;
        }
        public int GetDistance(uint fromCity, uint toCity)
        {
            ShortestPathResult result = graph.Dijkstra(fromCity, toCity); //result contains the shortest path

            var path = result.GetPath();
            
            return result.Distance;
        }

        public List<City> GetCities()
        {
            var cities = _routesService.GetCities();
            return cities;
        }


        //public int findPath(string fromCity, string toCity)
        //{
        //    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data/distances.csv");
        //    string[] lines = File.ReadAllLines(path);



        //    var stuff = lines.Select(l => lines.ToArray()).ToArray();



        //    string[] firstRow = stuff[0];



        //    int from = Array.FindIndex(firstRow, w => w.Equals(fromCity)) - 1;
        //    int to = Array.FindIndex(firstRow, w => w.Equals(toCity)) - 1;



        //    int[,] graph = new int[lines.Length - 1, lines.Length - 1];



        //    for (int i = 0; i < graph.Length; i++)
        //    {
        //        for (int j = 0; j < graph.Length; j++)
        //        {
        //            graph[i, j] = Int32.Parse(stuff[i][j]);
        //        }
        //    }

        //    int distance = Dijkstra(graph, to, from, 4);

        //    return distance;
        //}



        //private int Dijkstra(int[,] graph, int source, int destination, int verticesCount)
        //{
        //    int[] distance = new int[verticesCount];
        //    bool[] shortestPathTreeSet = new bool[verticesCount];



        //    for (int i = 0; i < verticesCount; ++i)
        //    {
        //        distance[i] = int.MaxValue;
        //        shortestPathTreeSet[i] = false;
        //    }



        //    distance[source] = 0;



        //    for (int count = 0; count < verticesCount - 1; ++count)
        //    {
        //        int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
        //        shortestPathTreeSet[u] = true;



        //        for (int v = 0; v < verticesCount; ++v)
        //            if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
        //                distance[v] = distance[u] + graph[u, v];
        //    }



        //    return distance[destination];
        //}



        //private int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        //{
        //    int min = int.MaxValue;
        //    int minIndex = 0;



        //    for (int v = 0; v < verticesCount; ++v)
        //    {
        //        if (shortestPathTreeSet[v] == false && distance[v] <= min)
        //        {
        //            min = distance[v];
        //            minIndex = v;
        //        }
        //    }
        //    return minIndex;
        //}
    }
}