using ExerciseFirst.Test;
using System;
using System.Collections.Generic;
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

            if ((test.Left != null) && (test.Right == null))
            {

            }
            else if ((test.Left == null) && (test.Right != null))
            {

            }
        }

        public void Rebalance()
        {

        }

        public T GetMin(T treeRoot)
        {
            if (treeRoot == null)
            {
                return treeRoot;
            }

            T startPoint = treeRoot;
            for (; startPoint.Left != null; startPoint = (T)startPoint.Left) ;
            return startPoint;
        }

        public T GetMax(T treeRoot)
        {
            if (treeRoot == null)
            {
                return treeRoot;
            }

            T startPoint = treeRoot;
            for (; startPoint.Right != null; startPoint = (T)startPoint.Right) ;
            return startPoint;
        }

        public void ToList(T element, ref List<T> allElements)
        {
            if (element == null)
            {
                return;
            }

            if (element != null)
            {
                allElements.Add(element);
            }
            ToList(element.Left as T, ref allElements);
            ToList(element.Right as T, ref allElements);
        }


    }
}
