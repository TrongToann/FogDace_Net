﻿using Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("TinhCach")]
    public class TinhCach : EntityBase<Guid>
    {
        [ForeignKey(nameof(PetHealthProfile))]
        public Guid PetHealthProfile_id { get; set; }
        public PetHealthProfile PetHealthProfile { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}
