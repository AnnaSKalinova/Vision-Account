namespace AccountingProgram.Services.Items.Models
{
    using System.Collections.Generic;
    
    public class ItemQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int TotalItems { get; init; }

        public int ItemsPerPage { get; init; }

        public IEnumerable<ItemServiceModel> Items { get; init; }
    }
}
