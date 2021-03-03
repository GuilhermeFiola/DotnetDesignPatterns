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
using Xunit;

namespace FactoryMethodTest
{
    public class FactoryMethodTest
    {
        [Fact]
        public void testOrcBlacksmithWithSpear()
        {
            var blacksmith = new OrcBlacksmith();
            var weapon = blacksmith.manufactureWeapon(WeaponType.SPEAR);
            verifyWeapon(weapon, WeaponType.SPEAR, typeof(OrcWeapon));
        }

        [Fact]
        public void testOrcBlacksmithWithAxe() {
            var blacksmith = new OrcBlacksmith();
            var weapon = blacksmith.manufactureWeapon(WeaponType.AXE);
            verifyWeapon(weapon, WeaponType.AXE, typeof(OrcWeapon));
        }

        [Fact]
        public void testElfBlacksmithWithShortSword() {
            var blacksmith = new ElfBlacksmith();
            var weapon = blacksmith.manufactureWeapon(WeaponType.SHORT_SWORD);
            verifyWeapon(weapon, WeaponType.SHORT_SWORD, typeof(ElfWeapon));
        }

        [Fact]
        public void testElfBlacksmithWithSpear() {
            var blacksmith = new ElfBlacksmith();
            var weapon = blacksmith.manufactureWeapon(WeaponType.SPEAR);
            verifyWeapon(weapon, WeaponType.SPEAR, typeof(ElfWeapon));
        }

        private void verifyWeapon(IWeapon weapon, WeaponType expectedWeaponType, Type weaponType) {
            Assert.True(weaponType.IsInstanceOfType(weapon), "Weapon must be an object of: " + weaponType.Name);
            Assert.Equal(expectedWeaponType, weapon.getWeaponType());
        }
    }
}
