using System.Linq;
using System.Collections.Generic;
using System;

namespace DjiskaAlgorithim
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var graph = new Graph();
            var intializedGraph = graph.InitalizeGraph();
            var unvisitedNodes = intializedGraph.Nodes.ToList();
            List<string> visitedNodes = new List<string>();
            var fixedNode = intializedGraph.Nodes.FirstOrDefault();
            var sequence = 0;
            var distanceList = new List<ConnectedNode>
            {
                new ConnectedNode(){ Name = "A", Distance = null, Sequence = 0 },
                new ConnectedNode(){ Name = "B", Distance = 0 },
                new ConnectedNode(){ Name = "C", Distance = 0 },
                new ConnectedNode(){ Name = "D", Distance = 0 },
                new ConnectedNode(){ Name = "E", Distance = 0 },
            };

            foreach (var connectedNode in fixedNode.ConnectedNodes)
            {
                var index = distanceList.FindIndex(d => d.Name == connectedNode.Name);
                distanceList[index].Distance = connectedNode.Distance;
            }
            visitedNodes.Add(fixedNode.Name);
            unvisitedNodes.Remove(fixedNode);
            sequence++;

            for (int i = 0; i < unvisitedNodes.Count; i++)
            {
                var lowestKnownValueKey = FindConnectedNodeWithTheSmallestDistance(distanceList, visitedNodes);
                var indexList = distanceList.FindIndex(d => d.Name == lowestKnownValueKey);
                distanceList[indexList].Sequence = sequence;
                sequence++;
                var currentNode = unvisitedNodes.Where(un => un.Name == lowestKnownValueKey).Select(un => new Node
                {
                    Name = un.Name,
                    ConnectedNodes = un.ConnectedNodes,
                }).FirstOrDefault();
                    
                foreach (var connectedNode in currentNode?.ConnectedNodes)
                {
                    if (!visitedNodes.Contains(connectedNode.Name))
                    {
                        var index = distanceList.FindIndex((d) => d.Name == connectedNode.Name);
                        var newNodeDistance = connectedNode.Distance + distanceList[index].Distance;

                        if (distanceList[index].Distance == 0)
                        {
                            distanceList[index].Distance = newNodeDistance;
                        }
                        else if (distanceList[index].Distance > newNodeDistance)
                        {
                            distanceList[index].Distance = newNodeDistance;
                        }
                    }
                }
                visitedNodes.Add(currentNode.Name);
                unvisitedNodes.Remove(currentNode);
            }

            var finalOrder = distanceList.OrderBy(dd => dd.Sequence);
            var stop = 0;
            foreach (var pair in finalOrder)
            {
                Console.WriteLine($"Stop {stop} is {pair.Name}. Distance is {pair.Distance}");
                stop++;
            }
            var totalDistance = distanceList.Sum(d => d.Distance);
            Console.WriteLine($"This route has the shortest distance of {totalDistance}");
        }

        private static string FindConnectedNodeWithTheSmallestDistance(List<ConnectedNode> distanceList, List<string> visitedNodes)
        {
            // a node which distance was calculated for will not be 0,
            // so we can query to find the lowest value based on if it's not 0 but its not in the visited nodes
            return distanceList.Where(dl => dl.Distance > 0 && dl.Distance != null && !visitedNodes.Contains(dl.Name)).OrderBy(dl => dl.Distance).FirstOrDefault().Name;
        }
        
    }
    

    

}

