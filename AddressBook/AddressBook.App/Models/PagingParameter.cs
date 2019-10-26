namespace AddressBook.App.Models
{

    public class PagingParameter
    {
        private const int MaxPageSize = 50;

        private int _pageSize = 10;

        private int _pageNumber = 1;


        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize || value < 1 ? MaxPageSize : value;
        }

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value < 1 ? 1 : value;
        }

    }
}
