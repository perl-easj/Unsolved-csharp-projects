namespace Flinter
{
    public class Profile
    {
        private bool _gender;
        private string _eyeColor;
        private string _hairColor;
        private int _heightCategory;

        public Profile(bool gender, string eyeColor, string hairColor, int heightCategory)
        {
            _gender = gender;
            _eyeColor = eyeColor;
            _hairColor = hairColor;
            _heightCategory = heightCategory;
        }

        public string Description
        {
            get
            {
                string description = "You got a " + GenderDescription;

                description = description + ", with " + _eyeColor + " eyes";
                description = description + ", " + _hairColor + " hair";
                description = description + ", who is " + HeightDescription;

                return description;
            }
        }

        public string GenderDescription
        {
            get { return _gender ? "man" : "woman"; }
        }

        public string HeightDescription
        {
            get
            {
                switch (_heightCategory)
                {
                    case 0:
                        return "Very short";
                    case 1:
                        return "Short";
                    case 2:
                        return "Medium height";
                    case 3:
                        return "Tall";
                    case 4:
                        return "Very tall";
                    default:
                        return "Unknown height";
                }
            }
        }
    }
}