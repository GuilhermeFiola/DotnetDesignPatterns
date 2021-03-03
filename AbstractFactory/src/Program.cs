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
using AbstractFactory.src.factories;
using AbstractFactory.src.interfaces;
using static AbstractFactory.Program.FactoryMaker;

/**
 * The Abstract Factory pattern provides a way to encapsulate a group of individual factories that
 * have a common theme without specifying their concrete classes. In normal usage, the client
 * software creates a concrete implementation of the abstract factory and then uses the generic
 * interface of the factory to create the concrete objects that are part of the theme. The client
 * does not know (or care) which concrete objects it gets from each of these internal factories,
 * since it uses only the generic interfaces of their products. This pattern separates the details
 * of implementation of a set of objects from their general usage and relies on object composition,
 * as object creation is implemented in methods exposed in the factory interface.
 *
 * <p>The essence of the Abstract Factory pattern is a factory interface ({@link KingdomFactory})
 * and its implementations ( {@link ElfKingdomFactory}, {@link OrcKingdomFactory}). The example uses
 * both concrete implementations to create a king, a castle and an army.
 */

namespace AbstractFactory
{
    public class Program
    {
        private IKing king;
        private ICastle castle;
        private IArmy army;

        public void createKingdom(IKingdomFactory factory) {
            king = factory.createKing();
            castle = factory.createCastle();
            army = factory.createArmy();
        }

        public IKing getKing() => this.king;
        private void setKing(IKing king) => this.king = king;
        public IKing getKing(IKingdomFactory factory) => factory.createKing();

        public ICastle getCastle() => this.castle;
        private void setCastle(ICastle castle) => this.castle = castle;
        public ICastle getCastle(IKingdomFactory factory) => factory.createCastle();

        public IArmy getArmy() => this.army;
        private void setArmy(IArmy army) => this.army = army;
        public IArmy getArmy(IKingdomFactory factory) => factory.createArmy();

        public static class FactoryMaker
        {
            public enum KingdomType {
                ELF, ORC
            }

            public static IKingdomFactory makeFactory(KingdomType type) {
                switch(type) 
                {
                    case KingdomType.ELF: 
                        return new ElfKingdomFactory();
                    case KingdomType.ORC:
                        return new OrcKingdomFactory();
                    default:
                        throw new ArgumentException("Kingdom not supported!");
                }
            }

        }

        static void Main(string[] args)
        {
            var program = new Program();

            Console.WriteLine("Elf Kingdom");
            program.createKingdom(FactoryMaker.makeFactory(KingdomType.ELF));
            Console.WriteLine(program.getArmy().getDescription());
            Console.WriteLine(program.getCastle().getDescription());
            Console.WriteLine(program.getKing().getDescription());

            Console.WriteLine("Orc Kingdom");
            program.createKingdom(FactoryMaker.makeFactory(KingdomType.ORC));
            Console.WriteLine(program.getArmy().getDescription());
            Console.WriteLine(program.getCastle().getDescription());
            Console.WriteLine(program.getKing().getDescription());
        }
    }
}
