/*
 * The MIT License
 * Copyright © 2014-2019 Ilkka Seppälä
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
using System;
using Singleton.src.entities;
using Singleton.src.enums;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var ivoryTower1 = IvoryTower.GetInstance;
            var ivoryTower2 = IvoryTower.GetInstance;
            Console.WriteLine($"ivorytower1={ivoryTower1.GetType().GetHashCode()}");
            Console.WriteLine($"ivorytower2={ivoryTower2.GetType().GetHashCode()}");

            var threadSafeIvoryTower1 = ThreadSafeLazyLoadedIvoryTower.GetInstance;
            var threadSafeIvoryTower2 = ThreadSafeLazyLoadedIvoryTower.GetInstance;
            Console.WriteLine($"threadSafeIvoryTower1={threadSafeIvoryTower1.GetType().GetHashCode()}");
            Console.WriteLine($"threadSafeIvoryTower2={threadSafeIvoryTower2.GetType().GetHashCode()}");

            var enumIvoryTower1 = IvoryTowerEnum.INSTANCE;
            var enumIvoryTower2 = IvoryTowerEnum.INSTANCE;
            Console.WriteLine($"enumIvoryTower1={enumIvoryTower1.GetType().GetHashCode()}");
            Console.WriteLine($"enumIvoryTower2={enumIvoryTower2.GetType().GetHashCode()}");

            var dcl1 = ThreadSafeDoubleCheckLocking.GetInstance;
            Console.WriteLine($"threadSafeDoubleCheck1={dcl1.GetType().GetHashCode()}");
            var dcl2 = ThreadSafeDoubleCheckLocking.GetInstance;
            Console.WriteLine($"threadSafeDoubleCheck2={dcl2.GetType().GetHashCode()}");

            var demandHolderIdiom1 = InitializingOnDemandHolderIdiom.GetInstance;
            Console.WriteLine($"demandHolderIdiom1={demandHolderIdiom1.GetType().GetHashCode()}");
            var demandHolderIdiom2 = InitializingOnDemandHolderIdiom.GetInstance;
            Console.WriteLine($"demandHolderIdiom2={demandHolderIdiom2.GetType().GetHashCode()}");
        }
    }
}
