using ExerciseFirst.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExerciseFirst.Collection
{
    public class BinaryTree<T> where T : TestResult, IBinaryTreeElement<T>, new()
    {
        public BinaryTree()
        { }
        public BinaryTree(T root)
        {
            Root = root;
        }

        public T Root { get; private set; }
        public int Depth { get; }

        public void Add(T test)
        {
            if (test == null)
            {
                throw new NullReferenceException("Невозможно добавить null в бинарное дерево");
            }

            if (Root == null)
            {
                Root = test;
            }
            else
            {
                var startPoint = Root;
                while (true)
                {
                    if (test > startPoint)
                    {
                        if (startPoint.Right == null)
                        {
                            startPoint.Right = test;
                            break;
                        }
                        startPoint = startPoint.Right as T;
                    }
                    else if (test < startPoint)
                    {
                        if (startPoint.Left == null)
                        {
                            startPoint.Left = test;
                            break;
                        }
                        startPoint = startPoint.Left as T;
                    }
                    else
                    {
                        throw new Exception("В бинарном дереве могу находится только уникальные элементы.");
                    }
                }
            }


        }

        public void Remove(T test)
        {
            if (test == null)
            {
                throw new NullReferenceException("Значения для удаления не можеть быть null.");
            }

            if ((test.Left == null) && (test.Right == null))
            {
                RemovePatherHeir(test);
                return;
            }

            if ((test.Left != null) && (test.Right == null))
            {
                RemovePatherHeir(test, test.Left as T);
            }
            else if ((test.Left == null) && (test.Right != null))
            {
                RemovePatherHeir(test, test.Right as T);
            }
            else
            {
                // 
            }

        }

        public void Rebalance()
        {

        } // пусто

        public T GetMin(T treeRoot)
        {
            if (treeRoot == null)
            {
                return treeRoot;
            }

            T startPoint = treeRoot;
            for (; startPoint.Left != null; startPoint = (T)startPoint.Left);
            return startPoint;
        }

        public T GetMax(T treeRoot)
        {
            if (treeRoot == null)
            {
                return treeRoot;
            }

            T startPoint = treeRoot;
            for (; startPoint.Right != null; startPoint = (T)startPoint.Right);
            return startPoint;
        }

        public List<T> ToList()
        {
            var list = new List<T>();
            GetElementsFromTree(Root, ref list);
            return list;
        }

        private (T pather, BinaryTreeHeir typeOfHeir) RemovePatherHeir(T heir, T newHeir = null)
        {
            var startPoint = Root;
            while (true)
            {
                if ((startPoint.Left == heir) || (startPoint.Right == heir))
                {
                    if (startPoint > heir)
                    {
                        startPoint.Left = newHeir;
                        return (startPoint, BinaryTreeHeir.Left);
                    }
                    else
                    {
                        startPoint.Right = newHeir;
                        return (startPoint, BinaryTreeHeir.Right);
                    }
                    
                }

                if (startPoint > heir)
                {
                    startPoint = startPoint.Left as T;
                }
                else
                {
                    startPoint = startPoint.Right as T;
                }
            }
        
        }

        private void GetElementsFromTree(T element, ref List<T> allElements)
        {
            if (element == null)
            {
                return;
            }

            if (element != null)
            {
                allElements.Add(element);
            }
            GetElementsFromTree(element.Left as T, ref allElements);
            GetElementsFromTree(element.Right as T, ref allElements);
        }


    }
}
