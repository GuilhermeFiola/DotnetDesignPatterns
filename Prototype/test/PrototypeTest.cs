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

using System.Collections.Generic;
using Prototype.src.entities;
using Prototype.src.interfaces;
using Xunit;

namespace PrototypeTest 
{
    public class PrototypeTest
    {
        public static IEnumerable<object[]> DataProvider()
        {
            yield return new object[] { new OrcBeast("axe"), "Orcish wolf attacks with axe" };
            yield return new object[] { new OrcMage("sword"), "Orcish mage attacks with sword"};
            yield return new object[] { new OrcWarlord("laser"), "Orcish warlord attacks with laser"};
            yield return new object[] { new ElfBeast("cooking"), "Elven eagle helps in cooking"};
            yield return new object[] { new ElfMage("cleaning"), "Elven mage helps in cleaning"};
            yield return new object[] { new ElfWarlord("protecting"), "Elven warlord helps in protecting"};
        }

        [Theory]
        [MemberData(nameof(DataProvider))]
        public void TestPrototype(IPrototype testedPrototype, string expectedToString)
        {
            Assert.Equal(expectedToString, testedPrototype.ToString());

            var clone = testedPrototype.Copy();
            Assert.NotNull(clone);
            Assert.NotSame(clone, testedPrototype);
            Assert.Same(testedPrototype.GetType(), clone.GetType());
            Assert.Equal(clone, testedPrototype);
        }
    }
}
