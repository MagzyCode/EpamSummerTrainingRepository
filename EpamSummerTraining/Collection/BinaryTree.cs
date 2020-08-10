using ExerciseFirst.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;

namespace ExerciseFirst.Collection
{
    public class BinaryTree<T> where T : TestResult, IBinaryTreeElement<T>, new()
    {
        private T _root;
        public BinaryTree()
        { }
        public BinaryTree(T root)
        {
            Root = root;
        }

        public T Root
        {
            get
            {
                return _root;
            }

            set
            {
                _root = value;
            }
        }
        public int Depth { get; }
        public int Count
        {
            get
            {
                return ToList().Count;
            }
        }

        public void Add(T test)
        {
            if (test == null)
            {
                throw new NullReferenceException("Невозможно добавить null в бинарное дерево");
                // return;
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
                ChangePatherHeir(test);
            }
            else if ((test.Left != null) && (test.Right == null))
            {
                ChangePatherHeir(test, test.Left as T);
            }
            else if (((test.Left == null) && (test.Right != null)) ||
                ((test.Left != null) && (test.Right != null) &&
                (test.Right.Left == null)))
            {
                ChangePatherHeir(test, test.Right as T);
            }
            else
            {
                var newHeir = GetMin(test.Right as T);
                ChangePatherHeir(newHeir, newHeir.Right as T);
                ChangePatherHeir(test, newHeir, true);
            }

        }

        //public BinaryTree<T> Rebalance()
        //{
        //    //if (IsTreeBalanced(this))
        //    //{
        //    //    return this;
        //    //}

        //    //var halfOfCount = Count / 2;
        //    //List<T> sortedTree = ToList().OrderBy(i => i.StudentNumber).ToList();
        //    //List<T> getFirstPart = sortedTree.GetRange(0, halfOfCount);
        //    //getFirstPart.Reverse();
        //    //List<T> getSecondPart = sortedTree.GetRange(halfOfCount, Count - halfOfCount);

        //    //var newTree = new BinaryTree<T>();
        //    //var maxHalf = Math.Max(getFirstPart.Count, getSecondPart.Count);
        //    //for (int counter = 0; counter <= maxHalf; counter++)
        //    //{
        //    //    if ((counter == maxHalf - 1) && (getFirstPart.Count != getSecondPart.Count))
        //    //    {
        //    //        if (getFirstPart.Count > getSecondPart.Count)
        //    //        {
        //    //            newTree.Add(getFirstPart[counter]);
        //    //        }
        //    //        else
        //    //        {
        //    //            newTree.Add(getSecondPart[counter]);
        //    //        }
        //    //        break;
        //    //    }

        //    //    newTree.Add(getFirstPart[counter]);
        //    //    newTree.Add(getSecondPart[counter]);
        //    //}
        //    //return newTree;
        //}

        public void Rebalance()
        {
            // var root = Root;
            GetRebalance(ref _root);
        }

        private void GetRebalance(ref T root)
        {
            if (root != null)
            {

                var right = root.Right as T;
                GetRebalance(ref right);
                if (root != Root)
                {
                    root = BalanceTreeItem(/*ref */root);
                }


                var left = root.Left as T;
                GetRebalance(ref left);
                if (root == Root)
                {
                    root = BalanceTreeItem(/*ref */root);
                }
                
                
                
            }

            
        }

        public int GetBalanceFactor(T root)
        {
            var balanceFactor = Math.Abs(GetDepth(root.Right as T) - GetDepth(root.Left as T));
            return balanceFactor;
        }

        public void RorateRight(ref T root)
        {
            var oldRoot = root;
            var newRoot = root.Left;
            oldRoot.Left = newRoot.Right;
            newRoot.Right = oldRoot;

            var (pather, side) = GetPather(root);
            if (side == BinaryTreeHeir.Left)
            {
                pather.Left = newRoot;
            }
            else if (side == BinaryTreeHeir.Right)
            {
                pather.Right = newRoot;
            }
            //newRoot.Right = oldRoot;

            // root = newRoot;

            ///////////////////////////////////////

            //var newRoot = root.Left;
            //// var lateRoot = root;
            //root.Left = newRoot.Right;
            //newRoot.Right = root;
            //root = newRoot as T;
            ////return temp;
            ///////////////////////////////


            //var oldRoot = root;
            //var newRoot = root.Left;
            //oldRoot.Left = newRoot.Right;

            //var (pather, side) = GetPather(root);
            //if (side == BinaryTreeHeir.Left)
            //{
            //    pather.Left = newRoot;
            //}
            //else if (side == BinaryTreeHeir.Right)
            //{
            //    pather.Right = newRoot;
            //}
            //newRoot.Right = oldRoot;

            /////////////////////////////////////////
            // root = newRoot as T;
        }

