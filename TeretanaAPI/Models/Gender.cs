namespace TeretanaAPI.Models
{
    public class Gender
    {
        private int genderId;

        public int GenderId
        {
            get { return genderId; }
            set { genderId = value; }
        }

        private String genderName;

        public String GenderName
        {
            get { return genderName; }
            set { genderName = value; }
        }
    }
}