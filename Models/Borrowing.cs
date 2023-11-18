using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vicol_Lorena_Lab2.Models
{
    public class Borrowing
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        
        public int? BookID { get; set; }

        public Book? Book { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReturnDate { get; set; }
    }
}
