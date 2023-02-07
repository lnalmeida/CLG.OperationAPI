using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace CLG.OperationsAPI.Application.Entity
{
    [Table("operations")]
    public class Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("DescriptionOp")]
        [Required]
        public string DescriptionOp { get; set; }

        [Column("DateOp")]
        [Required]
        public DateTime DateOp { get; set; }
        private double _valueOp;
        [Column("ValueOp")]
        [Required]
        public double ValueOp
        {
            get { return _valueOp; }
            set
            {
                _valueOp = value;
                if (TypeOp == 1)
                {
                    _valueOp = (_valueOp * (-1));
                }
            }
        }
        private int _typeOp;
        [Column("TypeOp")]
        [Required]
        public int TypeOp
        {
            get { return _typeOp; }
            set
            {
                if (value == 0 || value == 1)
                {
                    _typeOp = value;
                }
                else
                {
                    throw new ArgumentException("TypeOp can only be either 0 or 1");
                }
            }
        }
    }
}


