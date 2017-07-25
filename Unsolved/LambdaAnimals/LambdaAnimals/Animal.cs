using System;

namespace LambdaAnimals
{
    /// <summary>
    /// This class is supposed to represent any kind of animal.
    /// The type of the animal should be returned by the AnimalType property.
    /// </summary>
    public class Animal
    {
        private Func<string> _animalTypeFunc;
        private Func<string> _soundFunc;

        public Animal(Func<string> animalTypeFunc, Func<string> soundFunc)
        {
            _soundFunc = soundFunc;
            _animalTypeFunc = animalTypeFunc;
        }

        /// <summary>
        /// Returns the type of the animal, e.g. Cat, Dog or something else. 
        /// </summary>
        public string AnimalType
        {
            get { return _animalTypeFunc(); }
        }

        /// <summary>
        /// Returns the sound this particular animal makes.
        /// </summary>
        public string Sound
        {
            get { return _soundFunc(); }
        }

        /// <summary>
        /// Convenient ToString override...
        /// </summary>
        public override string ToString()
        {
            return "A " + AnimalType + " that says " + Sound;
        }
    }
}