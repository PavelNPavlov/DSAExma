//Source: https://github.com/TelerikAcademy/Data-Structures-and-Algorithms/blob/master/03.%20Trees-and-Traversals/demos/Trees.cs
using System;
using System.Collections.Generic;

namespace Tree
{
    public class TreeNode<T>
    {
        private T value;
        private bool hasParent;
        private List<TreeNode<T>> children;

        public TreeNode(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }
            this.Value = value;
            this.children = new List<TreeNode<T>>();
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public int ChildrenCount
        {
            get
            {
                return this.children.Count;
            }
        }

        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }

            if (child.hasParent)
            {
                throw new ArgumentException(
                    "The node already has a parent!");
            }

            child.hasParent = true;
            this.children.Add(child);
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.children[index];
        }
    }

    public class Tree<T>
    {
        private TreeNode<T> root;

        public Tree(T value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(
                    "Cannot insert null value!");
            }

            this.Root = new TreeNode<T>(value);
        }

        public Tree(T value, params Tree<T>[] children) : this(value)
        {
            foreach (Tree<T> child in children)
            {
                this.root.AddChild(child.root);
            }
        }

        /// <summary>
        /// The root node or null if the tree is empty
        /// </summary>
        public TreeNode<T> Root
        {
            get
            {
                return this.root;
            }
            private set
            {
                this.root = value;
            }
        }

        //recursive dfs
        private void TraverseDFS(TreeNode<T> root, string spaces)
        {
            //bottom comes when method tries to travers the children of a node with no children
            if (root == null)
            {
                return;
            }

            //writes out values
            Console.WriteLine(spaces + root.Value);

            //get children, which form subtrees and repeat the algorithm for them
            TreeNode<T> child = null;
            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                this.TraverseDFS(child, spaces + "   ");
            }
            //when algorithm is reaped for all children then this subtree is traverse
            //So when we get to a node with no children the method will simply return, go up one step and continues with the next child
        }

        public void TraverseDFS()
        {
            //call DFS for the root, hence traverse the entire tree
            this.TraverseDFS(this.root, string.Empty);
        }

        //BFS with a queue
        public void TraverseBFS()
        {
            //set up queue, First in First Out
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            //Add the root
            queue.Enqueue(this.root);
            while (queue.Count > 0)
            {
                //Detach the node in first position, which for first cycle is the root
                TreeNode<T> currentNode = queue.Dequeue();
                //Write value
                Console.Write("{0} ", currentNode.Value);
                //Add all cildren
                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    queue.Enqueue(childNode);
                }
                //In the next cycle the first child will be teh first element. All its children will be added.
                //Third cycle second child will be first element and then its children wiil be added to the back of the queue
            }
        }

        //Itterative DFS traversa
        public void TraverseDFSWithStack()
        {
            //Set Stack Last in Last Out
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            //Put Root
            stack.Push(this.root);
            while (stack.Count > 0)
            {
                //Remove Last element that was added. First Cycle this means root;
                TreeNode<T> currentNode = stack.Pop();
                //Returnt/Write Result
                Console.Write("{0} ", currentNode.Value);
                //Add all children
                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    stack.Push(childNode);
                }

                //First Cycle - Last element added (the one that is poped) is root. It is displayed. All its children are added to the stack.
                //Second Cycle - Last element added is the last child of root. It is displayed and all its children are added.
                //Trid cycl - Last element added is the previously pooped element(last child of the last child of root) and so on. Untill stack is empty.
            }
        }
    }

    public static class TreeExample
    {
        static void Main()
        {
            Tree<int> tree =
            new Tree<int>(7,
                          new Tree<int>(19,
                                        new Tree<int>(1),
                                        new Tree<int>(12),
                                        new Tree<int>(31)),
                          new Tree<int>(21),
                          new Tree<int>(14,
                                        new Tree<int>(23),
                                        new Tree<int>(6)));

            Console.WriteLine("Depth-First Search (DFS) traversal (recursive):");
            tree.TraverseDFS();
            Console.WriteLine();

            Console.WriteLine("Breadth-First Search (BFS) traversal (with queue):");
            tree.TraverseBFS();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Depth-First Search (DFS) traversal (with stack):");
            tree.TraverseDFSWithStack();
            Console.WriteLine();
        }
    }
}