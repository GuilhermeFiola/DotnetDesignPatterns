﻿/*
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
using Builder.src.entities;
using Builder.src.enums;

namespace Builder.src
{
    class Program
    {
        static void Main(string[] args)
        {
            var mage = 
                new Hero.Builder(Profession.MAGE, "Riobard")
                .withHairColor(HairColor.BLACK)
                .withWeapon(Weapon.DAGGER)
                .build();
            Console.WriteLine(mage.ToString());

            var warrior =
                new Hero.Builder(Profession.WARRIOR, "Amberjill")
                .withHairColor(HairColor.BLOND)
                .withHairType(HairType.LONG_CURLY)
                .withArmor(Armor.CHAIN_MAIL)
                .withWeapon(Weapon.SWORD)
                .build();
            Console.WriteLine(warrior.ToString());

            var thief = 
                new Hero.Builder(Profession.THIEF, "Desmond")
                .withHairType(HairType.BALD)
                .withWeapon(Weapon.BOW)
                .build();
            Console.WriteLine(thief.ToString());
        }
    }
}
