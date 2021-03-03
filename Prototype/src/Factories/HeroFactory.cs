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

using Prototype.src.entities;
using Prototype.src.interfaces;

namespace Prototype.src.factories {
     public class HeroFactory : IHeroFactory{
         private Beast beast;
         private Mage mage;
         private Warlord warlord;

         public HeroFactory(Beast beast, Mage mage, Warlord warlord) 
         {
             this.beast = beast;
             this.mage = mage;
             this.warlord = warlord;
         }

         public Beast createBeast() {
             return (Beast)this.beast.Copy();
         }

        public Mage createMage()
        {
            return (Mage)this.mage.Copy();
        }

        public Warlord createWarlord()
        {
            return (Warlord)this.warlord.Copy();
        }
    }
 }