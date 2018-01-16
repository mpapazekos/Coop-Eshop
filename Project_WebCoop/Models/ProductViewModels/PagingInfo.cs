

namespace Project_WebCoop.Models.ProductViewModels
{
    public  class PagingInfo
    {
        public int CurrentPage { get; set; }

        public int TotalItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int TotalPages => (int) System.Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}