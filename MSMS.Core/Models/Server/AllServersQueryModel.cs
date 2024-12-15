using System.ComponentModel;
using MSMS.Infrastructure.Data.Enums;

namespace MSMS.Core.Models;

public class AllServersQueryModel
{
    public const int ServersPerPage  = 9;

    public int CurrentPage { get; set; } = 1;

    public int TotalServersCount { get; set; }

    [DisplayName("Search By Text")]
    public string SearchItem { get; set; } = null!;

    [DisplayName("Sort By")]
    public SortingType SortingType { get; set; }

    public IEnumerable<ServerViewModel> Servers { get; set; } = new HashSet<ServerViewModel>();
}
