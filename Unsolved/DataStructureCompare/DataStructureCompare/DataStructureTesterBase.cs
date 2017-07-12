using System;

namespace DataStructureCompare
{
    /// <summary>
    /// Base class for classes testing a specific collection class.
    /// The methods from IDataStructureTester are implemented, but
    /// the specific action done in each iteration is deferred to
    /// the sub-classes, by making the ...Statement methods abstract.
    /// </summary>
    /// <typeparam name="T">
    /// Type of collection class to test
    /// </typeparam>
    public abstract class DataStructureTesterBase<T> : IDataStructureTester
    {
        #region Instance fields
        private Random _generator;
        private T _collection;
        #endregion

        #region Constructor
        protected DataStructureTesterBase(T collection)
        {
            _generator = new Random();
            _collection = collection;
        }
        #endregion

        #region Properties
        public Random Generator
        {
            get { return _generator; }
        }

        public T Collection
        {
            get { return _collection; }
        }
        #endregion

        #region Implementation of IDataStructureTester
        public long AddInitial(int valuesToAdd, int maxValue)
        {
            return TimedTester.MeasureRunTimeLoop(() => { AddInitialStatement(Generator.Next(maxValue)); }, valuesToAdd);
        }

        public long InsertBack(int valuesToAdd, int maxValue)
        {
            return TimedTester.MeasureRunTimeLoop(() => { InsertBackStatement(Generator.Next(maxValue)); }, valuesToAdd);
        }

        public long InsertFront(int valuesToAdd, int maxValue)
        {
            return TimedTester.MeasureRunTimeLoop(() => { InsertFrontStatement(Generator.Next(maxValue)); }, valuesToAdd);
        }

        public long LookupRandom(int numerofLookups)
        {
            return TimedTester.MeasureRunTimeLoop(LookupRandomStatement, numerofLookups);
        }

        public long DeleteRandom(int numberofDeletes)
        {
            return TimedTester.MeasureRunTimeLoop(DeleteRandomStatement, numberofDeletes);
        }

        public long FindRandom(int numberofFinds, int maxValue)
        {
            return TimedTester.MeasureRunTimeLoop(() => { FindRandomStatement(Generator.Next(maxValue)); }, numberofFinds);
        }
        #endregion

        #region Abstract methods to be implemented in sub-classes
        public abstract void AddInitialStatement(int valueToInsert);
        public abstract void InsertBackStatement(int valueToInsert);
        public abstract void InsertFrontStatement(int valueToInsert);
        public abstract void LookupRandomStatement();
        public abstract void DeleteRandomStatement();
        public abstract void FindRandomStatement(int valueToFind); 
        #endregion
    }
}