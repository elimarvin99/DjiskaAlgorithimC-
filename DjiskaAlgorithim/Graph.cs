using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DjiskaAlgorithim
{
    public class Graph : IGraph
    {
        public List<Node> Nodes { get; set; }

        public Graph InitalizeGraph()
        {
            var graph = new Graph()
            {
                Nodes = new List<Node>()
                    {
                        new Node() { 
                            Name = "A", 
                            ConnectedNodes = new List<ConnectedNode>()
                            { 
                                new ConnectedNode() 
                                {
                                    Name = "B",
                                    Distance = 4
                                },
                                new ConnectedNode()
                                {
                                    Name= "C",
                                    Distance = 2
                                }
                            }
                        },
                        new Node() {
                            Name = "B",
                            ConnectedNodes = new List<ConnectedNode>()
                            {
                                new ConnectedNode()
                                {
                                    Name = "A",
                                    Distance = 4
                                },
                                new ConnectedNode()
                                {
                                    Name= "C",
                                    Distance = 1
                                },
                                new ConnectedNode()
                                {
                                    Name = "D",
                                    Distance = 3
                                },
                                new ConnectedNode()
                                {
                                    Name= "E",
                                    Distance = 2
                                }
                            }
                        },
                        new Node() {
                            Name = "C",
                            ConnectedNodes = new List<ConnectedNode>()
                            {
                                new ConnectedNode()
                                {
                                    Name = "A",
                                    Distance = 2
                                },
                                new ConnectedNode()
                                {
                                    Name= "B",
                                    Distance = 1
                                }
                            }
                        },
                        new Node() {
                            Name = "D",
                            ConnectedNodes = new List<ConnectedNode>()
                            {
                                new ConnectedNode()
                                {
                                    Name = "E",
                                    Distance = 5
                                },
                                new ConnectedNode()
                                {
                                    Name= "B",
                                    Distance = 3
                                }
                            }
                        },
                        new Node() {
                            Name = "E",
                            ConnectedNodes = new List<ConnectedNode>()
                            {
                                new ConnectedNode()
                                {
                                    Name = "D",
                                    Distance = 5
                                },
                                new ConnectedNode()
                                {
                                    Name= "B",
                                    Distance = 2
                                }
                            }
                        },
                    }
            };

            return graph;
        }
    }

    public interface IGraph
    {
        public Graph InitalizeGraph();
    }

}
