namespace PruebaTecnica.Dtos
{
    public class PaginationDTO
    {
        public int Page { get; set; } = 1;
        private int recordsPerPage = 5;
        private readonly int MaxPage = 10;
        public int RecordsPerPage
        {
            get { return recordsPerPage; }
            set
            {
                recordsPerPage = (value > MaxPage) ? MaxPage : value;
            }
        }
    }

}
