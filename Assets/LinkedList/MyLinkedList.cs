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

    //Extra
    //Delete previous
    
    //THESE TWO
    //Delete current




    public class LinkedList
    {
        private Node header; // The first node in the list
        private Node tail;
        private Node current; // current node we are looking at

        public LinkedList()
        {

        }

        public LinkedList(Node node)
        {
            header = node;
            tail = node;
            header.next = null;
            header.prev = null;
            current = node;
        }

        public void InsertNext(Node newNode)
        {
            if (current.next == null)
            {
                current.next = newNode;
                newNode.prev = current;
                newNode.next = null;
                tail = newNode;
            }
            else
            {
                current.next.prev = newNode;
                newNode.next = current.next;

                newNode.prev = current;
                current.next = newNode;
            }
        }

        public void InsertPrev(Node newNode)
        {
            if (current.prev == null)
            {
                current.prev = newNode;
                newNode.next = current;
                newNode.prev = null;
                header = newNode;
            }
            else
            {
                current.prev.next = newNode;
                newNode.prev = current.prev;

                newNode.next = current;
                current.prev = newNode;
            }
        }

        public void DeleteCurrent()
        {
            if (Prev())
            {
                DeleteNext();
            }
            else if(Next())
            {
                DeletePrev();
            }
            else
            {
                header = null;
                tail = null;
                current = null;
            }
        }

        public void DeletePrev()
        {
            if (current.prev == null)
            {
                return;
            }

            Node delNode = current.prev;
            current.prev = current.prev.prev;
            if (current.prev != null)
            {
                current.prev.next = current;
            }
            else
            {
                header = current;
            }

            delNode = null;

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
            else
            {
                tail = current;
            }

            delNode = null;

        }

        public bool Prev()
        {
            if (current.prev != null)
            {
                current = current.prev;
                return true;
            }
            return false;
        }
        
        public bool Next()
        {
            if (current.next != null)
            {
                current = current.next;
                return true;
            }
            return false;
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