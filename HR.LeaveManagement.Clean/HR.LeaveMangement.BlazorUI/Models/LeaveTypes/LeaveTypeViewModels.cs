using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HR.LeaveMangement.BlazorUI.Models.LeaveTypes;

public class LeaveTypeViewModels
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Number")]
        public int DefaultDays { get; set; }
    }
}
