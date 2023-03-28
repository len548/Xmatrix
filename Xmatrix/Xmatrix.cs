using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmatrixType
{
    public class Xmatrix
    {
        #region Attributes
        private int _size;
        private List<int> _vec;
        #endregion

        #region Exceptions
        public class InvalidSizeException : Exception { };
        public class OutofIndexException : Exception { };
        public class IndexOfZeroException : Exception { };
        public class DimensionMismatchException : Exception { };
        #endregion

        #region Properties
        public int getSize()
        {
            return _size;
        }
        #endregion

        #region Constructors
        public Xmatrix()
        {
            _size = 3;
            _vec = new List<int>(){1,2,3,4,5};
        }
        public Xmatrix(int _size)
        {
            if(_size % 2 == 0 || _size < 3) throw new InvalidSizeException();
            this._size = _size;
            int length = _size * 2 - 1;
            _vec = new List<int>();
            for(int i = 0; i < length; i++)
            {
                _vec.Add(0);
            }
        }

        public Xmatrix(List<int> list) 
        {
            setMatrix(list);
        }

        public Xmatrix(Xmatrix xmatrix)
        {
            _size = xmatrix._size;
            _vec = xmatrix._vec;
        }
        #endregion

        #region Getters and setters

        public int getEntry(int row, int col)
        {
            if(row < 0 || col < 0 || row > _size-1 || col > _size-1) throw new OutofIndexException();
            if(isInDiagonals(row, col)) return _vec[Index(row, col)];
            return 0;
        }

        public void setMatrix(List<int> list)
        {
            double n = (list.Count + 1)/2;
            int N = Convert.ToInt32(n);
            if(Math.Floor(n) == n && N % 2 != 0 && N > 2)
            {
                _size = N;
                _vec = list;
            }
            else
            {
                throw new InvalidSizeException();
            }
            
        }
        
        public void setEntry(int row, int col, int newValue)
        {
            _vec[Index(row, col)] = newValue;
        }
        #endregion

        #region Operator
        public static bool operator ==(Xmatrix a, Xmatrix b)
        {
            if(a.getSize () != b.getSize()) return false;
            for(int i = 0; i < a._vec.Count; i++)
            {
                if (a._vec[i] != b._vec[i]) return false;
            }
            return true;
        }

        public static bool operator !=(Xmatrix a, Xmatrix b)
        {
            if (a.getSize() != b.getSize()) return true;
            for (int i = 0; i < a._vec.Count; i++)
            {
                if (a._vec[i] != b._vec[i]) return true;
            }
            return false;
        }

        public static Xmatrix operator +(Xmatrix a, Xmatrix b)
        {
            if(a.getSize() != b.getSize()) throw new DimensionMismatchException();
            Xmatrix result = new Xmatrix(a.getSize());
            for(int i = 0; i < a._vec.Count; i++)
            {
                result._vec[i] = a._vec[i] + b._vec[i];
            }
            return new Xmatrix(result);
        }

        public static Xmatrix operator *(Xmatrix a, Xmatrix b)
        {
            if(a.getSize() == b.getSize())
            {
                Xmatrix result = new Xmatrix(a.getSize());
                for (int i = 0; i < a.getSize(); i++)
                {
                    for (int j = 0; j < b.getSize(); j++)
                    {
                        if (a.isInDiagonals(i, j))
                        {
                            for(int k = 0; k < a.getSize(); k++)
                            {
                                result.setEntry(i, j, result.getEntry(i, j) + a.getEntry(i, k) * b.getEntry(k, j));
                            }
                        }
                    }
                }
                return result;
            }
            else throw new DimensionMismatchException();
        }
        public override string ToString()
        {
            string s = string.Empty;
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    s += this.getEntry(i, j) + " ";
                }
                s += System.Environment.NewLine;
            }
            return s;
        }
        #endregion

        #region Helper functions
        private int Index(int row, int col)
        {
            if (row < 0 || row > _size - 1 || col < 0 || col > _size - 1) throw new OutofIndexException();

            else if (row + col == _size - 1 || row == col)
            {
                int ind = row * 2;
                if (row <= _size / 2 && col > _size / 2)
                {
                    ind++;
                }
                else if (row > _size / 2 && col < _size / 2)
                {
                    ind--;
                }
                return ind;
            }
            else throw new IndexOfZeroException();
        }
        public bool isInDiagonals(int row, int col)
        {
            return (0 <= row && 0 <= col && row < _size && col < _size && row + col == _size - 1 || row == col);
        }
        #endregion

    }
}

//Implement the X matrix type which contains integers. These are
//square matrices that can contain nonzero entries only in their two
//diagonals. Don't store the zero entries. Store only the entries that
//can be nonzero in a sequence. Implement as methods: getting the
//entry located at index (i, j), adding and multiplying two matrices,
//and printing the matrix (in a square shape). 
