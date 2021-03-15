namespace Quest
{
    public class Hat
    {
        public int ShininessLevel { get; set; }
        private string _shininessDescription;
        public string ShininessDescription
        {
            get
            {
                return _shininessDescription;
            }
            set
            {


                if (ShininessLevel >= 2 && ShininessLevel <= 5)
                {
                    _shininessDescription = "noticeable";
                }
                else if (ShininessLevel >= 6 && ShininessLevel <= 9)
                {
                    _shininessDescription = "bright";
                }
                else if (ShininessLevel > 9)
                {
                    _shininessDescription = "blinding";
                }
            }
        }

    }
}