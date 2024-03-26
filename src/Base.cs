namespace inventory_management.src
{
    public class Base
    {
        private readonly int _id;
        private readonly DateTime _createdDate;

        public Base(DateTime createdDate = default)
        {
            _id = DateTime.Now.Microsecond;
            _createdDate = createdDate == default ? DateTime.Now : createdDate;
        }

        public DateTime GetCreatedDate()
        {
            return _createdDate;
        }

        public int GetId()
        {
            return _id;
        }
    }
}