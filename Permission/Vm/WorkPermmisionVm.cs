using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Permission.Vm
{
    public class WorkPermmisionVm
    {
        public int Id { get; set; }
        public string MangerName { get; set; }
        public string EmployeeName { get; set; }
        public string DeaparementNme { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
   

    
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    public class WorkPermmisionPostVm
    {
        public int Id { get; set; }
        [Required]
        public int MangerId { get; set; }
        [Required]

        public string WorkConditions { get; set; }
        [Required]

        public int WorkPermitApprovers { get; set; }
        [Required]

        public int WorkPermitReject { get; set; }
        [Required]

        public string EquipmentUsed { get; set; }
        public string FilesAttached { get; set; }
        [Required]

        public string EmployeeName { get; set; }

        public string EmployeeRole { get; set; }
        [Required]

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Required]

        public string Status { get; set; }
        [ForeignKey("Department")]
        [Required]

        public int DepartmentId { get; set; }

        public string Equipment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
