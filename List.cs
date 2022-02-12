using System;
using System.Collections;
using System.Windows.Forms;

namespace LinkedListHelpers
{
    public class List
    {
        // The basic Customer class.
        public class Customer : Object
        {
            private string custName = "";
            protected ArrayList custOrders = new ArrayList();
            public Customer(string customername)
            {
                this.custName = customername;
            }
            public string CustomerName
            {
                get { return this.custName; }
                set { this.custName = value; }
            }
            public ArrayList CustomerOrders
            {
                get { return this.custOrders; }
            }
        } // End Customer class
          // The basic customer Order class.
        public class Order : Object
        {
            private string ordID = "";
            public Order(string orderid)
            {
                this.ordID = orderid;
            }
            public string OrderID
            {
                get { return this.ordID; }
                set { this.ordID = value; }
            }
        } // End Order class
          // Create a new ArrayList to hold the Customer objects.

        private ArrayList customerArray = new ArrayList();
        private TreeView treeView1 = new TreeView();
        public class LinkedList
        {
            Node head; // head of the list
            /* Node Class */
            class Node
            {
                public int data;
                public Node next;
                // Constructor to create a new node
                public Node(int d)
                {
                    data = d;
                    next = null;
                }
            }
            void printlist(Node node)
            {
                if (node == null)
                {
                    return;
                }
                while (node != null)
                {
                    Console.Write(node.data + " -> ");
                    node = node.next;
                }
            }
            Node reverselist(Node node)
            {
                Node prev = null, curr = node, next;
                while (curr != null)
                {
                    next = curr.next;
                    curr.next = prev;
                    prev = curr;
                    curr = next;
                }
                node = prev;
                return node;
            }
            void rearrange(Node node)
            {
                // 1) Find the middle point using
                // tortoise and hare method
                Node slow = node, fast = slow.next;
                while (fast != null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                }
                // 2) Split the linked list in two halves
                // node1, head of first half 1 -> 2 -> 3
                // node2, head of second half 4 -> 5
                Node node1 = node;
                Node node2 = slow.next;
                slow.next = null;
                // 3) Reverse the second half, i.e., 5 -> 4
                node2 = reverselist(node2);
                // 4) Merge alternate nodes
                node = new Node(0); // Assign dummy Node
                                    // curr is the pointer to this dummy Node, which
                                    // will be used to form the new list
                Node curr = node;
                while (node1 != null || node2 != null)
                {
                    // First add the element from first list
                    if (node1 != null)
                    {
                        curr.next = node1;
                        curr = curr.next;
                        node1 = node1.next;
                    }
                    // Then add the element from second list
                    if (node2 != null)
                    {
                        curr.next = node2;
                        curr = curr.next;
                        node2 = node2.next;
                    }
                }
                // Assign the head of the new list to head pointer
                node = node.next;
            }
            // Driver code
            public static void main(String[] args)
            {
                LinkedList list = new LinkedList();
                list.head = new Node(1);
                list.head.next = new Node(2);
                list.head.next.next = new Node(3);
                list.head.next.next.next = new Node(4);
                list.head.next.next.next.next = new Node(5);
                list.printlist(list.head); // print original list
                list.rearrange(
                list.head); // rearrange list as per ques
                Console.WriteLine("");
                list.printlist(list.head); // print modified list
            }
        }
        private void PopulateMyTreeView()
        {
            // Add customers to the ArrayList of Customer objects.
            for (int x = 0; x < 1000; x++)
            {
                customerArray.Add(new Customer("Customer" + x.ToString()));
            }
            // Add orders to each Customer object in the ArrayList.
            foreach (Customer customer1 in customerArray)
            {
                for (int y = 0; y < 15; y++)
                {
                    customer1.CustomerOrders.Add(new Order("Order" + y.ToString()));
                }
            }
            // Display a wait cursor while the TreeNodes are being created.
            Cursor.Current = new Cursor("MyWait.cur");

            // Suppress repainting the TreeView until all the objects have been created.
            treeView1.BeginUpdate();
            // Clear the TreeView each time the method is called.
            treeView1.Nodes.Clear();
            // Add a root TreeNode for each Customer object in the ArrayList.
            foreach (Customer customer2 in customerArray)
            {
                treeView1.Nodes.Add(new TreeNode(customer2.CustomerName));

                // Add a child treenode for each Order object in the current Customer object.
                foreach (Order order1 in customer2.CustomerOrders)
                {
                    treeView1.Nodes[customerArray.IndexOf(customer2)].Nodes.Add(
                    new TreeNode(customer2.CustomerName + "." + order1.OrderID));
                }
            }
            // Reset the cursor to the default for all controls.
            Cursor.Current = Cursors.Default;
            // Begin repainting the TreeView.
            treeView1.EndUpdate();
        }
        // Linked List Class
       
    }
}
