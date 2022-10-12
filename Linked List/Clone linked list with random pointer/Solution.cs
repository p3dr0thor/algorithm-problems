using System;

//Clone a linked list with a next and a random pointer.
//step 1: create list of cloned nodes and make node[i] reference cloned node[i]
//step 2: create reference with random (The random pointer of clone is the Random.next of original)
//step 3: separate lists and adjust references.

//Time complexity: O(n)
//Space complexity: O(n)

//Another way to solve the problem:
//Create clonedd list and hash to store reference
//Iterate over list and find random pointer in hash.

class Result
{
    
    public static void Main(string[] args)
    {
        //Create list
        Node rootNode = new Node() { Value = 1 };
        var node = rootNode;

        int i = 2;
        while (i <= 5)
        {
            node.Next = new Node() { Value = i };
            node = node.Next;
            i++;
        }

        //Create random pointers
        rootNode.Random = rootNode.Next.Next.Next.Next; //1 to 5
        rootNode.Next.Random = rootNode.Next.Next.Next; //2 to 4
        rootNode.Next.Next.Random = rootNode; //3 to 1
        rootNode.Next.Next.Next.Random = rootNode.Next.Next; //4 to 3
        rootNode.Next.Next.Next.Next.Random = rootNode.Next; //5 to 2

        Console.WriteLine("Original node without clone:");
        PrintNodes(rootNode);

        var rootNodeClone = Clone(rootNode);

        Console.WriteLine("\nOriginal node:");
        PrintNodes(rootNode);
        Console.WriteLine("\nCloned node:");
        PrintNodes(rootNodeClone);


        Console.WriteLine("\nTesting changing values from original list. Cloned list must not be changed.");
        Console.WriteLine("node.Random.Value = 200;");
        Console.WriteLine("node.Next.Value = 100;");

        rootNode.Random.Value = 200;
        rootNode.Next.Value = 100;

        Console.WriteLine("\nOriginal node:");
        PrintNodes(rootNode);
        Console.WriteLine("\nCloned node:");
        PrintNodes(rootNodeClone);

    }

    private static Node Clone(Node node)
    {
        if (node == null)
            return null;

        //step 1: create list of cloned nodes and make node[i] reference cloned node[i]
        var root = node;

        while (node != null)
        {
            var clonedNode = new Node() { Value = node.Value };
            clonedNode.Next = node.Next;

            node.Next = clonedNode;
            node = node.Next.Next;
        }

        //step 2: create reference with random (The random pointer of clone is the Random.next of original)
        node = root;
        while (node != null)
        {
            node.Next.Random = node.Random.Next;
            node = node.Next.Next;
        }

        //step 3: separate lists and adjust references.
        node = root;
        var rootClone = root.Next;
        var nodeClone = root.Next;
        while (node != null)
        {

            node.Next = node.Next.Next;
            nodeClone.Next = nodeClone.Next?.Next;

            node = node.Next;
            nodeClone = nodeClone.Next;
        }

        return rootClone;
    }

    private static void PrintNodes(Node node)
    {
        while (node != null)
        {
            Console.WriteLine($"node:{node.Value} random:{node.Random?.Value}");
            node = node.Next;
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Random { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
