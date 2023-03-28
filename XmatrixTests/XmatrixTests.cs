using XmatrixType;

namespace XmatrixTests
{
    [TestClass]
    public class XmatrixTests
    {
        [TestMethod]
        public void Create()
        {
            Assert.ThrowsException<Xmatrix.InvalidSizeException>(() => _ = new Xmatrix(0));
            Assert.ThrowsException<Xmatrix.InvalidSizeException>(() => _ = new Xmatrix(1));
            
            Xmatrix b = new(3);
            Assert.AreEqual(b.getSize(), 3);

            Assert.ThrowsException<Xmatrix.InvalidSizeException>(() => _ = new Xmatrix(4));

            Xmatrix c = new(5);
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    Assert.AreEqual(c.getEntry(i, j), 0);
                }
            }
            Assert.AreEqual(c.getSize(), 5);
            Assert.ThrowsException<Xmatrix.InvalidSizeException>(() => _ = new Xmatrix(-1));
            Xmatrix d = new(999);
            Assert.AreEqual(d.getSize(), 999);
        }

        [TestMethod]
        public void Change()
        {
            Xmatrix c = new(3);
            c.setEntry(0, 0, 1);
            c.setEntry(0, 2, 1);
            c.setEntry(1, 1, 1);
            c.setEntry(2, 0, 1);
            c.setEntry(2, 2, 1);
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(c.isInDiagonals(i,j)) Assert.AreEqual(c.getEntry(i, j), 1);
                }
            }
            Assert.AreEqual(c.getEntry(0, 1), 0);
            Assert.ThrowsException<Xmatrix.IndexOfZeroException>(() => c.setEntry(1,0,3));
            Assert.ThrowsException<Xmatrix.OutofIndexException>(() => c.setEntry(-1, 0, 3));
        }

        
        [TestMethod]
        public void Add()
        {
            Xmatrix a = new(3);
            Xmatrix b = new(3);
            Xmatrix zero = new(3);
            Xmatrix d = new(5);
            Xmatrix c;

            a.setEntry(0, 0, 1);
            a.setEntry(0, 2, 1);
            a.setEntry(1, 1, 1);
            a.setEntry(2, 0, 1);
            a.setEntry(2, 2, 1);

            b.setEntry(0, 0, 42);
            b.setEntry(0, 2, 0);
            b.setEntry(1, 1, 0);
            b.setEntry(2, 0, 0);
            b.setEntry(2, 2, 0);

            c = a + b;
            Assert.AreEqual(c.getEntry(0, 0), 43);
            Assert.AreEqual(c.getEntry(1, 1), 1);
            Assert.IsTrue(a == (a + zero));
            Assert.IsTrue(a == (zero + a));
            Assert.IsTrue((a + b) == (b + a));
            Assert.IsTrue(((a + b) + c) == (a + (b + c)));
            Assert.ThrowsException<Xmatrix.DimensionMismatchException>(() => a + d);
        }

        [TestMethod]
        public void Mul()
        {
            Xmatrix a = new(3);
            Xmatrix b = new(3);
            Xmatrix zero = new(3);
            Xmatrix d = new(5);
            Xmatrix c;

            a.setEntry(0, 0, 1);
            a.setEntry(0, 2, 1);
            a.setEntry(1, 1, 1);
            a.setEntry(2, 0, 1);
            a.setEntry(2, 2, 1);

            b.setEntry(0, 0, 42);
            b.setEntry(0, 2, 0);
            b.setEntry(1, 1, 0);
            b.setEntry(2, 0, 0);
            b.setEntry(2, 2, 0);

            c = a * b;
            Assert.AreEqual(c.getEntry(0, 0), 42);
            Assert.AreEqual(c.getEntry(1, 1), 0);

            Assert.IsTrue(zero == (a * zero));
            Assert.IsFalse(b == (a * b));
            Assert.IsTrue(((a * b) * c) == (a * (b * c)));

            Assert.ThrowsException<Xmatrix.DimensionMismatchException>(() => a * d);
        }

        
    }
}