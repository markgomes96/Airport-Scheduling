using System;
using System.Collections.Generic;

public class Node {

	public Airport airport;
	public List<Node> neighbors;
	public List<double> weights;
	public bool visited;
	public double distance;
	public Node previous;

	public Node(Airport port = new Airport()) {
		this.airport = port;
		this.neighbors = new List<Node>();
		this.weights = new List<double>();
		this.visited = false;
		this.distance = 99999.9;
		this.previous = null;
	}

	/*---------------------------------------------------------
	 * Method: addNeighbor
	 *
	 * Purpose: Connects this node to another node.
	 *          The other node is added to the neighbor list
	 *          and a corresponding weight to the weights list.
	 *          The new connection goes ONE WAY.
	 *--------------------------------------------------------*/
	public void addNeighbor(Node n, double weight) {
		this.neighbors.Add(n);
		this.weights.Add(weight);
	}

}

