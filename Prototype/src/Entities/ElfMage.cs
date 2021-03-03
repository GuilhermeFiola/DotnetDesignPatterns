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

namespace Prototype.src.entities {
    public class ElfMage : Mage
    {
        private string helpType;

        public ElfMage(string helpType) 
        { 
            this.helpType = helpType;    
        }

        public ElfMage(ElfMage elfMage) : base(elfMage) 
        { 
            this.helpType = elfMage.helpType;
        }

        public override object Copy()
        {
            return new ElfMage(this);
        }

        public override string ToString() {
            return "Elven mage helps in " + this.helpType;
        }

        public override bool Equals(object obj)
        {
            if(this == obj) {
                return true;
            }

            if(!base.Equals(obj)) {
                return false;
            }

            if(GetType() != obj.GetType()) {
                return false;
            }

            var other = (ElfMage)obj;

            if(helpType == null) {
                return other.helpType == null;
            }

            return helpType.Equals(other.helpType);
        }
    }

}