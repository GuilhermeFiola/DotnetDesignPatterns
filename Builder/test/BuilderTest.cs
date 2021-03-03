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
using Builder.src.entities;
using Builder.src.enums;
using Xunit;

namespace BuilderTest
{
    public class BuilderTest
    {
        [Fact]
        public void testMissingProfession()
        {
            Assert.Throws<ArgumentNullException>(() => new Hero.Builder(null, "Without job"));
        }

        [Fact]
        public void testMissingName() {
            Assert.Throws<ArgumentNullException>(() => new Hero.Builder(Profession.THIEF, null));
        }

        [Fact]
        public void testBuildHero() {
            string heroName = "Sir Lancelot";

            var hero = new Hero.Builder(Profession.WARRIOR, heroName)
                               .withArmor(Armor.CHAIN_MAIL)
                               .withWeapon(Weapon.SWORD)
                               .withHairType(HairType.LONG_CURLY)
                               .withHairColor(HairColor.BLOND)
                               .build();

            Assert.NotNull(hero);
            Assert.NotNull(hero.ToString());
            Assert.Equal(Profession.WARRIOR, hero.profession);
            Assert.Equal(heroName, hero.name);
            Assert.Equal(Armor.CHAIN_MAIL, hero.armor);
            Assert.Equal(Weapon.SWORD, hero.weapon);
            Assert.Equal(HairType.LONG_CURLY, hero.hairType);
            Assert.Equal(HairColor.BLOND, hero.hairColor);
        }
    }
}
