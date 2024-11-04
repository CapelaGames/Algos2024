using UnityEngine;

namespace OurLinkedList
{
    public class Node
    {
        public string name;
        public int gangamStyleCount = 0;

        public Node next;
        public Node prev;

        public Node(string name, int gangamStyleCount)
        {
            this.name = name;
            this.gangamStyleCount = gangamStyleCount;

            next = null;
            prev = null;
        }
    }

    public class MyLinkedList : MonoBehaviour
    {
        private void Start()
        {
            Node Andrew = new Node("Andrew", 300);
            Node Shoji = new Node("Shoji", 30);
            Node brainDead = new Node("brainDead", 90000);
            Node another = new Node("another", 90000);

            LinkedList linkedList = new LinkedList(Andrew);
            linkedList.InsertNext(Shoji);

            linkedList.PrintCurrent(); //
            linkedList.InsertNext(another);
            linkedList.InsertNext(brainDead);
            linkedList.DeleteNext();
            linkedList.PrintCurrent(); //
            linkedList.Next();
            linkedList.PrintCurrent(); //
            linkedList.Next();
            linkedList.PrintCurrent(); //
            linkedList.Prev();
            linkedList.PrintCurrent(); //
            linkedList.Prev();
            linkedList.PrintCurrent(); //
            linkedList.Prev();
            linkedList.PrintCurrent(); //
            
            
            
            
            
        }
    }

    public class LinkedList
    {
        private Node header; // The first node in the list
        private Node current; // current node we are looking at

        public LinkedList()
        {
            
        }
        public LinkedList(Node node)
        {
            header = node;
            header.next = null;
            header.prev = null;
            current = node;
        }

        public void InsertNext(Node newNode)
        {
            if (current.next == null)
            {
                newNode.prev = current;
                newNode.next = null;
                current.next = newNode;
                
            }
            else
            {
                current.next.prev = newNode;
                newNode.next = current.next;

                newNode.prev = current;
                current.next = newNode;
            }
        }

        public void DeleteNext()
        {
            if (current.next == null)
            {
                return;
            }

            Node delNode = current.next;
            current.next = current.next.next;
            if (current.next != null)
            {
                current.next.prev = current;
            }

            delNode = null;

        }

        public void Prev()
        {
            if (current.prev != null)
            {
                current = current.prev;
            }
        }
        
        public void Next()
        {
            if (current.next != null)
            {
                current = current.next;
            }
        }

        public void PrintCurrent() =>
            Debug.Log(current.name + " Gangam count: " + current.gangamStyleCount);

        public void Restart()
        {
            current = header;
        }
        
        public void PrintAll()
        {
            if (header == null) return;
            
            Node currentPrint = header;

            do
            {
                Debug.Log(currentPrint.name + " Gangam count: " + currentPrint.gangamStyleCount);
                currentPrint = currentPrint.next;
            } while (currentPrint != null);
        }
    }
}