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
using FactoryMethod.src.entities;
using FactoryMethod.src.enums;
using FactoryMethod.src.interfaces;

namespace FactoryMethod
{
    public class Program
    {
        private readonly IBlacksmith blacksmith;

        public Program(IBlacksmith blacksmith)
        {
            this.blacksmith = blacksmith;
        }

        static void Main(string[] args)
        {
            var program = new Program(new OrcBlacksmith());
            program.manufactureWeapon();

            program = new Program(new ElfBlacksmith());
            program.manufactureWeapon();
        }

        private void manufactureWeapon() {
            var weapon = blacksmith.manufactureWeapon(WeaponType.SPEAR);
            Console.WriteLine(weapon.ToString());

            weapon = blacksmith.manufactureWeapon(WeaponType.AXE);
            Console.WriteLine(weapon.ToString());
        }
    }
}
