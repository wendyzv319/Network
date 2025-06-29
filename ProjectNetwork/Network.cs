using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectNetwork
{
    public class Network
    {
        private readonly int _countOfItems;
        private bool[,] _verifyEdge;
        public Network(int countOfItems)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(countOfItems);
            _countOfItems = countOfItems;
            _verifyEdge = new bool[countOfItems, countOfItems];
        }

        ///  <summary>
        /// Connect 2 items
        /// </summary>
        /// <param name="item1">Item 1 for connect</param>
        /// <param name="item2">Item 2 for connect to Item 1</param>
        public void Connect(int item1, int item2)
        {
            if (item1 > _countOfItems || item2 > _countOfItems || item1 <1 || item2 < 1)
                throw new ArgumentOutOfRangeException($"Items are out of limits");
            

            _verifyEdge[item1-1, item2-1] = true;
            _verifyEdge[item2 - 1, item1 - 1] = true;
   
        }

        ///  <summary>
        /// Verify if 2 items are connected
        /// </summary>
        /// <param name="item1">Item 1 for verify</param>
        /// <param name="item2">Item 2 for verify</param>
        public bool Query(int item1, int item2)
        {
            if (item1 > _countOfItems || item2 > _countOfItems || item1 < 1 || item2 < 1)
                throw new ArgumentOutOfRangeException($"Items are out of limits");

            return _verifyEdge[item1, item2];
        }

        ///  <summary>
        /// Disconnect 2 items
        /// </summary>
        /// <param name="item1">Item 1 for disconnect</param>
        /// <param name="item2">Item 2 for disconnect Item 1</param>
        public void Disconnet(int item1, int item2)
        {
            if (item1 > _countOfItems || item2 > _countOfItems || item1 < 1 || item2 < 1)
                throw new ArgumentOutOfRangeException($"Items are out of limits");


            _verifyEdge[item1 - 1, item2 - 1] = false;
            _verifyEdge[item2 - 1, item1 - 1] = false;

        }

        /// <summary>
        /// Determine the level of connection of 2 items
        /// </summary>
        /// <param name="item1">Item 1 for verify connect</param>
        /// <param name="item2">Item 2 for verify if connect Item 1</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>The number that represents how many connections there are between the searched elements.  </returns>                           
        public int LevelConnection(int item1, int item2)
        {
            if (item1 > _countOfItems || item2 > _countOfItems || item1 < 1 || item2 < 1)
                throw new ArgumentOutOfRangeException($"Items are out of limits");

            bool[] visited = new bool[_countOfItems];
            int[] level = new int[_countOfItems];

            Queue<int> cola = new Queue<int>();
            cola.Enqueue(item1-1);
            visited[item1-1] = true;
            level[item1-1] = 0;

            while (cola.Count > 0)
            {
                int current = cola.Dequeue();

                for (int neigborgIndex = 0; neigborgIndex < _countOfItems; neigborgIndex++)
                {
                    if (_verifyEdge[current, neigborgIndex] && !visited[neigborgIndex])
                    {
                        visited[neigborgIndex] = true;
                        level[neigborgIndex] = level[current] + 1;
                        cola.Enqueue(neigborgIndex);

                        if (neigborgIndex == item2-1)
                            return level[neigborgIndex];
                    }
                }
            }

            return 0; 
        }

    }

    public class Vertex
    {
        public Vertex(int number)
        {
        }

        
    }


}
