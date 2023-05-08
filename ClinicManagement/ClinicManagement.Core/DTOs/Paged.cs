namespace ClinicManagement.Core.DTOs;

public class Paged<T> where T : class
{
    public Paged(IEnumerable<T> data, int pageSize, int pageNumber, int totalItemsCount)
    {
        Data = data;
        PageSize = pageSize;
        PageNumber = pageNumber;
        TotalItemsCount = totalItemsCount;
    }

    public IEnumerable<T> Data { get; }
    public int PageSize { get; }
    public int PageNumber { get; }
    public int TotalItemsCount { get; }

    public int TotalPages
    {
        get
        {
            if (TotalItemsCount <= PageSize)
                return 1;

            return (int)Math.Ceiling((decimal)TotalItemsCount / PageSize);
        }
    }
}