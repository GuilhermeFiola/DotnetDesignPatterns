using System;
using Xunit;
using AbstractFactory.src.interfaces;
using AbstractFactory.src.entities;
using static AbstractFactory.Program;
using static AbstractFactory.Program.FactoryMaker;

namespace AbstractFactory
{
    public class FactoryFixture : IDisposable
    {
        public IKingdomFactory elfFactory;
        public IKingdomFactory orcFactory;

        public FactoryFixture()
        {
            elfFactory = FactoryMaker.makeFactory(KingdomType.ELF);
            orcFactory = FactoryMaker.makeFactory(KingdomType.ORC);
        }

        public void Dispose()
        {
            elfFactory = null;
            orcFactory = null;
        }
    }

    [CollectionDefinition("Factory Fixture")]
    public class FactoryCollection : ICollectionFixture<FactoryFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }

    [Collection("Factory Fixture")]
    public class AbstractFactoryTest
    {
        FactoryFixture fixture;
        private Program program = new Program();

        public AbstractFactoryTest(FactoryFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void king()
        {
            var elfKing = program.getKing(fixture.elfFactory);
            Assert.True(typeof(ElfKing).IsInstanceOfType(elfKing));
            Assert.Equal(ElfKing.DESCRIPTION, elfKing.getDescription());

            var orcKing = program.getKing(fixture.orcFactory);
            Assert.True(typeof(OrcKing).IsInstanceOfType(orcKing));
            Assert.Equal(OrcKing.DESCRIPTION, orcKing.getDescription());
        }

        [Fact]
        public void castle() {
            var elfCastle = program.getCastle(fixture.elfFactory);
            Assert.True(typeof(ElfCastle).IsInstanceOfType(elfCastle));
            Assert.Equal(ElfCastle.DESCRIPTION, elfCastle.getDescription());

            var orcCastle = program.getCastle(fixture.orcFactory);
            Assert.True(typeof(OrcCastle).IsInstanceOfType(orcCastle));
            Assert.Equal(OrcCastle.DESCRIPTION, orcCastle.getDescription());
        }

        [Fact]
        public void army() 
        {
            var elfArmy = program.getArmy(fixture.elfFactory);
            Assert.True(typeof(ElfArmy).IsInstanceOfType(elfArmy));
            Assert.Equal(ElfArmy.DESCRIPTION, elfArmy.getDescription());

            var orcArmy = program.getArmy(fixture.orcFactory);
            Assert.True(typeof(OrcArmy).IsInstanceOfType(orcArmy));
            Assert.Equal(OrcArmy.DESCRIPTION, orcArmy.getDescription());
        }

        [Fact]
        public void createElfKingdom() {
            program.createKingdom(fixture.elfFactory);
            var king = program.getKing();
            var castle = program.getCastle();
            var army = program.getArmy();

            Assert.True(typeof(IKing).IsInstanceOfType(king));
            Assert.Equal(ElfKing.DESCRIPTION, king.getDescription());

            Assert.True(typeof(ICastle).IsInstanceOfType(castle));
            Assert.Equal(ElfCastle.DESCRIPTION, castle.getDescription());

            Assert.True(typeof(IArmy).IsInstanceOfType(army));
            Assert.Equal(ElfArmy.DESCRIPTION, army.getDescription());
        }

        [Fact]
        public void createOrcKingdom() {
            program.createKingdom(fixture.orcFactory);
            var king = program.getKing();
            var castle = program.getCastle();
            var army = program.getArmy();

            Assert.True(typeof(IKing).IsInstanceOfType(king));
            Assert.Equal(OrcKing.DESCRIPTION, king.getDescription());

            Assert.True(typeof(ICastle).IsInstanceOfType(castle));
            Assert.Equal(OrcCastle.DESCRIPTION, castle.getDescription());

            Assert.True(typeof(IArmy).IsInstanceOfType(army));
            Assert.Equal(OrcArmy.DESCRIPTION, army.getDescription());
        }
    }
}