        public void RotateLeft(ref T root)
        {
            var oldRoot = root;
            var newRoot = root.Right;
            oldRoot.Right = newRoot.Left;
            newRoot.Left = oldRoot;
            // node = newRoot;
            var (pather, side) = GetPather(root);
            if (side == BinaryTreeHeir.Left)
            {
                pather.Left = newRoot;
            }
            else if (side == BinaryTreeHeir.Right)
            {
                pather.Right = newRoot;
            }
            /////////////////////////

            //var oldRoot = root;
            //var newRoot = root.Right;

            //oldRoot.Right = newRoot.Left;
            //newRoot.Left = root;
            //root = newRoot as T;

            ///////////////////////////////
            //var oldRoot = root;
            //var newRoot = root.Right;
            //oldRoot.Right = newRoot.Left;
            //// root = newRoot as T;
            //var (pather, side) = GetPather(root);
            //if (side == BinaryTreeHeir.Left)
            //{
            //    pather.Left = newRoot;
            //}
            //else if (side == BinaryTreeHeir.Right)
            //{
            //    pather.Right = newRoot;
            //}
            //newRoot.Left = oldRoot;

            /////////////////////////////////////
            // newRoot.Left = oldRoot;
            // var copyOfNewRoot = newRoot as T;
            // root = ref copyOfNewRoot;
        }

        public bool IsTreeBalanced(/*BinaryTree<T> element*/ T root)
        {
            if (root == null)
            {
                return true;
            }

            var balanceCoefficient = Math.Abs(GetDepth(root.Left as T) - GetDepth(root.Right as T));
            if (balanceCoefficient < 2)
            {
                return true;
            }
            return false;
        }

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
            var allElements = new List<T>();
            GetElementsFromTree(Root, ref allElements);
            return allElements;
        }
        
        private T BalanceTreeItem(/*ref */T root)
        {
            //var depthOfLeftTree = GetDepth(root.Left as T);
            //var depthOfRightTree = GetDepth(root.Right as T);

            //var 

            if (!IsTreeBalanced(root))
            {
                var leftTreeDepth = GetDepth(root.Left as T);
                var rightTreeDepth = GetDepth(root.Right as T);
                if ((leftTreeDepth > rightTreeDepth) /*&& (root.Left != null)*/)
                {
                    RorateRight(ref root);
                }
                else if ((leftTreeDepth <= rightTreeDepth) /*&& (root.Right != null)*/)
                {
                    RotateLeft(ref root);
                }
            }

            return root;
        }

        private (T, BinaryTreeHeir) GetPather(T heir)
        {
            var startPoint = Root;
            while (true)
            {
                if ((startPoint.Left == heir) || (startPoint.Right == heir))
                {
                    if (startPoint > heir)
                    {
                        return (startPoint, BinaryTreeHeir.Left);
                    }
                    else
                    {
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

        private void ChangePatherHeir(T heir, T newHeir = null, bool isTwoHeirs = false)
        {
            var startPoint = Root;
            while (true)
            {
                if ((startPoint.Left == heir) || (startPoint.Right == heir))
                {
                    if (startPoint > heir)
                    {
                        startPoint.Left = newHeir;
                        if (isTwoHeirs)
                        {
                            newHeir.Left = heir.Left;
                            newHeir.Right = heir.Right;
                        }
                        heir.Left = null;
                        heir.Right = null;
                        break;
                    }
                    else
                    {
                        startPoint.Right = newHeir;
                        if (isTwoHeirs)
                        {
                            newHeir.Left = heir.Left;
                            newHeir.Right = heir.Right;
                        }
                        heir.Left = null;
                        heir.Right = null;
                        break;
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

        public int GetDepth(T element)
        {
            if (element == null)
            {
                return 0;
            }
            return 1 + Math.Max(GetDepth(element.Left as T), GetDepth(element.Right as T));
        }

    }
}
